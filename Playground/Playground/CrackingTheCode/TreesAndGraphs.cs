using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresPlayground.Domains.BinaryTree;

namespace Playground.CrackingTheCode
{
    /// <summary>
    /// Chapter 4 - Interview Questions: Trees and Graphs
    /// </summary>
    public class TreesAndGraphs
    {
        /**
	    Given a sorted (increasing order) array with unique integer elements, write an algorithm to create a binary search tree with minimal height

	    Let’s suppose the following sorted increasing array: 
	    [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

	    A binary search tree with minimal height is a tree containing all leaf nodes in the same level.
	    In order to be a binary search tree, the tree must contain the smallest elements on the left, the highest elements to the right and the root node is the smallest one. It should be a complete and balanced binary tree.

	    Questions: 
        Should I validate if the array is unordered? 
        Should I order the array if it is unordered? 
	        Such algorithm can be:
        */
        
        public class BinaryTreeNode
        {
            // Fields and Properties
            public int Value { get; set; }
            public BinaryTreeNode Left { get; set; }
            public BinaryTreeNode Right { get; set; }

            // Methods
            public BinaryTreeNode(int value)
            {
                Value = value;
            }
        }

        /// <summary>
        /// Receives an ordered int array and populates a binary search tree
        /// Time complexity: O(N), where N is the array count
        /// </summary>
        /// <param name="orderedArray"></param>
        /// <param name="treeHeight"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /*public LinkedList<BinaryTreeNode> BSTMinHeight(int[] orderedArray)
        {
            var minHeightTree = new LinkedList<BinaryTreeNode>();

            if (orderedArray.Length.Equals(0))
                throw new Exception("orderedArray is empty.");

            var currentNode = new BinaryTreeNode(orderedArray[0]);
            var currentValue = orderedArray[0];
            minHeightTree.AddFirst(currentNode);

            if (orderedArray.Length.Equals(1))
                return minHeightTree;

            // Given that the array is increasingly ordered
            for (int i = 1; i < orderedArray.Length; i++)
            {
                var nodeToAppend = new BinaryTreeNode(orderedArray[i]);

                if (orderedArray[i] <= currentNode.Value)
                {
                    // node must go to the left
                    if (currentNode.Left == null)
                        currentNode.Left = nodeToAppend;
                    else
                    {
                        currentNode = currentNode.Left;
                    }
                        
                }
                else // otherwise, go to the right since it is greater
                {
                    // node must go to the left
                    if (currentNode.Right == null)
                        currentNode.Right = nodeToAppend;
                    else
                    {
                        currentNode = currentNode.Right;
                    }
                }
                    
                if (currentNode.Left != null && currentNode.Right != null)
                {
                    // Adds the node to the minHeightTree. Only adds a node if both left and right are filled.
                    minHeightTree.AddFirst(nodeToAppend);

                    // Updates the reference to the current node and value
                    currentNode = nodeToAppend;
                }
            }

            return minHeightTree;
        }*/

        public LinkedList<BinaryTreeNode> BSTMinHeight(int[] orderedArray)
        {
            var list = new LinkedList<BinaryTreeNode>();
            list.AddFirst(BSTMinNode(orderedArray, 0, orderedArray.Length - 1));

            return list;
        }

        /// <summary>
        /// Recursively creates a BST min height node.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public BinaryTreeNode BSTMinNode(int[] numbers, int start, int end)
        {
            if (end < start)
                return null;

            int mid = (start + end) / 2;
            BinaryTreeNode node = new BinaryTreeNode(numbers[mid]);
            node.Left = BSTMinNode(numbers, start, mid - 1);
            node.Right = BSTMinNode(numbers, mid + 1, end);

            return node;
        }

