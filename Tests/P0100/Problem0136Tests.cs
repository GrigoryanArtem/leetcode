using Solutions.P0100;

namespace Tests.P0100;

[Trait("Problem", "100+")]
public class Problem0136Tests
{
    [Theory(DisplayName = "136")]
    [MemberData(nameof(ExamplesMemberData))]
    public void ExamplesTest((int[] nums, int expected) @case)
    {
        var problem = new Problem0136();

        var answer = problem.SingleNumber(@case.nums);
        answer.Should().Be(@case.expected);

        var answer2 = problem.SingleNumberSimd(@case.nums);
        answer2.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[] nums, int expected)> Examples()
    {
        yield return ([2, 2, 1], 1);
        yield return ([4, 1, 2, 1, 2], 4);
        yield return ([1], 1);
        yield return ([], 0);
    }
}
