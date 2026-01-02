using Solutions.P2300;

namespace Tests.P2300;

[Trait("Problem", "2300+")]
public class Problem2391Tests
{
    [Theory(DisplayName = "2391")]
    [MemberData(nameof(ExamplesMemberData))]
    public void ExamplesTest((string[] grabage, int[] travel, int expected) @case)
    {
        var problem = new Problem2391();

        var answer = problem.GarbageCollection
        (
            @case.grabage,
            @case.travel
        );

        answer.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(string[] grabage, int[] travel, int expected)> Examples()
    {
        yield return (["G", "P", "GP", "GG"], [2, 4, 3], 21);
        yield return (["MMM", "PGM", "GP"], [3, 10], 37);
    }
}
