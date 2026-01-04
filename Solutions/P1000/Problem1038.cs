namespace Solutions.P1000;

public class Problem1038
{
    public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        public int val = val;

        public TreeNode? left = left;
        public TreeNode? right = right;
    }

    private int _currentSum = 0;

    public TreeNode? BstToGst(TreeNode? root)
    {
        if (root is null)
            return null;

        BstToGst(root.right);

        _currentSum += root.val;
        root.val = _currentSum;

        BstToGst(root.left);

        return root;
    }
}
