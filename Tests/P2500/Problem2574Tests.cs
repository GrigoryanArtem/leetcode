using Solutions.P2500;

namespace Tests.P2500;

[Trait("Problem", "2500+")]
public class Problem2574Tests
{
    [Theory(DisplayName = "2574")]
    [MemberData(nameof(ExamplesMemberData))]
    public void ExamplesTest((int[] nums, int[] expected) @case)
    {
        var problem = new Problem2574();

        var answer = problem.LeftRightDifference(@case.nums);

        answer.Should().BeEquivalentTo(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[] nums, int[] expected)> Examples()
    {
        yield return ([10, 4, 8, 3], [15, 1, 11, 22]);
        yield return ([1], [0]);
    }
}
