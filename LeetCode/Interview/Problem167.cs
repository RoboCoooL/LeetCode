namespace LeetCode.Interview;
/// <summary>
///     167. Two Sum II - Input Array Is Sorted
///     https://leetcode.com/problems/two-sum-ii-input-array-is-sorted
/// </summary>
public class Problem167
{
    public int[] TwoSum(int[] nums, int target)
    {
        int startIndex = 0;
        int endIndex = nums.Length - 1;
        while ( startIndex < endIndex )
        {
            int sum = nums[startIndex] + nums[endIndex];
            if ( sum == target )
            {
                return [startIndex + 1, endIndex + 1];
            }

            if ( sum < target )
            {
                startIndex++;
            }
            else
            {
                endIndex--;
            }
        }

        return [];
    }

    [Theory]
    [InlineData(new[] {2, 7, 11, 15}, 9, new[] {1, 2})]
    [InlineData(new[] {2, 3, 4}, 6, new[] {1, 3})]
    [InlineData(new[] {-1, 0}, -1, new[] {1, 2})]
    public void CanTwoSum(int[] nums, int target, int[] expectedNums) =>
        TwoSum(nums, target).Should().BeEquivalentTo(expectedNums);
}
