namespace Solutions.P0200;

public class Problem0206
{
    public class ListNode(int val = 0, ListNode? next = null)
    {
        public int val = val;
        public ListNode? next = next;
    }

    public ListNode? ReverseList(ListNode? head)
    {
        if (head is null)
            return head;

        if (head.next is null)
            return head;

        var curr = head;
        var next = head.next;
        curr.next = null;

        while (next is not null)
        {
            var t = next.next;
            next.next = curr;

            curr = next;
            next = t;
        }

        return curr;
    }
}
