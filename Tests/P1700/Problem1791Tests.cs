using Solutions.P1700;

namespace Tests.P1700;

[Trait("Problem", "1700+")]
public class Problem1791Tests
{
    [Theory(DisplayName = "1791")]
    [MemberData(nameof(ExamplesMemberData))]
    public void FindCenter_Examples((int[][] edges, int expected) @case)
    {
        var problem = new Problem1791();

        var answer = problem.FindCenter(@case.edges);

        answer.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[][] edges, int expected)> Examples()
    {
        yield return ([[1, 2], [2, 3], [4, 2]], 2);
        yield return ([[1, 2], [5, 1], [1, 3], [1, 4]], 1);
    }
}
