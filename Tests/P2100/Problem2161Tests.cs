using Solutions.P2100;

namespace Tests.P2100;

[Trait("Problem", "2100+")]
public class Problem2161Tests
{
    [Theory(DisplayName = "2161")]
    [MemberData(nameof(ExamplesMemberData))]
    public void TestExamples((int[] nums, int pivot, int[] expected) @case)
    {
        var problem = new Problem2161();

        var answer = problem.PivotArray
        (
            @case.nums,
            @case.pivot
        );

        answer.Should().BeEquivalentTo(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[] nums, int pivot, int[] @case)> Examples()
    {
        yield return ([9, 12, 5, 10, 14, 3, 10], 10, [9, 5, 3, 10, 10, 12, 14]);
        yield return ([-3, 4, 3, 2], 2, [-3, 2, 4, 3]);
        yield return ([10, 10, 10, 10, 10], 10, [10, 10, 10, 10, 10]);
    }
}
