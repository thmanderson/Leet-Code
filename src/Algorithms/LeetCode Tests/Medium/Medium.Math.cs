using System;
using System.Collections.Generic;
using Xunit;
using LeetCode;
using static LeetCode.Medium;

namespace LeetCodeTests.Medium
{
    public class Math
    {
        public class ComplexNumberMultiplyTests
        {
            [Theory]
            [InlineData("1+2i","3+4i", "-5+10i")]
            public void TestInputs(string input1, string input2, string expectedResult)
            {
                string actualResult = ComplexNumberMultiply(input1, input2);
                Assert.Equal(expectedResult, actualResult);
            }
        }
        public class AddListNodes
        {
            [Theory]
            [MemberData(nameof(ListNodeData))]
            public void ValidInputs(ListNode input1, ListNode input2, ListNode expectedResult)
            {
                ListNode actualResult = AddTwoNumbers(input1, input2);
                Assert.Equal(expectedResult, actualResult);
            }

            private static readonly List<object[]> _listNodeData
                = new List<object[]>
                {
                        new object[]
                        {
                            new ListNode(1), new ListNode(7), new ListNode(8)
                        }
                };
            public static IEnumerable<object[]> ListNodeData
            {
                get { return _listNodeData; }
            }
        }

    }
}
