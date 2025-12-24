using Solutions.P1900;

namespace Tests.P1900;

[Trait("Problem", "1900+")]
public class Problem1971Tests
{
    [Theory(DisplayName = "1971")]
    [MemberData(nameof(ExamplesMemberData))]
    public void FindJudge_Examples((int n, int[][] edges, int source, int destination, bool expected) testCase)
    {
        var problem = new Problem1971();

        var answer = problem.ValidPath
        (
            testCase.n, 
            testCase.edges, 
            testCase.source, 
            testCase.destination
        );

        answer.Should().Be(testCase.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int n, int[][] edges, int source, int destination, bool expected)> Examples()
    {
        yield return (3, [[0, 1], [1, 2], [2, 0]], 0, 2, true);
        yield return (6, [[0, 1], [0, 2], [3, 5], [5, 4], [4, 3]], 0, 5, false);
    }
}