        /// <summary>
        /// Gets the height of a BST tree
        /// </summary>
        public int GetBSTHeight(BinaryTreeNode treeNode)
        {
            if (treeNode == null) return 0;

            int leftHeight = GetBSTHeight(treeNode.Left);
            int rightHeight = GetBSTHeight(treeNode.Right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public List<LinkedList<BinaryTreeNode>> ListOfDepths(BinaryTreeNode root)
        {
            List<LinkedList<BinaryTreeNode>> depthsList = new List<LinkedList<BinaryTreeNode>>();
            CreateLevelLinkedList(root, depthsList, 0);
            return depthsList;
        }

        /// <summary>
        /// Exercise 4.3 - List of Depths - Depth-first search
        /// </summary>
        /// <param name="root"></param>
        /// <param name="dephtsList"></param>
        /// <param name="level"></param>
        public void CreateLevelLinkedList(BinaryTreeNode root, List<LinkedList<BinaryTreeNode>> dephtsList, int level)
        {
            if (root == null) return;

            LinkedList<BinaryTreeNode> list = null;

            if (dephtsList.Count == level)
            {
                // Levels are always traversed in order. So, if this is the first time we've
                // visited level i, we must have seen levels 0 through i -1.
                // We can therefore safely add the level at the end.
                list = new LinkedList<BinaryTreeNode>();
                dephtsList.Add(list);
            }
            else
            {
                list = dephtsList[level];
            }

            var nodeToAdd = new LinkedListNode<BinaryTreeNode>(root);
            list.AddFirst(nodeToAdd);
            CreateLevelLinkedList(root.Left, dephtsList, level + 1);
            CreateLevelLinkedList(root.Right, dephtsList, level + 1);
        }

        /// <summary>
        /// Exercise 4.3 - List of Depths - Breadth-first search
        /// </summary>
        public List<LinkedList<BinaryTreeNode>> ListOfDepthsBFS(BinaryTreeNode root)
        {
            List<LinkedList<BinaryTreeNode>> dephtsList = new List<LinkedList<BinaryTreeNode>>();
            
            // Visit the root
            LinkedList<BinaryTreeNode> current = new LinkedList<BinaryTreeNode>();

            if (root != null)
            {
                current.AddFirst(root);
            }

            while (current.Count > 0)
            {
                dephtsList.Add(current); // add the previous level
                LinkedList<BinaryTreeNode> parents = current; // Go to next level
                current = new LinkedList<BinaryTreeNode>();

                foreach (var parent in parents)
                {
                    // Visit the children
                    if (parent.Left != null)
                        current.AddFirst(parent.Left);

                    if (parent.Right != null)
                        current.AddFirst(parent.Right);
                }
            }

            return dephtsList;
        }

        /// <summary>
        /// Exercise 4.4
        /// Time Complexity: O(n)
        /// In order to check if tree is balanced or not, we need to check both left and right nodes subtrees and see if the difference in heights is greater than 1.
        /// Traverse the nodes using a breadth-first search algorithm, so we can pass through all sub nodes first
        /// For each subnode, we will get the height of the tree, considering the subnode as the root.
        /// if Math.Abs(left height - right height) is more than 1, then tree is unbalanced.
        /// otherwise, tree is balanced
        /// Write a method to find the height of a tree given a root node.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsTreeBalanced(BinaryTreeNode root)
        {
            // Traverse the tree and check both left and right nodes.
            Queue<BinaryTreeNode> treeNodes = new Queue<BinaryTreeNode>();
            treeNodes.Enqueue(root);

            while (treeNodes.Count > 0)
            {
                BinaryTreeNode currentNode = treeNodes.Dequeue();
                int leftHeight = 0;
                int rightHeight = 0;

                if (currentNode.Left != null)
                {
                    leftHeight = GetTreeHeight(currentNode.Left);
                    treeNodes.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    rightHeight = GetTreeHeight(currentNode.Right);
                    treeNodes.Enqueue(currentNode.Right);
                }

                if (Math.Abs(leftHeight - rightHeight) > 1)
                    return false;
            }

            return true;
        }

        public int GetTreeHeight(BinaryTreeNode treeNode)
        {
            if (treeNode == null)
            {
                return -1;
            }

            int leftHeight = GetTreeHeight(treeNode.Left);
            int rightHeight = GetTreeHeight(treeNode.Right);

            if (leftHeight > rightHeight)
                return leftHeight + 1;
            else
                return rightHeight + 1;
        }

        /// <summary>
        /// Exercise 4.5 - Trees and Graphs
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBinarySearchTree(BinaryTreeNode root)
        {
            if (root == null) return true;

            if (
                (root.Left != null && root.Value.CompareTo(root.Left.Value) < 0) ||
                (root.Right != null && root.Value.CompareTo(root.Right.Value) > 0) ||
                ((root.Left != null && root.Right != null) && root.Left.Value.CompareTo(root.Right.Value) > 0)
            )
                return false;
            
            return IsBinarySearchTree(root.Left) && IsBinarySearchTree(root.Right);
        }

        public bool CheckBST(BinaryTreeNode root)
        {
            return CheckBST(root, null, null);
        }

        public bool CheckBST(BinaryTreeNode root, int? min, int? max)
        {
            if (root == null) return true;

            if ((min != null && root.Value <= min) || (max != null && root.Value > max))
                return false;

            if (!CheckBST(root.Left, min, root.Value) || !CheckBST(root.Right, root.Value, max))
                return false;

            return true;
        }

        /// <summary>
        /// Exercise 4.6
        /// Find the successor node
        /// Time Complexity: O(log N) to traverse the nodes
        /// Space Complexity: O(N) as I created a list with all nodes and levels
        /// </summary>
        /// <remarks>
        ///     **** My understanding of this problem was not correct. So, my implementation works but it is different.
        /// </remarks>
        /// <param name="root"></param>
        /// <param name="node"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public int? NextSuccessorNode(BinaryTreeNode root, BinaryTreeNode node)
        {
            List<KeyValuePair<int, int>> nodesByLevel = new List<KeyValuePair<int, int>>();

            // Root starts at level 1
            MapNodesLevel(root, nodesByLevel, 1);

            // Select the node  and get the next level
            return GetNextSuccessor(nodesByLevel, node.Value);
        }

        public void MapNodesLevel(BinaryTreeNode root, List<KeyValuePair<int, int>> nodesByLevel, int level)
        {
            // means I reached the end
            if (root == null)
                return;

            // Add the node and the value to the list
            nodesByLevel.Add(new KeyValuePair<int, int>(level, root.Value));

            // Store the next level
            MapNodesLevel(root.Left, nodesByLevel, level + 1);
            MapNodesLevel(root.Right, nodesByLevel, level + 1);
        }

        public int? GetNextSuccessor(List<KeyValuePair<int, int>> nodesByLevel, int target)
        {
            var currentNodeList = nodesByLevel.Where(_ => _.Value.Equals(target)).OrderBy(_ => _.Value);
            
            if (!currentNodeList.Any()) 
                return null;

            var nextNode = nodesByLevel.Where(_ => _.Key.Equals(currentNodeList.First().Key + 1));

            return nextNode.Any() ? nextNode.First().Value : null;
        }
    }
}
