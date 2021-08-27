namespace FastEnumString
{
	using System.Collections.Immutable;
	using Microsoft.CodeAnalysis;
	using Microsoft.CodeAnalysis.Diagnostics;

	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public sealed class FastEnumAnalyzer : DiagnosticAnalyzer
	{
		public static readonly DiagnosticDescriptor InheritEntitySystemRule = new
		(
			"FENUMA001",
			"TODO",
			"TODO",
			"Correctness",
			DiagnosticSeverity.Info,
			isEnabledByDefault: true
		);

		#region DiagnosticAnalyzer Members

		/// <inheritdoc/>
		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
			=> ImmutableArray.Create(InheritEntitySystemRule);

		/// <inheritdoc/>
		public override void Initialize(AnalysisContext context)
		{
			System.Diagnostics.Debugger.Launch();

			context.EnableConcurrentExecution();
			context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
			context.RegisterOperationAction(AnalyzeOperationInvocation, OperationKind.Invocation);
		}

		#endregion

		private static void AnalyzeOperationInvocation(OperationAnalysisContext context)
		{
			//if (context.Symbol is IParameterSymbol parameter
			//	&& (parameter.HasAddedAttribute() || parameter.HasChangedAttribute())
			//	&& !parameter.ContainingSymbol.HasUpdateAttribute())
			//{
			context.ReportDiagnostic(Diagnostic.Create(InheritEntitySystemRule, Location.None));
			//}
		}
	}
}
