namespace Solutions.P3800;

public class Problem3896
{
    private const int N = 100100;

    private static bool _init = false;
    private static bool[] _primes = [];
    private static int[] _next = [];

    public int MinOperations(int[] nums)
    {
        RecalculatePrimes();

        var permutations = 0;

        for (int i = 1; i < nums.Length; i += 2)
            if (_primes[nums[i]])
                permutations += nums[i] == 2 ? 2 : 1;


        for (int i = 0; i < nums.Length; i += 2)
            if (!_primes[nums[i]])
                permutations += _next[nums[i]] - nums[i];

        return permutations;
    }

    private static void RecalculatePrimes()
    {
        if (_init)
            return;

        _init = true;
        _primes = new bool[N];
        _next = new int[N];

        Array.Fill(_primes, true);
        _primes[0] = _primes[1] = false;

        for (int i = 2; i * i < N; i++)
        {
            if (!_primes[i])
                continue;

            for (int j = i * i; j < N; j += i)
                _primes[j] = false;
        }

        var current = 0;
        for (int i = N - 1; i >= 0; i--)
        {
            if (_primes[i])
                current = i;

            _next[i] = current;
        }
    }
}
