using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
