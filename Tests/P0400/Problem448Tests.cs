using Solutions.P0400;

namespace Tests.P0400;

[Trait("Problem", "400+")]
public class Problem448Tests
{
    [Theory(DisplayName = "448")]
    [MemberData(nameof(ExamplesMemberData))]
    public void TestExamples((int[] nums, IList<int> expected) @case)
    {
        var problem = new Problem448();

        var answer = problem.FindDisappearedNumbers
        (
            @case.nums
        );

        answer.Should().BeEquivalentTo(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[] nums, IList<int> expected)> Examples()
    {
        yield return ([4, 3, 2, 7, 8, 2, 3, 1], [5, 6]);
        yield return ([1, 1], [2]);
    }
}
