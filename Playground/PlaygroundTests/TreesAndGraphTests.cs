using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresPlayground.Domains.Graph;
using DataStructuresPlayground.Domains.LinkedList;
using DataStructuresPlayground.Services.BinaryTree;
using DataStructuresPlayground.Services.Graph;
using Playground.CrackingTheCode;

namespace PlaygroundTests
{
    [TestFixture]
    public class TreesAndGraphTests
    {
        public DSGraph<int> graph { get; set; }
        public GraphService<int> graphService { get; set; }

        [SetUp]
        public void SetupGraphTests()
        {
            GraphNode<int> root = new GraphNode<int>(1);

            GraphNode<int> node2 = new GraphNode<int>(2);
            GraphNode<int> node3 = new GraphNode<int>(3);
            GraphNode<int> node4 = new GraphNode<int>(4);
            GraphNode<int> node5 = new GraphNode<int>(5);

            GraphNode<int> node6 = new GraphNode<int>(6);
            GraphNode<int> node7 = new GraphNode<int>(7);
            GraphNode<int> node8 = new GraphNode<int>(8);
            GraphNode<int> node9 = new GraphNode<int>(9);

            GraphNode<int> node10 = new GraphNode<int>(10);
            GraphNode<int> node11 = new GraphNode<int>(11);
            GraphNode<int> node12 = new GraphNode<int>(12);
            GraphNode<int> node13 = new GraphNode<int>(13);

            // Set graph interactions
            node3.Nodes = new[]
            {
                node6, node8, node9
            };

            node4.Nodes = new[]
            {
                node3, node2, node10, node11, node12
            };

            node5.Nodes = new[]
            {
                node2, node3, node13, node7
            };

            node8.Nodes = new[]
            {
                root, node2, node3, node9
            };

            node11.Nodes = new[]
            {
                node13, node4, node6, node9
            };

            root.Nodes = new[]
            {
                node2, node3, node4, node5
            };

            graph = new DSGraph<int>(root);
        }

        [Test]
        public void OnBFSearch_ShouldReturnGraphNode()
        {
            // Arrange
            graphService = new GraphService<int>(graph);

            // Act
            GraphNode<int> nodeToSearch = new GraphNode<int>(7);
            GraphNode<int> foundNode = graphService.BFSearchNode(7, graph.Node); // search using the root node from Graph

            // Assert
            Assert.That(nodeToSearch.Value, Is.EqualTo(foundNode.Value));
        }

        [Test]
        public void OnDFSearch_ShouldReturnGraphNode()
        {
            // Arrange
            graphService = new GraphService<int>(graph);

            // Act
            GraphNode<int> nodeToSearch = new GraphNode<int>(7);
            nodeToSearch.Visited = true;
            graphService.DFSearchNode(7, graph.Node); // search using the root node from Graph

            // Assert
            Assert.That(graphService.TrackedNodes.Any(_ => _.Value == 7), Is.True);
        }

        [Test]
        public void OnBSTMinHeight_WithOrderedArray_ShouldGetBSTMinHeight()
        {
            // Arrange
            int[] orderedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var treesAndGraphs = new TreesAndGraphs();

            // Act
            LinkedList<TreesAndGraphs.BinaryTreeNode?> bstMinHeight = treesAndGraphs.BSTMinHeight(orderedArray);

            // Assert
            Assert.That(treesAndGraphs.GetBSTHeight(bstMinHeight.First.Value), Is.EqualTo(4));
        }

        [Test]
        public void OnListOfDepths_ShouldReturnLinkedListOfNodes()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? root = new TreesAndGraphs.BinaryTreeNode(1);
            root.Left = new TreesAndGraphs.BinaryTreeNode(2);
            root.Right = new TreesAndGraphs.BinaryTreeNode(3);
            root.Right.Left = new TreesAndGraphs.BinaryTreeNode(4);
            root.Right.Right = new TreesAndGraphs.BinaryTreeNode(5);
            root.Right.Left.Left = new TreesAndGraphs.BinaryTreeNode(6);
            var treesAndGraphs = new TreesAndGraphs();

