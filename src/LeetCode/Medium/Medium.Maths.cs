using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium
{
    /// <summary>
    /// Methods used to solve the maths based 'Medium' algorithm problems on LeetCode: https://leetcode.com/problemset/algorithms/?difficulty=Medium 
    /// </summary>
    public class Math
    {
        /// <summary>
        /// LeetCode problem 537 - Complex Number Manipulation: https://leetcode.com/problems/complex-number-multiplication/#/description
        /// </summary>
        /// <param name="a">Complex number 1 - as a string.</param>
        /// <param name="b">Complex number 2 - as a string.</param>
        /// <returns>Complex number - 1 * 2 - as a string.</returns>
        public static string ComplexNumberMultiply(string a, string b)
        {
            // Split string into real and imaginary components.
            string[] leftStrings = a.Split('+');
            string[] rightStrings = b.Split('+');

            // Convert strings into integers:
            int leftReal = Convert.ToInt32(leftStrings[0]);
            int leftImaginary = Convert.ToInt32(leftStrings[1].TrimEnd('i'));
            int rightReal = Convert.ToInt32(rightStrings[0]);
            int rightImaginary = Convert.ToInt32(rightStrings[1].TrimEnd('i'));
            
            // Final real number:
            int finalReal = (leftReal * rightReal) - (leftImaginary * rightImaginary);
            // Final imaginary number:
            int finalImaginary = (leftReal * rightImaginary) + (leftImaginary * rightReal);

            return ( finalReal.ToString() + "+" + finalImaginary.ToString() + "i" );
        }

        /// <summary>
        /// LeetCode problem 2 - Add Two Numbers: https://leetcode.com/problems/add-two-numbers/#/description
        /// </summary>
        /// <param name="l1">First number.</param>
        /// <param name="l2">Second number.</param>
        /// <returns>Sum of 2 inputs.</returns>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result;

            if (l1 == null)
            {
                if (l2 == null) return null;
                else return l2;
            }
            else if (l2 == null) return l1;

            // L1 and L2 are the smallest numbers in a sequence.
            // e.g if L1 == 2, and links to another ListNode 1, which doesn't link to anything else, this represents the number 12.

            // Add up this node:
            int value = l1.val + l2.val;

            // If an extra 1 needs to be carried to the next sum:
            int carry = 0;
            if (value > 9) { carry = 1; value -= 10; }

            result = new ListNode(value);
            result.next = AddTwoNumbers(l1.next, l2.next);
            if (result.next == null && carry != 0) result.next = new ListNode(carry);
            else if (result.next != null) result.next = AddTwoNumbers(result.next, new ListNode(carry));
            return result;
        }
    }
}
