namespace Solutions.P1700;

public class Problem1700
{
    public int CountStudents(int[] students, int[] sandwiches)
    {
        Span<int> count = stackalloc int[2];

        foreach (int s in students)
            count[s]++;

        foreach (int s in sandwiches)
        {
            if (count[s] == 0)
                break;

            count[s]--;
        }

        return count[0] + count[1];
    }
}
