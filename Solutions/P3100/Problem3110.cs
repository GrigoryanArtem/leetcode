namespace Solutions.P3100;
public class Problem3110
{
    public int ScoreOfString(string s)
    {
        var ans = 0;

        for (int i = 1; i < s.Length; i++)
            ans += Math.Abs(s[i - 1] - s[i]);

        return ans;
    }
}
