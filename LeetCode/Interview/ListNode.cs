namespace LeetCode.Interview;
/**
 * * Definition for singly-linked list.
 */
public class ListNode
{
    public ListNode next;
    public int val;

    public ListNode(int x, ListNode next = null)
    {
        val = x;
        this.next = next;
    }

    public ListNode(List<int> nodes, int pos = -1)
    {
        if ( nodes == null || nodes.Count == 0 )
        {
            return;
        }

        ListNode tailNext = this;

        val = nodes[0];
        Queue<ListNode> queue = new();
        queue.Enqueue(this);

        int i = 1;
        while ( nodes.Count > i )
        {
            ListNode curr = queue.Dequeue();
            if ( i == pos )
            {
                tailNext = curr;
            }

            int? nextVal = nodes[i++];

            curr.next = new ListNode((int)nextVal);
            queue.Enqueue(curr.next);
        }

        if ( pos > -1 )
        {
            ListNode tail = queue.Dequeue();
            tail.next = tailNext;
        }
    }
}
