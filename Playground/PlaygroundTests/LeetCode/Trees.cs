using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Playground.LeetCode;

namespace PlaygroundTests.LeetCode
{
    [TestFixture]
    public class Trees
    {
        [Test]
        public void OnMaxDepth_ShouldReturnMaxDepth()
        {
            // Arrange
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.right.right = new TreeNode(5);

            // Act
            int maxDepth = Playground.LeetCode.Trees.MaxDepth(root);

            // Assert
            Assert.That(maxDepth, Is.EqualTo(3));
        }

        [Test]
        public void OnMaxDepth_ShouldReturnMaxDepth2()
        {
            // Arrange
            TreeNode root = new TreeNode(0);
            root.left = new TreeNode(2);
            root.right = new TreeNode(4);
            root.left.left = new TreeNode(1);
            root.left.left.left = new TreeNode(5);
            root.left.left.right = new TreeNode(1);
            root.right.left = new TreeNode(3);
            root.right.right = new TreeNode(-1);
            root.right.left.right = new TreeNode(6);
            root.right.right.right = new TreeNode(8);

            // Act
            int maxDepth = Playground.LeetCode.Trees.MaxDepth(root);

            // Assert
            Assert.That(maxDepth, Is.EqualTo(4));
        }

        //[0,2,4,1,null,3,-1,5,1,null,6,null,8]
    }
}
