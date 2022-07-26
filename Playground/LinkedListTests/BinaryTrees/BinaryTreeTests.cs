using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DataStructuresPlayground.Domains.BinaryTree;
using DataStructuresPlayground.Services.BinaryTree;

namespace DataStructuresTests.BinaryTrees
{
    [TestFixture]
    public class BinaryTreeTests
    {
        private BinaryTreeService<int> binaryTreeService { get; set; }
        private BinaryTree<int> binaryTree { get; set; }

        [SetUp]
        public void SetUpBinaryTreeTests()
        {
            binaryTreeService = new BinaryTreeService<int>();
            binaryTree = new BinaryTree<int>();
        }

        [Test]
        public void OnBinaryTreeAddTreeNode_ShouldAddRootNode()
        {
            // Arrange
            var newNode = new BinaryTreeNode<int>(10);

            // Act
            binaryTreeService.AddTreeNode(newNode, null, binaryTree);

            // Assert
            Assert.IsNotNull(binaryTree.Root);
        }

        [Test]
        public void OnBinaryTreeAddTreeNode_ShouldAddManyNodes()
        {
            // Arrange
            var newNode = new BinaryTreeNode<int>(10);
            var newNode2 = new BinaryTreeNode<int>(12);
            var newNode3 = new BinaryTreeNode<int>(8);
            var newNode4 = new BinaryTreeNode<int>(7);
            var newNode5 = new BinaryTreeNode<int>(20);
            var newNode6 = new BinaryTreeNode<int>(5);
            var newNode7 = new BinaryTreeNode<int>(3);
            var newNode8 = new BinaryTreeNode<int>(2);
            var newNode9 = new BinaryTreeNode<int>(15);
            var newNode10 = new BinaryTreeNode<int>(11);

            // Act
            binaryTreeService.AddTreeNode(newNode, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode2, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode3, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode4, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode5, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode6, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode7, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode8, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode9, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode10, null, binaryTree);

            // Assert
            Assert.IsNotNull(binaryTree.Root);
        }

        [Test]
        public void OnBinaryTreeAddTreeNode_OnGetTreeNode_ShouldMatchNodeValue()
        {
            // Arrange
            var newNode = new BinaryTreeNode<int>(10);
            var newNode2 = new BinaryTreeNode<int>(12);
            var newNode3 = new BinaryTreeNode<int>(8);
            var newNode4 = new BinaryTreeNode<int>(7);
            var newNode5 = new BinaryTreeNode<int>(20);
            var newNode6 = new BinaryTreeNode<int>(5);
            var newNode7 = new BinaryTreeNode<int>(3);
            var newNode8 = new BinaryTreeNode<int>(2);
            var newNode9 = new BinaryTreeNode<int>(15);
            var newNode10 = new BinaryTreeNode<int>(11);

            var valueToFind = 3;

            // Act
            binaryTreeService.AddTreeNode(newNode, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode2, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode3, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode4, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode5, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode6, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode7, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode8, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode9, null, binaryTree);
            binaryTreeService.AddTreeNode(newNode10, null, binaryTree);

            BinaryTreeNode<int> parent = null;
            BinaryTreeNode<int> nodeFound = binaryTreeService.GetTreeNode(valueToFind, out parent, binaryTree);

            // Assert
            Assert.AreEqual(nodeFound.Value, valueToFind);
            Assert.AreEqual(parent.Value, 5);
        }
    }
}
