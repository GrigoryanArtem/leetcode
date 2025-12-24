using Solutions.P0700;

namespace Tests.P0700;

[Trait("Problem", "700+")]
public class Problem0797Tests
{
    [Theory(DisplayName = "797")]
    [MemberData(nameof(ExamplesMemberData))]
    public void FindJudge_Examples((int[][] graph, int[][] expected) @case)
    {
        var problem = new Problem0797();

        var answer = problem.AllPathsSourceTarget(@case.graph);

        answer.Should().BeEquivalentTo(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[][] graph, int[][] expected)> Examples()
    {
        yield return ([[1, 2], [3], [3], []], [[0, 1, 3], [0, 2, 3]]);
        yield return ([[4, 3, 1], [3, 2, 4], [3], [4], []], [[0, 4], [0, 3, 4], [0, 1, 3, 4], [0, 1, 2, 3, 4], [0, 1, 4]]);
    }
}
