using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresPlayground.Domains.Graph;
using DataStructuresPlayground.Domains.LinkedList;
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
            LinkedList<TreesAndGraphs.BinaryTreeNode> bstMinHeight = treesAndGraphs.BSTMinHeight(orderedArray);

            // Assert
            Assert.That(treesAndGraphs.GetBSTHeight(bstMinHeight.First.Value), Is.EqualTo(4));
        }

        [Test]
        public void OnListOfDepths_ShouldReturnLinkedListOfNodes()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode root = new TreesAndGraphs.BinaryTreeNode(1);
            root.Left = new TreesAndGraphs.BinaryTreeNode(2);
            root.Right = new TreesAndGraphs.BinaryTreeNode(3);
            root.Right.Left = new TreesAndGraphs.BinaryTreeNode(4);
            root.Right.Right = new TreesAndGraphs.BinaryTreeNode(5);
            root.Right.Left.Left = new TreesAndGraphs.BinaryTreeNode(6);
            var treesAndGraphs = new TreesAndGraphs();

            // Act
            List<LinkedList<TreesAndGraphs.BinaryTreeNode>> dephtsList = treesAndGraphs.ListOfDepths(root);

            // Assert
            Assert.That(4, Is.EqualTo(dephtsList.Count));

        }

        [Test]
        public void OnListOfDepthsBFS_ShouldReturnLinkedListOfNodes()
        {
            // Arrange
            TreesAndGraphs.BinaryTreeNode root = new TreesAndGraphs.BinaryTreeNode(1);
            root.Left = new TreesAndGraphs.BinaryTreeNode(2);
            root.Right = new TreesAndGraphs.BinaryTreeNode(3);
            root.Right.Left = new TreesAndGraphs.BinaryTreeNode(4);
            root.Right.Right = new TreesAndGraphs.BinaryTreeNode(5);
            root.Right.Left.Left = new TreesAndGraphs.BinaryTreeNode(6);
            var treesAndGraphs = new TreesAndGraphs();

            // Act
            List<LinkedList<TreesAndGraphs.BinaryTreeNode>> dephtsList = treesAndGraphs.ListOfDepthsBFS(root);

            // Assert
            Assert.That(4, Is.EqualTo(dephtsList.Count));

        }
    }
}
