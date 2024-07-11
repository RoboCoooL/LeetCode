namespace LeetCode.Interview;
/// <summary>
///     242. Valid Anagram
///     https://leetcode.com/problems/valid-anagram
/// </summary>
public class Problem242
{
    public bool IsAnagram(string s, string t)
    {
        Dictionary<char, int> dictS = new();
        foreach ( char c in s )
        {
            if ( !dictS.TryAdd(c, 1) )
            {
                dictS[c]++;
            }
        }

        Dictionary<char, int> dictT = new();
        foreach ( char c in t )
        {
            if ( !dictT.TryAdd(c, 1) )
            {
                dictT[c]++;
            }
        }

        if ( dictS.Count != dictT.Count )
        {
            return false;
        }

        foreach ( KeyValuePair<char, int> kvp in dictS )
        {
            if ( !dictT.ContainsKey(kvp.Key) || dictT[kvp.Key] != kvp.Value )
            {
                return false;
            }
        }

        return true;
    }

    [Theory]
    [InlineData("anagram", "nagaram", true)]
    [InlineData("rat", "car", false)]
    public void CanIsAnagram(string s, string t, bool expected) => IsAnagram(s, t).Should().Be(expected);
}
