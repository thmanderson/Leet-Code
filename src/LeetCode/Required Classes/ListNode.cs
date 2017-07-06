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
    }
}
