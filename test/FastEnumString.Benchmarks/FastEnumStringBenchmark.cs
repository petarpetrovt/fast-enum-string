namespace FastEnumString.Benchmarks
{
	using BenchmarkDotNet.Attributes;

	[MemoryDiagnoser, MarkdownExporter, DisassemblyDiagnoser(exportHtml: true)]
	public class FastEnumStringBenchmark
	{
		public TestEnum Value { get; set; }

		[Benchmark]
		public string ToStringOriginal()
			=> Value.ToString();

		[Benchmark]
		public string ToStringFast()
			=> Value.ToStringFast();
	}
}
