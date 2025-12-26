using Solutions.P0200;
using static Solutions.P0200.Problem0206;

namespace Tests.P0200;

[Trait("Problem", "200+")]
public class Problem0206Tests
{
    [Theory(DisplayName = "206")]
    [MemberData(nameof(ExamplesMemberData))]
    public void FindJudge_Examples((ListNode head, ListNode expected) testCase)
    {
        var problem = new Problem0206();

        var answer = problem.ReverseList
        (
            testCase.head
        );

        var expected = testCase.expected;
        while (expected is not null)
        {
            answer.Should().NotBeNull();
            expected.val.Should().Be(answer.val);

            answer = answer.next;
            expected = expected.next;
        }
    }

    public static IEnumerable<object?[]> ExamplesMemberData => Examples().ToMemberData();
    public static IEnumerable<(ListNode? head, ListNode? expected)> Examples()
    {
        yield return (A2LN([1, 2, 3, 4, 5]), A2LN([5, 4, 3, 2, 1]));
        yield return (A2LN([1, 2]), A2LN([2, 1]));
        yield return (A2LN([]), A2LN([]));
    }

    private static ListNode? A2LN(int[] arr)
    {
        if (arr.Length == 0)
            return null;

        var head = new ListNode(arr[0]);
        var curr = head;

        for (int i = 1; i < arr.Length; i++)
        {
            curr.next = new ListNode(arr[i]);
            curr = curr.next;
        }

        return head;
    }
}
