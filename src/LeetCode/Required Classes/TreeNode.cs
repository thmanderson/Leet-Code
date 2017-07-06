using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{    
    
    /// <summary>
    /// Class used for LeetCode problem 617 - <see cref="Easy.MergeTrees(TreeNode, TreeNode)"/>
    /// </summary>
    public class TreeNode : IEquatable<TreeNode>
    {
        /// <summary> Value of of this Node. </summary>
        public int val;
        /// <summary> Node connected by 'left' branch of this node. </summary>
        public TreeNode left;
        /// <summary> Node connected by 'right' branch of this node. </summary>
        public TreeNode right;
        /// <summary> Create a node with a specified value, with both connected nodes NULL. </summary>
        /// <param name="x">Value for node.</param>
        public TreeNode(int x) { val = x; }

        /// <summary> Create a node with a specified value, and connecting nodes. </summary>
        /// <param name="x">Value for this node.</param>
        /// <param name="t1">Connecting node to the left.</param>
        /// <param name="t2">Connecting node to the right.</param>
        public TreeNode(int x, TreeNode t1, TreeNode t2)
        {
            val = x;
            left = t1;
            right = t2;
        }

        /// <summary> Equality method for TreeNode. </summary>
        /// <param name="t">TreeNode to be compared to.</param>
        /// <returns>True is values are equal for this Node, and all connected nodes.</returns>
        public bool Equals(TreeNode t)
        {
            // Check base value
            if (val != t.val) return false;

            // Check left node
            if (left == null)
            {
                if (t.left != null) return false;
            }
            else
            {
                if (t.left == null) return false;
                else if (!left.Equals(t.left)) return false;
            }

            // Check right node
            if (right == null)
            {
                if (t.right != null) return false;
            }
            else
            {
                if (t.right == null) return false;
                else if (!right.Equals(t.right)) return false;
            }

            return true;
        }

        /// <summary>
        /// Override Obj.Equals - <see cref="TreeNode.Equals(TreeNode)"/>
        /// </summary>
        /// <param name="obj">Object to be compared to.</param>
        /// <returns>True is both are TreeNodes, value is equal, and all connected values are equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is TreeNode) return Equals((TreeNode)obj);
            else return false;
        }

        /// <summary>
        /// Override for equality.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return val.GetHashCode() ^ left.GetHashCode() ^ right.GetHashCode();
        }

        // TODO: Should be implemented, but gave an error.
        public static bool operator ==(TreeNode t1, TreeNode t2)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(t1, t2))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)t1 == null) || ((object)t2 == null))
            {
                return false;
            }

            return t1.Equals(t2);
        }
        public static bool operator !=(TreeNode t1, TreeNode t2)
        {
            return !(t1 == t2);
        }
    }
}
