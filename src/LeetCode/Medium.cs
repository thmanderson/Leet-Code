using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// Methods used to solve the 'Medium' algorithm problems on LeetCode: https://leetcode.com/problemset/algorithms/?difficulty=Medium 
    /// </summary>
    public class Medium
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
            return new ListNode(0);
        }

    }
}
