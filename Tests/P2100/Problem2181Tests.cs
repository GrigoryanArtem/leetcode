using Solutions.P2100;
using static Solutions.P2100.Problem2181;

namespace Tests.P2100;

[Trait("Problem", "2100+")]
public class Problem2181Tests
{
    [Theory(DisplayName = "2181")]
    [MemberData(nameof(ExamplesMemberData))]
    public void FindJudge_Examples((ListNode head, ListNode expected) testCase)
    {
        var problem = new Problem2181();

        var answer = problem.MergeNodes
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
        yield return (A2LN([0, 3, 1, 0, 4, 5, 2, 0]), A2LN([4, 11]));
        yield return (A2LN([0, 1, 0, 3, 0, 2, 2, 0]), A2LN([1, 3, 4]));
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
