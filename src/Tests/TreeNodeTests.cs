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
        public void MaxTreeDepth_ValidInputs(Model.TreeNode x, int expectedResult)
        {
            int actualResult = TreeNode.MaxDepth(x);
            Assert.True(expectedResult.Equals(actualResult));
        }

        [Theory]
        [MemberData(nameof(MergeTreeData))]
        public void MergeBinaryTrees_ValidInputs(Model.TreeNode x, Model.TreeNode y, Model.TreeNode expectedResult)
        {
            var actualResult = TreeNode.MergeTrees(x, y);
            Assert.True(expectedResult.Equals(actualResult));
        }

        #region Test Data

        public static readonly List<object[]> DepthTreeData
            = new List<object[]>
            {
                new object[] { new Model.TreeNode(1), 1 },
                new object[] { new Model.TreeNode(1, new Model.TreeNode(2), new Model.TreeNode(3)), 2 },
                new object[] { null, 0 }
            };

        public static readonly List<object[]> MergeTreeData
            = new List<object[]>
            {
                new object[]
                {
                    new Model.TreeNode(1), new Model.TreeNode(7), new Model.TreeNode(8)
                }
            };

        #endregion
    }
}