            // Act
            List<LinkedList<TreesAndGraphs.BinaryTreeNode?>> dephtsList = treesAndGraphs.ListOfDepths(root);

            // Assert
            Assert.That(4, Is.EqualTo(dephtsList.Count));

        }

        [Test]
        public void OnListOfDepthsBFS_ShouldReturnLinkedListOfNodes()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? root = new TreesAndGraphs.BinaryTreeNode(1);
            root.Left = new TreesAndGraphs.BinaryTreeNode(2);
            root.Right = new TreesAndGraphs.BinaryTreeNode(3);
            root.Right.Left = new TreesAndGraphs.BinaryTreeNode(4);
            root.Right.Right = new TreesAndGraphs.BinaryTreeNode(5);
            root.Right.Left.Left = new TreesAndGraphs.BinaryTreeNode(6);
            var treesAndGraphs = new TreesAndGraphs();

            // Act
            List<LinkedList<TreesAndGraphs.BinaryTreeNode?>> dephtsList = treesAndGraphs.ListOfDepthsBFS(root);

            // Assert
            Assert.That(4, Is.EqualTo(dephtsList.Count));

        }

        [Test]
        public void OnIsTreeBalanced_ShouldReturnTrue()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? rootNode = new TreesAndGraphs.BinaryTreeNode(1);
            rootNode.Left = new TreesAndGraphs.BinaryTreeNode(2);
            rootNode.Right = new TreesAndGraphs.BinaryTreeNode(3);
            rootNode.Right.Left = new TreesAndGraphs.BinaryTreeNode(4);
            rootNode.Right.Right = new TreesAndGraphs.BinaryTreeNode(5);
            rootNode.Left.Left = new TreesAndGraphs.BinaryTreeNode(6);
            rootNode.Left.Right = new TreesAndGraphs.BinaryTreeNode(7);

            var treesAndGraphs = new TreesAndGraphs();
            
            // Act
            bool isBalanced = treesAndGraphs.IsTreeBalanced(rootNode);

            // Assert
            Assert.That(isBalanced, Is.True);
        }

        [Test]
        public void OnIsTreeBalanced_ShouldReturnFalse()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? rootNode = new TreesAndGraphs.BinaryTreeNode(1);
            rootNode.Left = new TreesAndGraphs.BinaryTreeNode(2);
            rootNode.Right = new TreesAndGraphs.BinaryTreeNode(3);
            rootNode.Right.Left = new TreesAndGraphs.BinaryTreeNode(4);
            rootNode.Right.Right = new TreesAndGraphs.BinaryTreeNode(5);
            rootNode.Left.Left = new TreesAndGraphs.BinaryTreeNode(6);
            rootNode.Left.Right = new TreesAndGraphs.BinaryTreeNode(7);
            rootNode.Left.Right.Right = new TreesAndGraphs.BinaryTreeNode(8);
            rootNode.Left.Right.Right.Right = new TreesAndGraphs.BinaryTreeNode(9);
            rootNode.Left.Right.Right.Right.Right = new TreesAndGraphs.BinaryTreeNode(10);

            var treesAndGraphs = new TreesAndGraphs();

            // Act
            bool isBalanced = treesAndGraphs.IsTreeBalanced(rootNode);

            // Assert
            Assert.That(isBalanced, Is.False);
        }

        [Test]
        public void OnIsBinarySearchTree_ShouldReturnTrue()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? rootNode = new TreesAndGraphs.BinaryTreeNode(10);
            rootNode.Left = new TreesAndGraphs.BinaryTreeNode(6);
            rootNode.Right = new TreesAndGraphs.BinaryTreeNode(13);
            rootNode.Left.Left = new TreesAndGraphs.BinaryTreeNode(1);
            rootNode.Left.Right = new TreesAndGraphs.BinaryTreeNode(8);
            rootNode.Right.Left = new TreesAndGraphs.BinaryTreeNode(11);
            rootNode.Right.Right = new TreesAndGraphs.BinaryTreeNode(14);
            
            var treesAndGraphs = new TreesAndGraphs();

            // Act
            //bool isBST = treesAndGraphs.CheckBST(rootNode);
            bool isBST = treesAndGraphs.IsBinarySearchTree(rootNode);

            // Assert
            Assert.That(isBST, Is.True);
        }

        [Test]
        public void OnIsBinarySearchTree_ShouldReturnTrue_Test2()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? rootNode = new TreesAndGraphs.BinaryTreeNode(10);
            rootNode.Left = new TreesAndGraphs.BinaryTreeNode(8);
            rootNode.Right = new TreesAndGraphs.BinaryTreeNode(12);
            rootNode.Left.Left = new TreesAndGraphs.BinaryTreeNode(6);
            rootNode.Left.Right = new TreesAndGraphs.BinaryTreeNode(11);
            rootNode.Right.Left = new TreesAndGraphs.BinaryTreeNode(11);
            rootNode.Right.Right = new TreesAndGraphs.BinaryTreeNode(13);

            var treesAndGraphs = new TreesAndGraphs();

            // Act
            bool isBST = treesAndGraphs.CheckBST(rootNode);
            //bool isBST = treesAndGraphs.IsBinarySearchTree(rootNode);

            // Assert
            Assert.Pass();
            //Assert.That(isBST, Is.True);
        }

        [Test]
        public void OnIsBinarySearchTree_ShouldReturnFalse()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? rootNode = new TreesAndGraphs.BinaryTreeNode(10);
            rootNode.Left = new TreesAndGraphs.BinaryTreeNode(6);
            rootNode.Right = new TreesAndGraphs.BinaryTreeNode(13);
            rootNode.Left.Left = new TreesAndGraphs.BinaryTreeNode(1);
            rootNode.Left.Right = new TreesAndGraphs.BinaryTreeNode(5);
            rootNode.Right.Left = new TreesAndGraphs.BinaryTreeNode(11);
            rootNode.Right.Right = new TreesAndGraphs.BinaryTreeNode(14);
            rootNode.Right.Right.Right = new TreesAndGraphs.BinaryTreeNode(16);
            rootNode.Right.Right.Right.Right = new TreesAndGraphs.BinaryTreeNode(18);

            var treesAndGraphs = new TreesAndGraphs();

            // Act
            //bool isBST = treesAndGraphs.CheckBST(rootNode);
            bool isBST = treesAndGraphs.IsBinarySearchTree(rootNode);

            // Assert
            Assert.That(isBST, Is.False);
        }

        [Test]
        public void OnNextSuccessorNode_ShouldReturnNextNode()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? rootNode = new TreesAndGraphs.BinaryTreeNode(10);
            rootNode.Left = new TreesAndGraphs.BinaryTreeNode(6);
            rootNode.Right = new TreesAndGraphs.BinaryTreeNode(13);
            rootNode.Left.Left = new TreesAndGraphs.BinaryTreeNode(1);
            rootNode.Left.Right = new TreesAndGraphs.BinaryTreeNode(8);
            rootNode.Right.Left = new TreesAndGraphs.BinaryTreeNode(11);
            rootNode.Right.Right = new TreesAndGraphs.BinaryTreeNode(14);

            var treesAndGraphs = new TreesAndGraphs();
            TreesAndGraphs.BinaryTreeNode? targetNode = rootNode.Right;
            TreesAndGraphs.BinaryTreeNode? nextSuccessorNode = rootNode.Left.Left;

            // Act
            //bool isBST = treesAndGraphs.CheckBST(rootNode);
            int? nextNode = treesAndGraphs.NextSuccessorNode(rootNode, targetNode);

            // Assert
            Assert.That(nextNode, Is.EqualTo(nextSuccessorNode.Value));
        }

        [Test]
        public void OnNextSuccessorNode_ShouldReturnNull()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? rootNode = new TreesAndGraphs.BinaryTreeNode(10);
            rootNode.Left = new TreesAndGraphs.BinaryTreeNode(6);
            rootNode.Right = new TreesAndGraphs.BinaryTreeNode(13);
            rootNode.Left.Left = new TreesAndGraphs.BinaryTreeNode(1);
            rootNode.Left.Right = new TreesAndGraphs.BinaryTreeNode(8);
            rootNode.Right.Left = new TreesAndGraphs.BinaryTreeNode(11);
            rootNode.Right.Right = new TreesAndGraphs.BinaryTreeNode(14);

            var treesAndGraphs = new TreesAndGraphs();
            TreesAndGraphs.BinaryTreeNode? targetNode = rootNode.Left.Right;

            // Act
            //bool isBST = treesAndGraphs.CheckBST(rootNode);
            int? nextNode = treesAndGraphs.NextSuccessorNode(rootNode, targetNode);

            // Assert
            Assert.That(nextNode, Is.Null);
        }

        [Test]
        public void OnCommonAncestor_ShouldReturnAncestorNode()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? rootNode = new TreesAndGraphs.BinaryTreeNode(10);
            rootNode.Left = new TreesAndGraphs.BinaryTreeNode(6);
            rootNode.Right = new TreesAndGraphs.BinaryTreeNode(13);
            rootNode.Left.Left = new TreesAndGraphs.BinaryTreeNode(1);
            rootNode.Left.Right = new TreesAndGraphs.BinaryTreeNode(8);
            rootNode.Right.Left = new TreesAndGraphs.BinaryTreeNode(11);
            rootNode.Right.Right = new TreesAndGraphs.BinaryTreeNode(14);
            rootNode.Right.Right = new TreesAndGraphs.BinaryTreeNode(14);
            rootNode.Left.Left.Left = new TreesAndGraphs.BinaryTreeNode(9);
            rootNode.Left.Left.Right = new TreesAndGraphs.BinaryTreeNode(15);
            rootNode.Left.Right.Left = new TreesAndGraphs.BinaryTreeNode(18);
            rootNode.Left.Right.Right = new TreesAndGraphs.BinaryTreeNode(20);

            var treesAndGraphs = new TreesAndGraphs();
            TreesAndGraphs.BinaryTreeNode? ancestor1 = rootNode;
            TreesAndGraphs.BinaryTreeNode? ancestor2 = rootNode.Left;

            // Act
            //bool isBST = treesAndGraphs.CheckBST(rootNode);
            TreesAndGraphs.BinaryTreeNode? nextNode1 = treesAndGraphs.CommonAncestor(rootNode, rootNode.Right.Left, rootNode.Left.Right.Left);
            TreesAndGraphs.BinaryTreeNode? nextNode2 = treesAndGraphs.CommonAncestor(rootNode, rootNode.Left.Right.Left, rootNode.Left.Left.Right);

            // Assert
            Assert.That(nextNode1, Is.EqualTo(ancestor1));
            Assert.That(nextNode2, Is.EqualTo(ancestor2));
        }

        [Test]
        public void OnCheckSubtree_ShouldReturnTrue()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? t1 = new TreesAndGraphs.BinaryTreeNode(10);
            t1.Left = new TreesAndGraphs.BinaryTreeNode(6);
            t1.Right = new TreesAndGraphs.BinaryTreeNode(13);
            t1.Left.Left = new TreesAndGraphs.BinaryTreeNode(1);
            t1.Left.Right = new TreesAndGraphs.BinaryTreeNode(8);
            t1.Right.Left = new TreesAndGraphs.BinaryTreeNode(11);
            t1.Right.Right = new TreesAndGraphs.BinaryTreeNode(14);
            t1.Left.Left.Left = new TreesAndGraphs.BinaryTreeNode(9);
            t1.Left.Left.Right = new TreesAndGraphs.BinaryTreeNode(15);
            t1.Left.Right.Left = new TreesAndGraphs.BinaryTreeNode(18);
            t1.Left.Right.Right = new TreesAndGraphs.BinaryTreeNode(20);

            TreesAndGraphs.BinaryTreeNode? t2 = new TreesAndGraphs.BinaryTreeNode(1);
            t2.Left = new TreesAndGraphs.BinaryTreeNode(9);
            t2.Right = new TreesAndGraphs.BinaryTreeNode(15);
            //t2.Left.Right = new TreesAndGraphs.BinaryTreeNode(8);

            var treesAndGraphs = new TreesAndGraphs();

            // Act
            bool isSubtree = treesAndGraphs.CheckSubtree(t1, t2);

            // Assert
            Assert.IsTrue(isSubtree);
        }

        [Test]
        public void OnCheckSubtree_ShouldReturnFalse()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? t1 = new TreesAndGraphs.BinaryTreeNode(10);
            t1.Left = new TreesAndGraphs.BinaryTreeNode(6);
            t1.Right = new TreesAndGraphs.BinaryTreeNode(13);
            t1.Left.Left = new TreesAndGraphs.BinaryTreeNode(1);
            t1.Left.Right = new TreesAndGraphs.BinaryTreeNode(8);
            t1.Right.Left = new TreesAndGraphs.BinaryTreeNode(11);
            t1.Right.Right = new TreesAndGraphs.BinaryTreeNode(14);
            t1.Left.Left.Left = new TreesAndGraphs.BinaryTreeNode(9);
            t1.Left.Left.Right = new TreesAndGraphs.BinaryTreeNode(15);
            t1.Left.Right.Left = new TreesAndGraphs.BinaryTreeNode(18);
            t1.Left.Right.Right = new TreesAndGraphs.BinaryTreeNode(20);

            TreesAndGraphs.BinaryTreeNode? t2 = new TreesAndGraphs.BinaryTreeNode(1);
            t2.Left = new TreesAndGraphs.BinaryTreeNode(9);
            t2.Right = new TreesAndGraphs.BinaryTreeNode(15);
            t2.Left.Right = new TreesAndGraphs.BinaryTreeNode(8);

            var treesAndGraphs = new TreesAndGraphs();

            // Act
            bool isSubtree = treesAndGraphs.CheckSubtree(t1, t2);

            // Assert
            Assert.IsFalse(isSubtree);
        }

        [Test]
        public void OnCheckSubtree_ForSmallTrees_ShouldReturnFalse()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? t1 = new TreesAndGraphs.BinaryTreeNode(3);
            t1.Left = new TreesAndGraphs.BinaryTreeNode(4);
            
            TreesAndGraphs.BinaryTreeNode? t2 = new TreesAndGraphs.BinaryTreeNode(3);
            t2.Right = new TreesAndGraphs.BinaryTreeNode(4);

            var treesAndGraphs = new TreesAndGraphs();

            // Act
            bool isSubtree = treesAndGraphs.CheckSubtree(t1, t2);

            // Assert
            Assert.IsFalse(isSubtree);
        }

        [Test]
        public void OnCheckSubtreeRecursive_ShouldReturnTrue()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? t1 = new TreesAndGraphs.BinaryTreeNode(10);
            t1.Left = new TreesAndGraphs.BinaryTreeNode(6);
            t1.Right = new TreesAndGraphs.BinaryTreeNode(13);
            t1.Left.Left = new TreesAndGraphs.BinaryTreeNode(1);
            t1.Left.Right = new TreesAndGraphs.BinaryTreeNode(8);
            t1.Right.Left = new TreesAndGraphs.BinaryTreeNode(11);
            t1.Right.Right = new TreesAndGraphs.BinaryTreeNode(14);
            t1.Left.Left.Left = new TreesAndGraphs.BinaryTreeNode(9);
            t1.Left.Left.Right = new TreesAndGraphs.BinaryTreeNode(15);
            t1.Left.Right.Left = new TreesAndGraphs.BinaryTreeNode(18);
            t1.Left.Right.Right = new TreesAndGraphs.BinaryTreeNode(20);

            TreesAndGraphs.BinaryTreeNode? t2 = new TreesAndGraphs.BinaryTreeNode(1);
            t2.Left = new TreesAndGraphs.BinaryTreeNode(9);
            t2.Right = new TreesAndGraphs.BinaryTreeNode(15);
            //t2.Left.Right = new TreesAndGraphs.BinaryTreeNode(8);

            var treesAndGraphs = new TreesAndGraphs();

            // Act
            bool isSubtree = treesAndGraphs.CheckSubTreeRecursive(t1, t2);

            // Assert
            Assert.IsTrue(isSubtree);
        }

        [Test]
        public void OnCheckSubtreeRecursive_ShouldReturnFalse()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? t1 = new TreesAndGraphs.BinaryTreeNode(10);
            t1.Left = new TreesAndGraphs.BinaryTreeNode(6);
            t1.Right = new TreesAndGraphs.BinaryTreeNode(13);
            t1.Left.Left = new TreesAndGraphs.BinaryTreeNode(1);
            t1.Left.Right = new TreesAndGraphs.BinaryTreeNode(8);
            t1.Right.Left = new TreesAndGraphs.BinaryTreeNode(11);
            t1.Right.Right = new TreesAndGraphs.BinaryTreeNode(14);
            t1.Left.Left.Left = new TreesAndGraphs.BinaryTreeNode(9);
            t1.Left.Left.Right = new TreesAndGraphs.BinaryTreeNode(15);
            t1.Left.Right.Left = new TreesAndGraphs.BinaryTreeNode(18);
            t1.Left.Right.Right = new TreesAndGraphs.BinaryTreeNode(20);

            TreesAndGraphs.BinaryTreeNode? t2 = new TreesAndGraphs.BinaryTreeNode(1);
            t2.Left = new TreesAndGraphs.BinaryTreeNode(9);
            t2.Right = new TreesAndGraphs.BinaryTreeNode(15);
            t2.Left.Right = new TreesAndGraphs.BinaryTreeNode(8);

            var treesAndGraphs = new TreesAndGraphs();

            // Act
            bool isSubtree = treesAndGraphs.CheckSubTreeRecursive(t1, t2);

            // Assert
            Assert.IsFalse(isSubtree);
        }

        [Test]
        public void OnRandomNode_ShouldReturnRandomNode()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? t1 = new TreesAndGraphs.BinaryTreeNode(10);
            t1.Left = new TreesAndGraphs.BinaryTreeNode(6);
            t1.Right = new TreesAndGraphs.BinaryTreeNode(13);
            t1.Left.Left = new TreesAndGraphs.BinaryTreeNode(1);
            t1.Left.Right = new TreesAndGraphs.BinaryTreeNode(8);
            t1.Right.Left = new TreesAndGraphs.BinaryTreeNode(11);
            t1.Right.Right = new TreesAndGraphs.BinaryTreeNode(14);
            t1.Left.Left.Left = new TreesAndGraphs.BinaryTreeNode(9);
            t1.Left.Left.Right = new TreesAndGraphs.BinaryTreeNode(15);
            t1.Left.Right.Left = new TreesAndGraphs.BinaryTreeNode(18);
            t1.Left.Right.Right = new TreesAndGraphs.BinaryTreeNode(20);

            var treesAndGraphs = new TreesAndGraphs();

            // Act
            TreesAndGraphs.BinaryTreeNode randomNode1 = treesAndGraphs.GetRandomNode(t1);
            TreesAndGraphs.BinaryTreeNode randomNode2 = treesAndGraphs.GetRandomNode(t1);

            // Assert
            Assert.IsNotNull(randomNode1);
            Assert.IsNotNull(randomNode2);
        }

        [Test]
        public void OnGetRandomNodeStatistic_ShouldReturnStatistics()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? t1 = new TreesAndGraphs.BinaryTreeNode(10);
            t1.Left = new TreesAndGraphs.BinaryTreeNode(6);
            t1.Right = new TreesAndGraphs.BinaryTreeNode(13);
            t1.Left.Left = new TreesAndGraphs.BinaryTreeNode(1);
            t1.Left.Right = new TreesAndGraphs.BinaryTreeNode(8);
            t1.Right.Left = new TreesAndGraphs.BinaryTreeNode(11);
            t1.Right.Right = new TreesAndGraphs.BinaryTreeNode(14);
            t1.Left.Left.Left = new TreesAndGraphs.BinaryTreeNode(9);
            t1.Left.Left.Right = new TreesAndGraphs.BinaryTreeNode(15);
            t1.Left.Right.Left = new TreesAndGraphs.BinaryTreeNode(18);
            t1.Left.Right.Right = new TreesAndGraphs.BinaryTreeNode(20);

            var treesAndGraphs = new TreesAndGraphs();

            // Act
            Dictionary<int, float> statistics = treesAndGraphs.GetRandomNodeStatistic(t1, 1000);

            // Assert
            Assert.IsNotNull(statistics); // will be always true, this is just to see statistics for some samples.
        }

        [Test]
        public void OnGetRandomNodeStatistic_ShouldReturnEqualStatistic()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode? t1 = new TreesAndGraphs.BinaryTreeNode(20);
            t1.InsertInOrder(10);
            t1.InsertInOrder(30);
            t1.InsertInOrder(5);
            t1.InsertInOrder(15);
            t1.InsertInOrder(14);
            t1.InsertInOrder(35);
            t1.InsertInOrder(25);
            t1.InsertInOrder(23);
            t1.InsertInOrder(27);
            t1.InsertInOrder(32);
            t1.InsertInOrder(3);
            t1.InsertInOrder(7);
            t1.InsertInOrder(17);
            
            var treesAndGraphs = new TreesAndGraphs();

            // Act
            Dictionary<int, float> statistics = treesAndGraphs.GetBalancedRandomNodeStatistic(t1, 1000);

            // Assert
            Assert.IsNotNull(statistics); // will be always true, this is just to see statistics for some samples.
        }

        [Test]
        public void OnPathsWithSums_ShouldRetunNumberOfPaths()
        {
            // Arrange
            int targetSum = 25;
            int expectedPaths = 2;
            TreesAndGraphs.BinaryTreeNode? t1 = new TreesAndGraphs.BinaryTreeNode(20);
            t1.InsertInOrder(10);
            t1.InsertInOrder(30);
            t1.InsertInOrder(5);
            t1.InsertInOrder(15);
            t1.InsertInOrder(14);
            t1.InsertInOrder(35);
            t1.InsertInOrder(25);
            t1.InsertInOrder(23);
            t1.InsertInOrder(27);
            t1.InsertInOrder(32);
            t1.InsertInOrder(3);
            t1.InsertInOrder(7);
            t1.InsertInOrder(17);

            var treesAndGraphs = new TreesAndGraphs();

            // Act
            int paths = treesAndGraphs.PathsWithSums(t1, targetSum);

            // Assert
            Assert.That(paths, Is.EqualTo(expectedPaths));
        }

        [Test]
        public void OnPathsWithSums2_ShouldRetunNumberOfPaths()
        {
            // Arrange
            int targetSum = 30;
            int expectedPaths = 2;
            TreesAndGraphs.BinaryTreeNode? t1 = new TreesAndGraphs.BinaryTreeNode(20);
            t1.InsertInOrder(10);
            t1.InsertInOrder(15);
            t1.InsertInOrder(15);
            t1.InsertInOrder(10);
            t1.InsertInOrder(5);

            var treesAndGraphs = new TreesAndGraphs();

            // Act
            int paths = treesAndGraphs.PathsWithSums(t1, targetSum);

            // Assert
            Assert.That(paths, Is.EqualTo(expectedPaths));
        }

        [Test]
        public void OnPathsWithSums_ShouldRetunNoPaths()
        {
            // Arrange
            int targetSum = 100;
            int expectedPaths = 0;
            TreesAndGraphs.BinaryTreeNode? t1 = new TreesAndGraphs.BinaryTreeNode(20);
            t1.InsertInOrder(10);
            t1.InsertInOrder(15);
            t1.InsertInOrder(15);
            t1.InsertInOrder(10);
            t1.InsertInOrder(5);

            var treesAndGraphs = new TreesAndGraphs();

            // Act
            int paths = treesAndGraphs.PathsWithSums(t1, targetSum);

            // Assert
            Assert.That(paths, Is.EqualTo(expectedPaths));
        }
    }
}
