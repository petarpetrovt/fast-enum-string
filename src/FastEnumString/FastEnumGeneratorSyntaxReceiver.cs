namespace FastEnumString
{
	using System.Collections.Generic;
	using Microsoft.CodeAnalysis;
	using Microsoft.CodeAnalysis.CSharp.Syntax;

	internal sealed class FastEnumGeneratorSyntaxReceiver : ISyntaxReceiver
	{
		public List<EnumDeclarationSyntax> CandidateClasses { get; } = new();

		#region ISyntaxReceiver Members

		/// <inheritdoc/>
		public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
		{
			if (syntaxNode is EnumDeclarationSyntax enumDeclarationSyntax)
			{
				CandidateClasses.Add(enumDeclarationSyntax);
			}
		}

		#endregion
	}
}