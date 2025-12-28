namespace Solutions.P1700;

public class Problem1769
{    
    public int[] MinOperations(string boxes)
    {
        var span = boxes.AsSpan();
        var result = new int[span.Length];

        var counter = 0;
        var acc = 0;

        for (int i = span.Length - 1; i >= 0; i--)
        {            
            result[i] = acc;
            counter += span[i] & 1;
            acc += counter;
        }

        counter = 0;
        acc = 0;

        for (int i = 0; i < span.Length; i++)
        {
            result[i] += acc;
            counter += span[i] & 1; 
            acc += counter;
        }

        return result;
    }
}
