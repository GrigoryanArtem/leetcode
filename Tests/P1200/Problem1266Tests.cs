using Solutions.P1200;

namespace Tests.P1200;

[Trait("Problem", "1200+")]
public class Problem1266Tests
{

    [Theory(DisplayName = "1266")]
    [MemberData(nameof(ExamplesMemberData))]
    public void TestExamples((int[][] points, int expected) @case)
    {
        var problem = new Problem1266();

        var answer = problem.MinTimeToVisitAllPoints
        (
            @case.points
        );

        answer.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[][] points, int expected)> Examples()
    {
        yield return ([[1, 1], [3, 4], [-1, 0]], 7);
        yield return ([[3, 2], [-2, 2]], 5);
    }
}
