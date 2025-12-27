using Solutions.P3700;

namespace Tests.P3700;

[Trait("Problem", "3700+")]
public class Problem3760Tests
{
    [Theory(DisplayName = "3760")]
    [MemberData(nameof(ExamplesMemberData))]
    public void FindJudge_Examples((string s, int n) testCase)
    {
        var problem = new Problem3760();

        var answer = problem.MaxDistinct
        (
            testCase.s
        );

        answer.Should().Be(testCase.n);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(string s, int n)> Examples()
    {
        yield return ("abab", 2);
        yield return ("abcd", 4);
        yield return ("aaaa", 1);
    }
}
