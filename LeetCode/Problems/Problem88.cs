namespace LeetCode.Problems;



/// <summary>
/// 88. Merge Sorted Array
/// https://leetcode.com/problems/merge-sorted-array/ 
/// </summary>
public class Problem88
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
       Array.Copy(nums2,0,nums1,m,n);
       Array.Sort(nums1);
    }
    
    [Test]
    [TestCase(new[]{1,0},1, new[]{2},1, new[]{1,2})]
    [TestCase(new[]{1,2,3,0,0,0},3, new[]{2,5,6},3, new[]{1,2,2,3,5,6})]
    public void Test(int[] nums1, int m, int[] nums2, int n, int[] res)
    {
        Merge(nums1, m, nums2, n);
        Assert.That(nums1, Is.EqualTo(res));
    }
    
}