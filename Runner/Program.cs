using ScottPlot;
using ScottPlot.TickGenerators;
using System.Diagnostics;
using System.Numerics;

namespace Runner;

public class Program
{
    public record TestResult
    {
        public long TimeMs { get; init; }
    }

    static void Main(string[] args)
    {        
        var iterations = 10000;
        var sizes = new int[] 
        {
            10,
            50,
            100,
            500,
            1000,
            5000,
            10000,
            50000,
            100000,
            // 500000
        };

        var data = sizes.Select(GenerateRandomString).ToArray();

        var impl1 = Test(data, iterations, Impl1);
        var impl2 = Test(data, iterations, Impl2);
        var impl3 = Test(data, iterations, Impl3);
        var impl4 = Test(data, iterations, Impl4);

        var plot = new Plot();

        var scatt1 = plot.Add.Scatter(sizes, impl1.Select(x => x.TimeMs).ToArray());        
        var scatt2 = plot.Add.Scatter(sizes, impl2.Select(x => x.TimeMs).ToArray());
        var scatt3 = plot.Add.Scatter(sizes, impl3.Select(x => x.TimeMs).ToArray());
        var scatt4 = plot.Add.Scatter(sizes, impl4.Select(x => x.TimeMs).ToArray());

        scatt1.LegendText = "impl 1 (stackalloc)";
        scatt2.LegendText = "impl 2 (uint 32)";
        scatt3.LegendText = "impl 3 (uint 64)";
        scatt4.LegendText = "impl 4 (uint 32 + 4x)";

        plot.ShowLegend();

        plot.SavePng("tests.png", 2560, 1440);
    }

    static string LogTickLabelFormatter(double y) => $"{Math.Pow(10, y):N0}";

    private static string GenerateRandomString(int size)
    {
        var random = Random.Shared;
        var arr = new char[size];

        for(int i = 0; i < size; i++)
            arr[i] = (char)('a' + random.Next('z' - 'a' + 1));

        return new string(arr);
    }

    public static TestResult[] Test(string[] data, int iterations, Func<ReadOnlySpan<char>, int> f)
    {
        var result = new TestResult[data.Length];   

        for (int i = 0; i <  data.Length; i++)
        {
            var sw = Stopwatch.StartNew();

            for(int itr = 0; itr < iterations; itr++)
                f(data[i].AsSpan());

            result[i] = new() { TimeMs = sw.ElapsedMilliseconds };
        }

        return result;
    }

    public static int Impl1(ReadOnlySpan<char> s)
    {
        Span<byte> set = stackalloc byte['z' - 'a' + 1];
        for (int i = 0; i < s.Length; i++)
            set[s[i] - 'a'] = 1;

        var count = 0;
        for (int i = 0; i < set.Length; i++)
            count += set[i];

        return count;
    }

    public static int Impl2(ReadOnlySpan<char> s)
    {
        var set = 0U;
        for (int i = 0; i < s.Length; i++)
            set |= 1U << (s[i] - 'a');

        return BitOperations.PopCount(set);
    }

    public static int Impl3(ReadOnlySpan<char> s)
    {
        var set = 0UL;
        for (int i = 0; i < s.Length; i++)
            set |= 1UL << (s[i] - 'a');

        return BitOperations.PopCount(set);
    }

    public static int Impl4(ReadOnlySpan<char> s)
    {
        ulong set = 0;
        int i = 0;

        for (; i + 3 < s.Length; i += 4)
        {
            set |= 1UL << (s[i] - 'a');
            set |= 1UL << (s[i + 1] - 'a');
            set |= 1UL << (s[i + 2] - 'a');
            set |= 1UL << (s[i + 3] - 'a');
        }
        
        for (; i < s.Length; i++)
        {
            set |= 1UL << (s[i] - 'a');
        }

        return BitOperations.PopCount(set);
    }
}
