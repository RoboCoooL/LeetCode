﻿using System.Collections;

namespace LeetCode.Interview;
/// <summary>
///     110. Balanced Binary Tree
///     https://leetcode.com/problems/balanced-binary-tree
/// </summary>
public class Problem110
{
    public bool IsBalanced(TreeNode root) => IsBalancedRecursive(root, out int _);

    private bool IsBalancedRecursive(TreeNode node, out int depth)
    {
        if ( node == null )
        {
            depth = 0;
            return true;
        }

        bool lIsBalanced = IsBalancedRecursive(node.left, out int lDepth);
        bool rIsBalanced = IsBalancedRecursive(node.right, out int rDepth);

        depth = Math.Max(lDepth, rDepth) + 1;

        return lIsBalanced && rIsBalanced && Math.Abs(lDepth - rDepth) < 2;
    }

    [Theory]
    [ClassData(typeof(IsBalancedTestData))]
    public void CanIsBalanced(TreeNode root, bool expected) =>
        IsBalanced(root).Should().Be(expected);
}

public class IsBalancedTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        TreeNode root = new([3, 9, 20, null, null, 15, 7]);
        yield return [root, true];

        root = new TreeNode([1, 2, 2, 3, 3, null, null, 4, 4]);
        yield return [root, false];

        root = null;
        yield return [root, true];

        root = new TreeNode([1, 2, 2, 3, null, null, 3, 4, null, null, 4]);
        yield return [root, false];

        root = new TreeNode([
            7, 0, 3, 8, 5, 7, 9, 3, 2, 2, 7, 4, 1, 7, 0, 6, 3, 0, 4, 7, 8, 0, 4, 5, 4, 4, 1, 3, 7, 3, 7, 9, 5, 6, 6, 7, 9, 5, 5, 8, 6, 2, 2, 6, 2, 5, 3, 8, 5, 6, 1, 0, 8, 6, 3, 1, 4, 2, 6, 4, 9, 5, 0, 0, 2, 1, 5, 7, 3, 8, 2, 2, 8, 2, 2, 4, 2, 2, 2, 5, 5, 5, 7, 0, 2, 7, 6, 3, 2, 7, 6, 5, 9, 6, 2, 7, 5, 8, 0, 6, 8, 1, 4, 0, 4, 8, 8, 1, 8, 5, 3, 6, 7, 5, 3, 0, 1, 8, 8, 2, 0, 3, 9, 3, 2, 1, 8, 3, 8, 8, 3, 9, 9, 5, 1, 1, 2, 7, 2, 6, 5, 8, 1, 3, 2, 8, 0, 2, 8, 9, 8, 1, 7, 1, 8, 1, 5, 2, 8, 8, 8, 0, 8, 3, 5, 8, 7, 1, 2, 8, 0, 3, 2, 8, 7, 6, 9, 5, 9, 1, 6, 7, 9, 9, 3, 6, 3, 0, 4, 3, 8, 1, 9, 8, 0, 4, 8, 5, 3, 4, 1, 7, 8, 3, 7, 4, 7, 3, 1, 0, 7, 7, 5, 8, 2, 6, 1, 5, 3, 3, 5, 4, 7, 9, 9, 0, 9, 4, 4, 8, 5, 4, 3, 7, 8, 3, 7, 6, 0, 3, 0, 9, 8, 5, 7, 4, 4, 0, 7, 7, 8, 7, 3, 4, 9, 5, 3, 6, 9, 7, 4, 7, 1, 7, null, 3, 3, 0, 9, 0, 1, 4, 0, 7, 2, 1, 6, 6, 9, 4, 8, 3, 0, 5, 5, 0, 8, 9, 8, 5, null, 8, 5, 5, 1, 9, 8, 9, 0, 2, 4, 6, 8, 8, 1, 8, 4, 9, 2, 5, 9, 1, 6, 7, 5, 0, 0, 0, 2, 6, 8, 3, 3, 0, 7, 1, 7, 8, 2, 3, 2, 9, 9, 2, 7, 3, 5, 0, 9, 0, 2, 3, 4, 0, 4, 2, 0, 0, 4, 0, 1, 3, 1, 1, 9, 1, 1, 8, 9, 1, 0, 0, 9, 9, 3, 4, 8, 0, 2, 7, 6, 8, 3, 2, 6, 6, 2, 9, 1, 2, 1, 7, 6, 6, 5, 0, 9, 5, 8, 7, 5, 9, 1, 4, 6, 2, 9, 7, 3, 7, 8, 0, 8, 2, 4, 9,
            9, 0, 9, 1, 8, 7, 3, 2, 6, 4, 8, 9, 3, 5, 7, 4, 0, 8, 1, 0, 1, 7, 3, 4, 2, 8, 4, 5, 2, 8, 5, 0, 3, 0, 5, 7, 3, 9, 2, 0, 8, 5, 7, 4, 7, 3, 6, 3, 7, 9, 5, 9, 2, 4, 9, 9, 6, 5, 5, 4, 6, 5, 2, 6, 6, 3, 8, 0, 9, 6, 2, 6, 7, 0, 2, 1, 5, 3, 5, 3, 9, 9, 0, 7, 9, 9, 5, 3, 2, 0, 4, 4, 1, 6, 1, 4, 7, 1, 1, 4, 6, 1, 3, 8, 7, 7, 2, 9, 4, 8, 6, 6, 1, 5, 7, 0, 2, null, null, null, null, null, null, 5, 2, 8, 4, 2, 5, 6, 5, 0, 8, 7, 1, 1, 9, 9, null, 4, 4, 1, null, 8, 4, 8, 5, 5, 4, 5, 5, 5, 6, 0, 4, 5, 3, 1, 3, 5, 4, 1, 2, 9, 9, 8, 7, 7, 9, 8, 5, null, null, 3, 2, 3, 7, 2, 4, 8, null, null, null, null, null, 4, 7, 4, 3, 6, 6, 3, 8, 6, 9, 4, 1, 7, 8, 9, 8, 2, 5, 9, 8, 5, 7, 9, 8, 0, 2, 8, null, 7, 1, 2, null, 1, 6, 2, 7, 8, 7, 3, 6, 9, 6, 3, null, 7, 2, 8, 9, 7, 8, 9, 4, 4, 8, 1, 3, 7, 8, 4, null, 7, 8, 7, 8, 8, null, null, null, 1, 5, 6, 4, 0, null, 4, null, 8, 7, 1, 3, 1, 1, 8, 7, 1, 4, 9, null, 7, 4, 2, null, 1, 0, 5, 0, 2, 9, 3, 2, 8, 3, 0, null, null, null, null, null, 6, 5, 9, 1, 2, 9, 7, 6, 8, 7, 7, 0, 0, 3, 2, 1, 8, 2, 0, 4, 9, 8, 7, 1, 6, 6, 7, null, 7, null, 6, null, 3, 7, 7, 9, 0, 2, 4, null, 1, null, null, null, 0, 1, 9, 6, 1, 1, 7, 9, 7, 8, 4, null, 8, 2, 4, 3, 4, 7, 3, null, 5, null, 7, null, 5, null, 5,
            null, 2, 5, 9, 6, 3, 1, 6, 5, 0, 7, 1, 2, 0, 8, 3, 7, 2, 3, 9, 9, 1, 4, 2, null, 2, null, 5, null, 6, null, 7, null, 0, null, 6, 2, 3, 7, 9, null, 7, 0, 4, 2, 2, 9, 2, 1, 9, null, null, null, 9, 2, 3, 9, 0, 7, 5, null, 9, 8, 2, 9, 0, 0, 6, 9, 3, 3, 6, 2, 3, null, 3, null, 2, 9, 9, 2, 3, 7, 9, null, 7, 5, 0, null, 9, 2, 6, 3, 7, null, null, null, 8, 1, 4, 1, null, null, null, null, 7, 7, 4, 9, 1, 2, 2, 0, 1, 1, 7, 3, 5, 5, 7, null, 4, 6, 7, 9, 4, 7, 2, 4, 6, null, 7, 2, 5, 5, 3, null, 7, 2, 7, 2, 7, null, 3, null, 8, 7, 4, 3, 4, 6, 4, 8, 0, 8, 8, 1, 1, 0, 7, 3, 4, 8, 8, null, 9, 4, 4, null, 5, null, 9, null, 5, 4, 5, 6, 0, 7, 9, 1, 9, 5, 8, null, 4, 3, 7, null, 7, 9, 9, null, 4, 9, 6, 3, 5, 9, 6, 8, 9, 4, 8, 2, 7, 3, 2, null, 7, 8, 1, 7, 2, null, 4, null, 6, 1, 7, 3, 2, 6, 3, 1, 0, 1, 9, 5, 3, 4, 7, 8, 0, null, 7, null, 0, null, null, null, 6, 7, 3, 6, 0, null, 6, null, null, null, null, null, null, null, null, null, 2, null, 3, null, 4, null, null, null, 9, null, null, null, 2, null, null, null, 4, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
            5, null, null, null, 0, null, null, null, 5, null, null, null, null, null, null, null, 0, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 3, null, null, null, null, null, null, null, 5, null, 8, null, 2, null, null, null, null, null, null, null, null, null, 6, null, null, null, 5, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 9, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, 1, 7, 6, null, null, null, null, null, null, 7, null, null, null, 8, null, null, null, null, null, null, null, 9, null, null, null, 9, null, null, null, 7, null,
            null, null, 8, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 6, null, null, null, null, null, null, null, 2, null, null, null, null, null, null, null, null, null, null, null, null, null, 7, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 3, null, null, null, 0, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 3, null, 4, null, 7, null, 6, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 6, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 5, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 4, null, null, null, null, null, null, null, 6, null, null, null, 8, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
            null, null, null, 4, 8, 4, 0, null, null, null, null, null, null, 2, null, null, null, 9, null, null, null, 3, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 4, null, 1, null, 9, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 3, null, 8, null, 8, null, null, null, null, null, 5, 4, 1, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 8, 7, 5, 5, null, null, null, null, null, null, null, null, null, null, 1, 8, 7, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 8, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
            null, null, null, null, null, null, null, null, null, null, null, null, null, 6, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 4, null, null, null, 3, null, null, null, 6, null, null, null, null, null, null, null, null, null, null, null, null, null, 5, null, null, null, 8
        ]);
        yield return [root, false];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
