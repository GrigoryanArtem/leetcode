using Solutions.P3500;

namespace Tests.P3500;

[Trait("Problem", "3500+")]
public class Problem3512Tests
{

    [Theory(DisplayName = "3512")]
    [MemberData(nameof(ExamplesMemberData))]
    public void FindJudge_Examples((int[] nums, int k, int expected) testCase)
    {
        var problem = new Problem3512();

        var answer = problem.MinOperations
        (
            testCase.nums,
            testCase.k
        );

        answer.Should().Be(testCase.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[] nums, int k, int expected)> Examples()
    {
        yield return ([3, 9, 7], 5, 4);
        yield return ([4, 1, 3], 4, 0);
        yield return ([3, 2], 6, 5);
    }
}
