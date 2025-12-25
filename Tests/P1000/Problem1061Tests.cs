using Solutions.P1000;

namespace Tests.P1000;

[Trait("Problem", "1000+")]
public class Problem1061Tests
{
    [Theory(DisplayName = "1061")]
    [MemberData(nameof(ExamplesMemberData))]
    public void FindJudge_Examples((string s1, string s2, string baseStr, string expected) testCase)
    {
        var problem = new Problem1061();

        var answer = problem.SmallestEquivalentString
        (
            testCase.s1,
            testCase.s2,
            testCase.baseStr
        );

        answer.Should().Be(testCase.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(string s1, string s2, string baseStr, string expected)> Examples()
    {
        yield return ("parker", "morris", "parser", "makkek");
        yield return ("hello", "world", "hold", "hdld");
        yield return ("leetcode", "programs", "sourcecode", "aauaaaaada");
    }
}
