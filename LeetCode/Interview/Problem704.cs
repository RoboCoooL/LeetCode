namespace LeetCode.Interview;
/// <summary>
///     704. Binary Search
///     https://leetcode.com/problems/binary-search
/// </summary>
public class Problem704
{
    public int Search(int[] nums, int target)
    {
        int startIndex = 0;
        int endIndex = nums.Length - 1;
        while ( startIndex <= endIndex )
        {
            int i = (endIndex + startIndex) / 2;

            if ( nums[i] == target )
            {
                return i;
            }

            if ( nums[i] > target )
            {
                if ( endIndex == i )
                {
                    endIndex--;
                }
                else
                {
                    endIndex = i;
                }
            }
            else
            {
                if ( startIndex == i )
                {
                    startIndex++;
                }
                else
                {
                    startIndex = i;
                }
            }
        }

        return -1;
    }

    [Theory]
    [InlineData(new[] {-1, 0, 3, 5, 9, 12}, 9, 4)]
    [InlineData(new[] {-1, 0, 3, 5, 9, 12}, 2, -1)]
    [InlineData(new[] {2, 5}, 5, 1)]
    public void CanSearch(int[] nums, int target, int expected) =>
        Search(nums, target).Should().Be(expected);
}
