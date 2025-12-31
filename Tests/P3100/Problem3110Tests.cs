using Solutions.P3100;

namespace Tests.P3100;

[Trait("Problem", "3100+")]
public class Problem3110Tests
{
    [Theory(DisplayName = "3512")]
    [MemberData(nameof(ExamplesMemberData))]
    public void FindJudge_Examples((string s, int expected) testCase)
    {
        var problem = new Problem3110();

        var answer = problem.ScoreOfString
        (
            testCase.s
        );

        answer.Should().Be(testCase.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(string s, int expected)> Examples()
    {
        yield return ("hello", 13);
        yield return ("zaz", 50);
    }
}
