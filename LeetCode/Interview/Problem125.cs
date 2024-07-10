using System.Text.RegularExpressions;

namespace LeetCode.Interview;
/// <summary>
///     125. Valid Palindrome
///     https://leetcode.com/problems/valid-palindrome
/// </summary>
public class Problem125
{
    public bool IsPalindrome(string s)
    {
        string str = Regex.Replace(s.ToLowerInvariant(), @"[^a-zA-Z0-9]", "");
        int endIndex = str.Length - 1;
        int startIndex = 0;
        foreach ( char c in str )
        {
            if ( startIndex == endIndex )
            {
                break;
            }

            if ( c != str[endIndex] )
            {
                return false;
            }

            startIndex++;
            endIndex--;
        }

        return true;
    }

    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("race a car", false)]
    [InlineData(" ", true)]
    [InlineData("abcba", true)]
    [InlineData("abccba", true)]
    public void CanIsPalindrome(string s, bool expected) => IsPalindrome(s).Should().Be(expected);
}
