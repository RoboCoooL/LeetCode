namespace LeetCode.Interview;
/// <summary>
///     20. Valid Parentheses
///     https://leetcode.com/problems/valid-parentheses
/// </summary>
public class Problem20
{
    public bool IsValid(string s)
    {
        Dictionary<char, char> bracketsMap = new() {{'{', '}'}, {'[', ']'}, {'(', ')'}};
        Stack<char> openBrackets = new();
        foreach ( char c in s )
        {
            if ( bracketsMap.ContainsKey(c) )
            {
                openBrackets.Push(c);
            }
            else
            {
                if ( !openBrackets.TryPop(out char bracket) )
                {
                    return false;
                }

                if ( c != bracketsMap[bracket] )
                {
                    return false;
                }
            }
        }

        return openBrackets.Count <= 0;
    }

    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    public void CanIsValid(string s, bool expected) =>
        IsValid(s).Should().Be(expected);
}
