namespace FastEnumString.Benchmarks
{
	using BenchmarkDotNet.Attributes;

	[MemoryDiagnoser, MarkdownExporter]
	public class FastEnumStringBenchmark
	{
		[Params(TestEnum.Test1)]
		public TestEnum Value { get; set; }

		[Benchmark]
		public string ToStringOriginal()
			=> Value.ToString();

		[Benchmark]
		public string ToStringFast()
			=> Value.ToStringFast();
	}
}
