using Solutions.P1700;

namespace Tests.P1700;

[Trait("Problem", "1700+")]
public class Problem1700Tests
{
    [Theory(DisplayName = "1700")]
    [MemberData(nameof(ExamplesMemberData))]
    public void TestExamples((int[] students, int[] sandwiches, int expected) @case)
    {
        var problem = new Problem1700();

        var answer = problem.CountStudents
        (
            @case.students,
            @case.sandwiches
        );

        answer.Should().Be(@case.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[] students, int[] sandwiches, int expected)> Examples()
    {
        yield return ([1, 1, 0, 0], [0, 1, 0, 1], 0);
        yield return ([1, 1, 1, 0, 0, 1], [1, 0, 0, 0, 1, 1], 3);
    }
}
