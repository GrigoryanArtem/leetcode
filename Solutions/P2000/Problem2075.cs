namespace Solutions.P2000;

public class Problem2075
{
    public string DecodeCiphertext(string encodedText, int rows)
    {
        if (encodedText.Length == 0)
            return encodedText;

        var cols = encodedText.Length / rows;
        Span<char> ans = stackalloc char[(2 * cols - (rows - 1)) * rows / 2];

        var aidx = 0;
        var lst = 0;

        for (int i = 0; i < cols; i++)
        {
            int maxK = Math.Min(rows, cols - i);
            for (int k = 0; k < maxK; k++)
            {
                var ch = encodedText[k * cols + i + k];
                ans[aidx++] = ch;

                if (ch != ' ')
                    lst = aidx;
            }
        }

        return new string(ans[..lst]);
    }
}
