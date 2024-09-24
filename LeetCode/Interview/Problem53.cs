namespace LeetCode.Interview;
/// <summary>
///     53. Maximum Subarray
///     https://leetcode.com/problems/maximum-subarray
/// </summary>
public class Problem53
{
    public int MaxSubArray(int[] nums)
    {
        if ( nums.Length == 0 )
        {
            return 0;
        }

        int maxSum = nums[0];
        int currSum = nums[0];

        for ( int i = 1; i < nums.Length; i++ )
        {
            currSum = Math.Max(currSum + nums[i], nums[i]);
            maxSum = Math.Max(maxSum, currSum);
        }

        return maxSum;
    }


    [Theory]
    [InlineData(new[] {-2, 1, -3, 4, -1, 2, 1, -5, 4}, 6)]
    [InlineData(new[] {1}, 1)]
    [InlineData(new[] {5, 4, -1, 7, 8}, 23)]
    [InlineData(new[] {-1, -2}, -1)]
    public void CanMaxSubArray(int[] nums, int expectedNum) => MaxSubArray(nums).Should().Be(expectedNum);
}
