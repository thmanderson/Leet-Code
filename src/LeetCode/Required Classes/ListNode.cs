using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// Class used for LeetCode problem 2 <see cref="Medium.Math.AddTwoNumbers(ListNode, ListNode)"/>
    /// </summary>
    public class ListNode
    {
        /// <summary> Value of current node. </summary>
        public int val;
        /// <summary> Next node in the list. </summary>
        public ListNode next;
        /// <summary> Constructor for new node, with value but no linked nodes. </summary>
        public ListNode(int x) { val = x; }

        /// <summary> Constructor for new node, with value but no linked nodes. </summary>
        public ListNode(int x, int y) { val = x; next = new ListNode(y); }

        /// <summary> Equality method for ListNode. </summary>
        /// <param name="l">ListNode to be compared to.</param>
        /// <returns>True if values are equal for this Node, and all connected nodes.</returns>
        public bool Equals(ListNode l)
        {
            if (l == null) return false;

            // Check base value
            if (val != l.val) return false;

            // Check left node
            if (next == null)
            {
                if (l.next != null) return false;
            }
            else
            {
                if (l.next.Equals(null)) return false;
                else if (!next.Equals(l.next)) return false;
            }

            return true;
        }

        /// <summary>
        /// Override Obj.Equals - <see cref="ListNode.Equals(ListNode)"/>
        /// </summary>
        /// <param name="obj">Object to be compared to.</param>
        /// <returns>True if both are ListNodes, value is equal, and next connected node is equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ListNode) return Equals((ListNode)obj);
            else return false;
        }

        /// <summary>
        /// Override for equality.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return val.GetHashCode() ^ next.GetHashCode();
        }

        // TODO: Should be implemented, but gave an error.
        public static bool operator ==(ListNode l1, ListNode l2)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(l1, l2))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)l1 == null) || ((object)l2 == null))
            {
                return false;
            }

            return l1.Equals(l2);
        }
        public static bool operator !=(ListNode l1, ListNode l2)
        {
            return !(l1 == l2);
        }
    }
}
