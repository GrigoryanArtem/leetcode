using Solutions.P3600;

namespace Tests.P3600;

[Trait("Problem", "3600+")]
public class Problem3666Tests
{
    public record Example(
        string s,
        int k);

    [Theory(DisplayName = "3666")]
    [MemberData(nameof(ExamplesMemberData))]
    public void TestExamples((Example example, int expected) @case)
    {
        var problem = new Problem3666();
        var ex = @case.example;

        var answer = problem.MinOperations
        (
            ex.s,
            ex.k
        );

        answer.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(Example example, int expected)> Examples()
    {
        yield return (new("0000", 3), 4);
        yield return (new("01", 2), -1);
        yield return (new("101", 2), -1);
        yield return (new("110", 1), 1);
        yield return (new("0101", 3), 2);
    }
}
