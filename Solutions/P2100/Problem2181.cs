namespace Solutions.P2100;

public class Problem2181
{
    public class ListNode(int val = 0, ListNode? next = null)
    {
        public int val = val;
        public ListNode? next = next;
    }

    public ListNode MergeNodes(ListNode head)
    {
        var prev = head;
        var currentSum = 0;

        for (var node = head.next; node is not null; node = node.next)
        {
            if (node.val == 0)
            {
                prev.next!.val = currentSum;
                prev = prev.next;
                currentSum = 0;
            }
            else
            {
                currentSum += node.val;
            }
        }

        prev.next = null;
        return head.next!;
    }
}
