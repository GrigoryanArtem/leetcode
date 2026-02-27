using Solutions.P3500;

namespace Tests.P3500;

[Trait("Problem", "3500+")]
public class Problem3507Tests
{
    [Theory(DisplayName = "3507")]
    [MemberData(nameof(ExamplesMemberData))]
    public void TestExamples((int[] nums, int expected) @case)
    {
        var problem = new Problem3507();

        var answer = problem.MinimumPairRemoval
        (
            @case.nums
        );

        answer.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[] nums, int expected)> Examples()
    {        
        yield return ([5, 2, 3, 1], 2);
        yield return ([1, 2, 2], 0);
    }
}
