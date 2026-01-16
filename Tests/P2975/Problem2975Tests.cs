using Solutions.P2900;

namespace Tests.P2975;

[Trait("Problem", "2900+")]
public class Problem2975Tests
{
    [Theory(DisplayName = "2975")]
    [MemberData(nameof(ExamplesMemberData))]
    public void TestExamples((int m, int n, int[] hFences, int[] vFences, int expected) @case)
    {
        var problem = new Problem2975();

        var answer = problem.MaximizeSquareArea
        (
            @case.m,
            @case.n,
            @case.hFences,
            @case.vFences
        );

        answer.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int m, int n, int[] hFences, int[] vFences, int expected)> Examples()
    {
        yield return (4, 3, [2, 3], [2], 4);
        yield return (6, 7, [2], [4], -1);
    }
}
