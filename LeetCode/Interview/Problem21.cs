using System.Collections;

namespace LeetCode.Interview;
/// <summary>
///     21. Merge Two Sorted Lists
///     https://leetcode.com/problems/merge-two-sorted-lists
/// </summary>
public class Problem21
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if ( list1 is null && list2 is null )
        {
            return null;
        }

        if ( list1 is null )
        {
            return list2;
        }

        if ( list2 is null )
        {
            return list1;
        }

        int currVal;
        ListNode nextList1;
        ListNode nextList2;
        if ( list1.val <= list2.val )
        {
            currVal = list1.val;
            nextList1 = list1.next;
            nextList2 = list2;
        }
        else
        {
            currVal = list2.val;
            nextList1 = list1;
            nextList2 = list2.next;
        }

        ListNode res = new(currVal, MergeTwoLists(nextList1, nextList2));

        return res;
    }

    [Theory]
    [ClassData(typeof(ListNodeClassData))]
    public void CanMergeTwoLists(ListNode list1, ListNode list2, ListNode expected) =>
        MergeTwoLists(list1, list2).Should().BeEquivalentTo(expected);
}

public class ListNodeClassData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        ListNode list1 = new([1, 2, 4]);
        ListNode list2 = new([1, 3, 4]);
        ListNode expectedList = new([1, 1, 2, 3, 4, 4]);

        yield return [list1, list2, expectedList];

        list1 = null;
        list2 = null;
        expectedList = null;

        yield return [list1, list2, expectedList];

        list1 = null;
        list2 = new ListNode([0]);
        expectedList = new ListNode([0]);

        yield return [list1, list2, expectedList];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
