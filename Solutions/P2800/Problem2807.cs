namespace Solutions.P2800;

public class Problem2807
{
    public class ListNode(int val = 0, ListNode? next = null)
    {
        public int val = val;
        public ListNode? next = next;
    }

    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
        var curr = head;

        while (curr?.next is not null)
        {
            var gcdNode = new ListNode(GCD(curr.val, curr.next.val), curr.next);

            curr.next = gcdNode;
            curr = gcdNode.next;
        }

        return head;
    }

    private static int GCD(int a, int b)
    {
        while (b != 0)
            (a, b) = (b, a % b);

        return a;
    }
}
