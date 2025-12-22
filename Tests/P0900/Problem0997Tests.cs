using Solutions.P0900;

namespace Tests.P0900;

[Trait("Problem", "900+")]
public class Problem0997Tests
{
    [Theory(DisplayName = "997")]
    [MemberData(nameof(ExamplesMemberData))]
    public void FindJudge_Examples((int n, int[][] thrust, int expected) @case)
    {
        var problem = new Problem0997();

        var answer = problem.FindJudge(@case.n, @case.thrust);

        answer.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int n, int[][] thrust, int expected)> Examples()
    {
        yield return (2, [[1, 2]], 2);
        yield return (3, [[1, 3], [2, 3]], 3);
        yield return (3, [[1, 3], [2, 3], [3, 1]], -1);
    }
}
