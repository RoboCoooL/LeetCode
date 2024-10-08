﻿namespace LeetCode.Interview;
/**
 * Definition for a binary tree node.
 */
public class TreeNode
{
    public TreeNode left;
    public TreeNode right;
    public int val;

    public TreeNode(int x) => val = x;

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

    // Preorder tree traversal (Root - Left - Right)
    public static void PreorderTraversal(TreeNode root)
    {
        if ( root == null )
        {
            return;
        }

        Stack<TreeNode> stack = new();
        stack.Push(root);
        while ( stack.Count > 0 )
        {
            TreeNode currNode = stack.Pop();
            Console.Write(currNode.val + " ");
            if ( currNode.right != null )
            {
                stack.Push(currNode.right);
            }

            if ( currNode.left != null )
            {
                stack.Push(currNode.left);
            }
        }
    }
}
