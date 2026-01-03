using Solutions.P3400;

namespace Tests.P3400;

[Trait("Problem", "3400+")]
public class Problem3467Tests
{

    [Theory(DisplayName = "3467")]
    [MemberData(nameof(ExamplesMemberData))]
    public void ExamplesTest((int[] nums, int[] expected) @case)
    {
        var problem = new Problem3467();

        var answer = problem.TransformArray
        (
            @case.nums
        );

        answer.Should().BeEquivalentTo(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[] nums, int[] expected)> Examples()
    {
        yield return ([4, 3, 2, 1], [0, 0, 1, 1]);
        yield return ([1, 5, 1, 4, 2], [0, 0, 1, 1, 1]);
    }
}
