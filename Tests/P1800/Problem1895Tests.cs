using Solutions.P1800;

namespace Tests.P1800;

[Trait("Problem", "1800+")]
public class Problem1895Tests
{
    [Theory(DisplayName = "1895")]
    [MemberData(nameof(ExamplesMemberData))]
    public void TestExamples((int[][] grid, int expected) @case)
    {
        var problem = new Problem1895();

        var answer = problem.LargestMagicSquare
        (
            @case.grid
        );

        answer.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[][] grid, int expected)> Examples()
    {
        yield return ([[7, 1, 4, 5, 6], [2, 5, 1, 6, 4], [1, 5, 4, 3, 2], [1, 2, 7, 3, 4]], 3);        
        yield return ([[5, 1, 3, 1], [9, 3, 3, 1], [1, 3, 3, 8]], 2);
    }
}
