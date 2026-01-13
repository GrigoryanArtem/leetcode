using Solutions.P3400;

namespace Tests.P3400;

[Trait("Problem", "3400+")]
public class Problem3453Tests
{

    [Theory(DisplayName = "3453")]
    [MemberData(nameof(ExamplesMemberData))]
    public void TestExamples((int[][] squares, double expected) @case)
    {
        var problem = new Problem3453();

        var answer = problem.SeparateSquares
        (
            @case.squares
        );

        answer.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[][] squares, double expected)> Examples()
    {        
        yield return ([[0, 0, 1], [2, 2, 1]], 1.0);
        yield return ([[0, 0, 2], [1, 1, 1]], 1.16667);
    }
}
