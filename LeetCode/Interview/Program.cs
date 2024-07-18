namespace LeetCode.Interview;
public static class Program
{
    public static void Main()
    {
        TreeNode tree = new([4, 2, 7, 1, 3, 6, 9]);
        TreeNode.PreorderTraversal(tree);
    }
}
