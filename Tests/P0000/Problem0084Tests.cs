using Solutions.P0000;

namespace Tests.P0000;


[Trait("Problem", "0+")]
public class Problem0084Tests
{
    [Theory(DisplayName = "84")]
    [MemberData(nameof(ExamplesMemberData))]
    public void TestExamples((int[] heights, int expected) @case)
    {
        var problem = new Problem0084();

        var answer = problem.LargestRectangleArea
        (
            @case.heights
        );

        answer.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[] heights, int expected)> Examples()
    {        
        yield return ([2, 1, 5, 6, 2, 3], 10);
        yield return ([2, 4], 4);
    }
}
