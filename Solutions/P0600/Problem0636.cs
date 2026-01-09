namespace Solutions.P0600;

public class Problem0636
{
    public int[] ExclusiveTime(int n, IList<string> logs)
    {
        var times = new int[n];
        var currentTime = 0;

        Span<int> stack = stackalloc int[501];
        int sidx = 0;


        foreach (var log in logs)
        {
            var (id, end, time) = Parse(log);

            if (end)
            {
                times[id] += time - currentTime + 1;
                sidx--;
            }
            else
            {
                if (sidx > 0)
                    times[stack[sidx - 1]] += time - currentTime - 1;

                stack[sidx++] = id;
            }

            currentTime = time;
        }

        return times;
    }

    private (int id, bool end, int time) Parse(ReadOnlySpan<char> log)
    {
        int id, time;
        bool end;
        var idx = 0;

        for (; log[idx] != ':'; idx++) ;

        id = Int32.Parse(log[..idx++]);
        end = log[idx] == 'e';

        for (; log[idx] != ':'; idx++) ;

        time = Int32.Parse(log[(idx + 1)..]);

        return (id, end, time);
    }
}
