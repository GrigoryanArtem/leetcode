using Solutions.P1500;

namespace Tests.P1500;

[Trait("Problem", "1500+")]
public class Problem1557Tests
{
    [Theory(DisplayName = "1557")]
    [MemberData(nameof(ExamplesMemberData))]
    public void FindJudge_Examples((int n, IList<IList<int>> edges, IList<int> expected) testCase)
    {
        var problem = new Problem1557();

        var answer = problem.FindSmallestSetOfVertices
        (
            testCase.n,
            testCase.edges
        );

        answer.Should().BeEquivalentTo(testCase.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int n, IList<IList<int>> edges, IList<int> expected)> Examples()
    {
        yield return (6, [[0, 1], [0, 2], [2, 5], [3, 4], [4, 2]], [0, 3]);
        yield return (5, [[0, 1], [2, 1], [3, 1], [1, 4], [2, 4]], [0, 2, 3]);
    }
}
