namespace FastEnumString
{
	using System;
	using System.Linq;
	using System.Text;
	using Microsoft.CodeAnalysis;
	using Microsoft.CodeAnalysis.CSharp;
	using Microsoft.CodeAnalysis.CSharp.Syntax;
	using Microsoft.CodeAnalysis.Text;

	/// <summary>
	/// Represents a handle generator.
	/// </summary>
	[Generator]
	public class FastEnumGenerator : ISourceGenerator
	{
		private static readonly DiagnosticDescriptor ErrorGeneratingEnumSource = new
		(
			id: "FENUM001",
			title: "An error has occured while generating fast enum extensions",
			messageFormat: "An error has occured while generating source for enum with name `{0}`: {1}",
			category: "Compilation",
			defaultSeverity: DiagnosticSeverity.Error,
			isEnabledByDefault: true
		);

		private static readonly DiagnosticDescriptor SuccessfullyGeneratedEnumSource = new
		(
			id: "FENUM002",
			title: "Successfully generated fast enum extensions",
			messageFormat: "Successfully generated source for enum with name `{0}`",
			category: "Compilation",
			defaultSeverity: DiagnosticSeverity.Info,
			isEnabledByDefault: true
		);

		#region ISourceGenerator Members

		/// <inheritdoc/>
		public void Initialize(GeneratorInitializationContext context)
			=> context.RegisterForSyntaxNotifications(() => new FastEnumGeneratorSyntaxReceiver());

		/// <inheritdoc/>
		public void Execute(GeneratorExecutionContext context)
		{
			if (context.SyntaxReceiver is not FastEnumGeneratorSyntaxReceiver receiver)
			{
				return;
			}

			foreach (EnumDeclarationSyntax syntax in receiver.CandidateClasses)
			{
				SemanticModel semanticModel = context.Compilation.GetSemanticModel(syntax.SyntaxTree);
				INamedTypeSymbol? declaredSumbol = semanticModel.GetDeclaredSymbol(syntax);

				if (declaredSumbol is null)
				{
					continue;
				}

				try
				{
					string source = GenerateSource(declaredSumbol);

					context.ReportDiagnostic(Diagnostic.Create(SuccessfullyGeneratedEnumSource, Location.None, declaredSumbol.Name));
					context.AddSource($"{declaredSumbol.Name}.g.cs", SourceText.From(source, Encoding.UTF8));
				}
				catch (Exception ex)
				{
					context.ReportDiagnostic(Diagnostic.Create(ErrorGeneratingEnumSource, Location.None, declaredSumbol.Name, ex.Message));
				}
			}
		}

		#endregion

		private static string GenerateSource(INamedTypeSymbol enumSymbol)
		{
			string[] switchCases = enumSymbol
				.GetMembers()
				.Where(x => x.Kind == SymbolKind.Field)
				.Select(x => $"				case {enumSymbol.Name}.{x.Name}: return nameof({enumSymbol.Name}.{x.Name});")
				.ToArray();

			return
$@"namespace {enumSymbol.ContainingNamespace.ToDisplayString()}
{{
	{enumSymbol.DeclaredAccessibility.ToString().ToLowerInvariant()} static class {enumSymbol.Name}_FastEnumString
	{{
		public static string ToStringFast(this {enumSymbol.Name} value)
		{{
			switch(value)
			{{
{string.Join(Environment.NewLine, switchCases)}
				default:
					return null;
					//throw new System.ArgumentException($""{enumSymbol.Name} value `{{value}}` is not supported in this context."", nameof(value));
			}}
		}}
	}}
}}";
		}
	}
}