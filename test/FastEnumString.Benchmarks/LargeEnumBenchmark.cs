namespace FastEnumString.Benchmarks
{
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Jobs;

	[SimpleJob(RuntimeMoniker.Net50)]
	[SimpleJob(RuntimeMoniker.Net60)]
	[MemoryDiagnoser, MarkdownExporter, DisassemblyDiagnoser(exportHtml: true)]
	public class LargeEnumBenchmark
	{
		public LargeEnum Value { get; set; }

		[Benchmark]
		public string ToStringOriginal()
			=> Value.ToString();

		[Benchmark]
		public string ToStringFast()
			=> Value.ToStringFast();
	}
}
