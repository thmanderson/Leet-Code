using System;
using System.Collections.Generic;
using Xunit;
using LeetCode.Model;

namespace LeetCode.Tests
{
    public class TreeNodeTests
    {
        public class MaxTreeDepth
        {
            [Theory]
            [MemberData(nameof(TreeData))]
            public void ValidInputs(Model.TreeNode x, int expectedResult)
            {
                int actualResult = TreeNode.MaxDepth(x);
                Assert.True(expectedResult.Equals(actualResult));
            }
            private static readonly List<object[]> _treeData
                = new List<object[]>
                {
                        new object[] { new Model.TreeNode(1), 1 },
                        new object[] { new Model.TreeNode(1, new Model.TreeNode(2), new Model.TreeNode(3)), 2 },
                        new object[] { null, 0 }
                };
            public static IEnumerable<object[]> TreeData
            {
                get { return _treeData; }
            }
        }
        public class MergeBinaryTrees
        {
            [Theory]
            [MemberData(nameof(TreeData))]
            public void ValidInputs(Model.TreeNode x, Model.TreeNode y, Model.TreeNode expectedResult)
            {
                var actualResult = TreeNode.MergeTrees(x, y);
                Assert.True(expectedResult.Equals(actualResult));
            }
            private static readonly List<object[]> _treeData
                = new List<object[]>
                {
                        new object[]
                        {
                            new Model.TreeNode(1), new Model.TreeNode(7), new Model.TreeNode(8)
                        }
                };
            public static IEnumerable<object[]> TreeData
            {
                get { return _treeData; }
            }
        }
    }
}
