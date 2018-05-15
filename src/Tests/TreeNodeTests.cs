using System;
using System.Collections.Generic;
using Xunit;
using LeetCode.Model;

namespace LeetCode.Tests
{
    public class TreeNodeTests
    {
        [Theory]
        [MemberData(nameof(DepthTreeData))]
        public void MaxTreeDepth_ValidInputs(TreeNode x, int expectedResult)
        {
            int actualResult = TreeNodes.MaxDepth(x);
            Assert.True(expectedResult.Equals(actualResult));
        }

        [Theory]
        [MemberData(nameof(MergeTreeData))]
        public void MergeBinaryTrees_ValidInputs(TreeNode x, TreeNode y, TreeNode expectedResult)
        {
            var actualResult = TreeNodes.MergeTrees(x, y);
            Assert.True(expectedResult.Equals(actualResult));
        }

        #region Test Data

        public static readonly List<object[]> DepthTreeData
            = new List<object[]>
            {
                new object[] { new TreeNode(1), 1 },
                new object[] { new TreeNode(1, new TreeNode(2), new TreeNode(3)), 2 },
                new object[] { null, 0 }
            };

        public static readonly List<object[]> MergeTreeData
            = new List<object[]>
            {
                new object[]
                {
                    new TreeNode(1), new TreeNode(7), new TreeNode(8)
                }
            };

        #endregion
    }
}
