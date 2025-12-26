using Solutions.P2800;
using static Solutions.P2800.Problem2807;

namespace Tests.P2800;

[Trait("Problem", "2800+")]
public class Problem2807Tests
{
    [Theory(DisplayName = "2807")]
    [MemberData(nameof(ExamplesMemberData))]
    public void FindJudge_Examples((ListNode head, ListNode expected) testCase)
    {
        var problem = new Problem2807();

        var answer = problem.InsertGreatestCommonDivisors
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
    public static IEnumerable<(ListNode head, ListNode expected)> Examples()
    {
        yield return (A2LN([18, 6, 10, 3]), A2LN([18, 6, 6, 2, 10, 1, 3]));
        yield return (A2LN([7]), A2LN([7]));
    }

    private static ListNode A2LN(int[] arr)
    {        
        var head = new ListNode(arr[0]);
        var curr = head;

        for(int i = 1; i < arr.Length; i++)
        {
            curr.next = new ListNode(arr[i]);
            curr = curr.next;
        }

        return head;
    }
}
