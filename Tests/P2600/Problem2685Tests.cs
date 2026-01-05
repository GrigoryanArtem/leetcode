using Solutions.P2600;

namespace Tests.P2600;

[Trait("Problem", "2600+")]
public class Problem2685Tests
{
    [Theory(DisplayName = "2685")]
    [MemberData(nameof(ExamplesMemberData))]
    public void ExamplesTest((int n, int[][] edges, int expected) @case)
    {
        var problem = new Problem2685();

        var answer = problem.CountCompleteComponents
        (
            @case.n,
            @case.edges
        );

        answer.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int n, int[][] edges, int expected)> Examples()
    {
        yield return (6, [[0, 1], [0, 2], [1, 2], [3, 4]], 3);
        yield return (6, [[0, 1], [0, 2], [1, 2], [3, 4], [3, 5]], 1);
    }
}
