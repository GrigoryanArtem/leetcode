using Solutions.P1700;

namespace Tests.P1700;

[Trait("Problem", "1700+")]
public class Problem1769Tests
{
    [Theory(DisplayName = "1769")]
    [MemberData(nameof(ExamplesMemberData))]
    public void FindJudge_Examples((string boxes, int[] operations) testCase)
    {
        var problem = new Problem1769();

        var answer = problem.MinOperations
        (
            testCase.boxes
        );

        answer.Should().BeEquivalentTo(testCase.operations);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(string boxes, int[] operations)> Examples()
    {
        yield return ("110", [1, 1, 3]);
        yield return ("001011", [11, 8, 5, 4, 3, 4]);
    }
}
