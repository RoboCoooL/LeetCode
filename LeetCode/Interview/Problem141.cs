using System.Collections;

namespace LeetCode.Interview;
/// <summary>
///     141. Linked List Cycle
///     https://leetcode.com/problems/linked-list-cycle
/// </summary>
public class Problem141
{
    public bool HasCycle(ListNode head) => HasCycleRecursive(head, new Dictionary<ListNode, int>());

    private bool HasCycleRecursive(ListNode head, Dictionary<ListNode, int> indexes)
    {
        if ( head == null )
        {
            return false;
        }

        bool isCycle = !indexes.TryAdd(head, head.val);
        return isCycle ? isCycle : HasCycleRecursive(head.next, indexes);
    }

    public bool HasCycleStack(ListNode head)
    {
        if ( head == null )
        {
            return false;
        }

        bool isCycle = false;
        Dictionary<ListNode, int> indexes = [];
        Stack<ListNode> stack = new();
        stack.Push(head);
        while ( stack.Count > 0 && !isCycle )
        {
            ListNode node = stack.Pop();
            isCycle = !indexes.TryAdd(node, node.val);
            if ( node.next != null )
            {
                stack.Push(node.next);
            }
        }

        return isCycle;
    }

    [Theory]
    [ClassData(typeof(HasCycleTestData))]
    public void CanHasCycle(ListNode head, bool expected) => HasCycle(head).Should().Be(expected);
}

public class HasCycleTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        ListNode head = new([3, 2, 0, -4], 1);
        yield return [head, true];

        head = new ListNode([1, 2], 0);
        yield return [head, true];

        head = new ListNode([1]);
        yield return [head, false];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
