namespace Tests.Extensions;

public static class TestExtensions
{
    public static IEnumerable<object?[]> ToMemberData<T>(this IEnumerable<T?> source)
    {
        foreach (var item in source)
            yield return [item];
    }
}
