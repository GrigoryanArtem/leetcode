namespace Solutions.P2300;

public class Problem2396
{
    public bool IsStrictlyPalindromic(int n)
    {
        Span<int> buffer = new int[0x20];
        var isPalindromic = true;

        for(int b = 2; isPalindromic & b < n; b++)
        {
            var s = ToBase(n, b, buffer);
            isPalindromic &= IsPalindromic(s);
        }

        return isPalindromic;
    }

    private static bool IsPalindromic(Span<int> arr)
    {
        var isPalindromic = true;
        for (int left = 0, right = arr.Length - 1; isPalindromic & left <= right; left++, right--)
            isPalindromic &= arr[left] == arr[right];

        return isPalindromic;
    }

    private static Span<int> ToBase(int n, int b, Span<int> buffer)
    {
        int count = 0;  

        while(n > 0)
        {
            buffer[count++] = n % b; 
            n /= b;
        }
            
        return buffer[.. count];
    }
}
