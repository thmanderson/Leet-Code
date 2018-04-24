using System;
using System.Collections;
using System.Collections.Generic;
using LeetCode.Model;

namespace LeetCode
{
    public static class TreeNode
    {
        /// <summary>
        /// Find the maximum depth of a tree of <see cref="TreeNode"/>s
        /// LeetCode problem 104 - Maximum Depth of Binary Tree: https://leetcode.com/problems/maximum-depth-of-binary-tree/#/description
        /// </summary>
        /// <param name="root">Root TreeNode</param>
        /// <returns>Maximum depth of the Tree</returns>
        public static int MaxDepth(Model.TreeNode root)
        {
            if (root == null) return 0; // If null tree, 0 depth.
            if (root.left==null && root.right==null) return 1; // If both connected nodes are null, depth of 1.

            // If non-null connected nodes, depth = deepest connected node + this node
            else if (root.left == null) return MaxDepth(root.right) + 1; 
            else if (root.right == null) return MaxDepth(root.left) + 1;
            else return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }

        /// <summary>
        /// Invert the input binary tree, i.e. left node becomes right, and all subsequent nodes also inverted.
        /// LeetCode problem 226 - Invert Binary Tree: https://leetcode.com/problems/invert-binary-tree/description/
        /// </summary>
        /// <param name="input">Binary tree to be inverted.</param>
        /// <returns>Inverted tree.</returns>
        public static Model.TreeNode InvertTree(Model.TreeNode root)
        {
            if (root == null) return null;
            var result = new Model.TreeNode(root.val);
            if (root.right != null) result.left = InvertTree(root.right);
            if (root.left != null) result.right = InvertTree(root.left);
            return result;
        }

        /// <summary>
        /// Turn a binary tree into a string.
        /// LeetCode problem 606 - Construct string from binary tree: https://leetcode.com/problems/construct-string-from-binary-tree/#/description
        /// </summary>
        /// <param name="t">Binary tree.</param>
        /// <returns>String representation of the tree.</returns>
        public static string Tree2str(Model.TreeNode t)
        {
            if (t == null) return "";

            // Add node value to string to start with.
            string output = t.val.ToString(), left = "", right = "";

            // Right hand node, include blank parens if left is null.
            if (t.right != null)
            {
                right = "(" + Tree2str(t.right) + ")";
                if (t.left == null) left = "()";
            }

            // Left hand node.
            if (t.left != null) left = "(" + Tree2str(t.left) + ")";

            // Combine!
            return output + left + right;
        }

        /// <summary>
        /// Merge 2 binary trees - i.e. if values overlap, add them together, if one is null, take the other value, if both null, null.
        /// LeetCode problem 617 - Merge Two Binary Trees: https://leetcode.com/problems/merge-two-binary-trees/#/description
        /// </summary>
        /// <param name="t1">First binary tree</param>
        /// <param name="t2">Second binary tree</param>
        /// <returns>Merged result of 2 input trees</returns>
        public static Model.TreeNode MergeTrees(Model.TreeNode t1, Model.TreeNode t2)
        {
            // If both are null, end of the tree for this node.
            if (t1 == null && t2 == null) return null;

            // If not, create new node, combining the 2 input values (either could be null).
            Model.TreeNode Final = new Model.TreeNode((t1 != null ? t1.val : 0) + (t2 != null ? t2.val : 0));

            // Create the 2 subsequent nodes from the new tree Final with recursion. Will end when both null.
            Final.left = MergeTrees(t1 != null ? t1.left : null, t2 != null ? t2.left : null);
            Final.right = MergeTrees(t1 != null ? t1.right : null, t2 != null ? t2.right : null);

            return Final;
        }
    }

}