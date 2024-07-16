namespace LeetCode.Interview;
/// <summary>
///     278. First Bad Version
///     https://leetcode.com/problems/first-bad-version
/// </summary>
public class Problem278 : VersionControl
{
    public int FirstBadVersion(int n)
    {
        if ( n == 1 )
        {
            return IsBadVersion(n) ? 1 : -1;
        }

        int start = 1;
        int end = n;
        while ( start <= end )
        {
            int j = start + (end - start) / 2;

            if ( IsBadVersion(j) )
            {
                if ( !IsBadVersion(j - 1) )
                {
                    return j;
                }

                end = j - 1;
            }
            else
            {
                if ( IsBadVersion(j + 1) )
                {
                    return j + 1;
                }

                start = j + 1;
            }
        }

        return -1;
    }

    [Theory]
    [InlineData(5, 4)]
    [InlineData(1, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 4)]
    [InlineData(2126753390, 1702766719)]
    public void CanFirstBadVersion(int n, int expected)
    {
        LastBadVersion = expected;
        FirstBadVersion(n).Should().Be(expected);
    }
}

public class VersionControl
{
    protected int LastBadVersion { get; set; }

    public bool IsBadVersion(int version) => version >= LastBadVersion;
}
