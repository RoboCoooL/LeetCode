namespace LeetCode.Problems;
/// <summary>
/// 26. Remove Duplicates from Sorted Array
/// https://leetcode.com/problems/remove-duplicates-from-sorted-array
/// </summary>
public class Problem26
{
    public int RemoveDuplicates(int[] nums)
    {
        var numsDict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            numsDict.TryAdd(num, 0);    
        }

        var k = numsDict.Keys.Count;
        
        Array.Copy(numsDict.Keys.ToArray(), 0, nums, 0, k);

        return k;
    }

    
    [Test]
    [TestCase(new[] {1,1,2}, new[]{1,2,0}, ExpectedResult = 2)]
    public int Test(int[] nums, int[] numsExpected)
    {
        var ret = RemoveDuplicates(nums);
        Assert.That(nums[..ret], Is.EqualTo(numsExpected[..ret]));
        return ret;
    }
}