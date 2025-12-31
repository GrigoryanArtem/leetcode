using Solutions.P1500;

namespace Tests.P1500;

[Trait("Problem", "1500+")]
public class Problem1512Tests
{
    [Theory(DisplayName = "1512")]
    [MemberData(nameof(ExamplesMemberData))]
    public void Examples_Test((int[] nums, int expected) testCase)
    {
        var problem = new Problem1512();

        var answer = problem.NumIdenticalPairs
        (
            testCase.nums
        );

        answer.Should().Be(testCase.expected);
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(int[] nums, int expected)> Examples()
    {
        yield return ([1, 2, 3, 1, 1, 3], 4);
        yield return ([1, 1, 1, 1], 6);
        yield return ([1, 2, 3], 0);
    }
}
