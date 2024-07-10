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
    [ClassData(typeof(TreeNodeClassData))]
    public void CanInvertTree(TreeNode root, TreeNode expected) =>
        InvertTree(root).Should().BeEquivalentTo(expected);
}

public class TreeNodeClassData : IEnumerable<object[]>
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

/**
 * Definition for a binary tree node.
 */
public class TreeNode
{
    public TreeNode left;
    public TreeNode right;
    public int val;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public TreeNode(List<int?> nodes)
    {
        if ( nodes == null || nodes.Count == 0 )
        {
            return;
        }

        val = (int)nodes[0]!;
        Queue<TreeNode> q = new();
        q.Enqueue(this);

        int i = 1;
        while ( i < nodes.Count )
        {
            TreeNode curr = q.Dequeue();
            int? nextVal = nodes[i++];
            if ( nextVal != null )
            {
                curr.left = new TreeNode((int)nextVal);
                q.Enqueue(curr.left);
            }

            if ( i >= nodes.Count )
            {
                return;
            }

            nextVal = nodes[i++];
            if ( nextVal != null )
            {
                curr.right = new TreeNode((int)nextVal);
                q.Enqueue(curr.right);
            }
        }
    }
}
