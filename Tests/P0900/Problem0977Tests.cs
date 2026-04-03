using Solutions.P0900;

namespace Tests.P0900;

[Trait("Problem", "900+")]
public class Problem0977Tests
{

    [Theory(DisplayName = "977")]
    [MemberData(nameof(ExamplesMemberData))]
    public void ExamplesTest((int[] nums, int[] expected) @case)
    {
        var problem = new Problem0977();

        var answer = problem.SortedSquares(@case.nums);
        answer.Should().BeEquivalentTo(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[] nums, int[] expected)> Examples()
    {
        yield return ([-4, -1, 0, 3, 10, 10, 10, 10, 10], [0, 1, 9, 16, 100, 100, 100, 100, 100]);
        yield return ([-7, -3, 2, 3, 11], [4, 9, 9, 49, 121]);
    }
}
