using System.Collections;

namespace LeetCode.Interview;
/// <summary>
///     235. Lowest Common Ancestor of a Binary Search Tree
///     https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree
/// </summary>
public class Problem235
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) => root;

    [Theory]
    [ClassData(typeof(LowestCommonAncestorTestData))]
    public void CanLowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q, TreeNode expected) =>
        LowestCommonAncestor(root, p, q).Should().BeEquivalentTo(expected);
}

public class LowestCommonAncestorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        TreeNode root = new([6, 2, 8, 0, 4, 7, 9, null, null, 3, 5]);
        TreeNode p = new([2, 0, 4, null, null, 3, 5]);
        TreeNode q = new([8, 7, 9]);
        TreeNode expected = new([6, 2, 8, 0, 4, 7, 9, null, null, 3, 5]);

        yield return [root, p, q, expected];

        root = new TreeNode([6, 2, 8, 0, 4, 7, 9, null, null, 3, 5]);
        p = new TreeNode([2, 0, 4, null, null, 3, 5]);
        q = new TreeNode([4, 3, 5]);
        expected = new TreeNode([2, 0, 4, null, null, 3, 5]);

        yield return [root, p, q, expected];

        root = new TreeNode([2, 1]);
        p = new TreeNode([2, 1]);
        q = new TreeNode([1]);
        expected = new TreeNode([2, 1]);

        yield return [root, p, q, expected];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
