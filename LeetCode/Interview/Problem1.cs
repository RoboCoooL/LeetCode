namespace LeetCode.Interview;
/// <summary>
///     1. Two Sum
///     https://leetcode.com/problems/two-sum
/// </summary>
public class Problem1
{
    public int[] TwoSum(int[] nums, int target)
    {
        for ( int i = 0; i < nums.Length; i++ )
        {
            for ( int j = i + 1; j < nums.Length; j++ )
            {
                if ( nums[i] + nums[j] == target )
                {
                    return [i, j];
                }
            }
        }

        return [];
    }

    [Theory]
    [InlineData(new[] {2, 7, 11, 15}, 9, new[] {0, 1})]
    [InlineData(new[] {3, 2, 4}, 6, new[] {1, 2})]
    [InlineData(new[] {3, 3}, 6, new[] {0, 1})]
    public void CanTwoSum(int[] nums, int target, int[] expectedNums)
        => TwoSum(nums, target).Should().BeEquivalentTo(expectedNums);
}
