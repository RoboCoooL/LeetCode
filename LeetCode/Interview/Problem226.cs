using System.Collections;

namespace LeetCode.Interview;
/// <summary>
///     226. Invert Binary Tree
///     https://leetcode.com/problems/invert-binary-tree
/// </summary>
public class Problem226
{
    public TreeNode InvertTree(TreeNode root)
    {
        if ( root == null )
        {
            return null;
        }

        Queue<TreeNode> q = new();
        q.Enqueue(root);
        while ( q.Count > 0 )
        {
            TreeNode currNode = q.Dequeue();
            if ( currNode.left != null )
            {
                q.Enqueue(currNode.left);
                (currNode.left, currNode.right) = (currNode.right, currNode.left);
            }
            else if ( currNode.right != null )
            {
                q.Enqueue(currNode.right);
                (currNode.left, currNode.right) = (currNode.right, currNode.left);
                continue;
            }

            if ( currNode.left != null )
            {
                q.Enqueue(currNode.left);
            }
        }

        return root;
    }

    [Theory]
    [ClassData(typeof(InvertTreeTestData))]
    public void CanInvertTree(TreeNode root, TreeNode expected) =>
        InvertTree(root).Should().BeEquivalentTo(expected);
}

public class InvertTreeTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        TreeNode root = new([4, 2, 7, 1, 3, 6, 9]);
        TreeNode expected = new([4, 7, 2, 9, 6, 3, 1]);

        yield return [root, expected];

        root = new TreeNode([1, null, 2]);
        expected = new TreeNode([1, 2, null]);

        yield return [root, expected];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
