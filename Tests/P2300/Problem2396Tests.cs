using Solutions.P2300;

namespace Tests.P2300;

[Trait("Problem", "2300+")]
public class Problem2396Tests
{
    [Theory(DisplayName = "2396")]
    [MemberData(nameof(ExamplesMemberData))]
    public void FindJudge_Examples((int n, bool expected) testCase)
    {
        var problem = new Problem2396();

        var answer = problem.IsStrictlyPalindromic
        (
            testCase.n
        );

        answer.Should().Be(testCase.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int n, bool expected)> Examples()
    {
        yield return (9, false);
        yield return (4, false);        
    }
}
