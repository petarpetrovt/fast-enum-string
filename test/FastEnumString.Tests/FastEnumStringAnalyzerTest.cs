namespace FastEnumString.Tests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	public class FastEnumStringAnalyzerTest
	{
		[TestMethod]
		public void Test()
		{
			Microsoft.CodeAnalysis.CSharp.Testing.MSTest.AnalyzerVerifier.Create<FastEnumAnalyzer>();

		}
	}
}