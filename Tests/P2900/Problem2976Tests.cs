using Solutions.P2900;

namespace Tests.P2900;

[Trait("Problem", "2900+")]
public class Problem2976Tests
{
    public record Example(
        string source,
        string target,
        char[] original,
        char[] changed,
        int[] cost);

    [Theory(DisplayName = "2976")]
    [MemberData(nameof(ExamplesMemberData))]
    public void TestExamples((Example example, long expected) @case)
    {
        var problem = new Problem2976();
        var ex = @case.example;

        var answer = problem.MinimumCost
        (
            ex.source,
            ex.target,
            ex.original,
            ex.changed,
            ex.cost
        );

        answer.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(Example example, long expected)> Examples()
    {
        yield return (new
        (
            "abcd",
            "acbe",
            ['a', 'b', 'c', 'c', 'e', 'd'],
            ['b', 'c', 'b', 'e', 'b', 'e'],
            [2, 5, 5, 1, 2, 20]
        ), 28);

        yield return (new
        (
            "aaaa",
            "bbbb",
            ['a', 'c'],
            ['c', 'b'],
            [1, 2]
        ), 12);

        yield return (new
        (
            "abcd",
            "adce",
            ['a'],
            ['e'],
            [10000]
        ), -1);
    }
}
