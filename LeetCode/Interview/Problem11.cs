namespace LeetCode.Interview;
/// <summary>
///     11. Container With Most Water
///     https://leetcode.com/problems/container-with-most-water
/// </summary>
public class Problem11
{
    public int MaxArea(int[] height)
    {
        int maxArea = 0;
        int beginIndex = 0;
        int endIndex = height.Length - 1;

        while ( beginIndex < endIndex )
        {
            maxArea = Math.Max(maxArea, (endIndex - beginIndex) * Math.Min(height[beginIndex], height[endIndex]));
            if ( height[beginIndex] < height[endIndex] )
            {
                beginIndex++;
            }
            else
            {
                endIndex--;
            }
        }

        return maxArea;
    }

    [Theory]
    [InlineData(new[] {1, 8, 6, 2, 5, 4, 8, 3, 7}, 49)]
    [InlineData(new[] {1, 1}, 1)]
    public void IsMaxArea(int[] height, int expected) =>
        MaxArea(height).Should().Be(expected);
}
