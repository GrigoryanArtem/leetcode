using Solutions.P2000;

namespace Tests.P2000;

[Trait("Problem", "2000+")]
public class Problem2075Tests
{

    [Theory(DisplayName = "2075")]
    [MemberData(nameof(ExamplesMemberData))]
    public void ExamplesTest((string encodedText, int rows, string expected) @case)
    {
        var problem = new Problem2075();

        var answer = problem.DecodeCiphertext(@case.encodedText, @case.rows);
        answer.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(string encodedText, int rows, string expected)> Examples()
    {
        yield return ("iveo    eed   l te   olc", 4, "i love leetcode");
        yield return ("ch   ie   pr", 3, "cipher");
        yield return ("coding", 1, "coding");        
    }
}
