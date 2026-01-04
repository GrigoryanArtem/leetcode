using Solutions.P1000;
using static Solutions.P1000.Problem1038;

namespace Tests.P1000;

[Trait("Problem", "1000+")]
public class Problem1038Tests
{
    [Theory(DisplayName = "1038")]
    [MemberData(nameof(ExamplesMemberData))]
    public void ExamplesTest((TreeNode root, TreeNode expected) @case)
    {
        var problem = new Problem1038();

        var answer = problem.BstToGst
        (
            @case.root
        );

        answer.Should().BeEquivalentTo(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(TreeNode root, TreeNode expected)> Examples()
    {
        yield break;
    }
}
