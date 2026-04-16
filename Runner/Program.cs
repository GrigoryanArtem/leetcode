using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Solutions.P0100;

namespace Runner;

public class Program
{    
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<TaskBenchmark>();
    }

    [RankColumn]
    [KeepBenchmarkFiles]
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
    public class TaskBenchmark
    {
        private Problem0136 _problem = new();
        private int[] data;

        [Params(1000, 10_000, 1_000_000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            data = new int[N];
            for (int i = 0; i < N; i++)
                data[i] = Random.Shared.Next();
        }

        [Benchmark(Baseline = true)]
        public int Simple()
        {
            return _problem.SingleNumber(data);
        }

        [Benchmark()]
        public int Simd()
        {
            return _problem.SingleNumberSimd(data);
        }
    }
}
