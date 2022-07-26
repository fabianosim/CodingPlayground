using DataStructuresPlayground.Domains.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPlayground.Services.BinaryTree.Interfaces
{
    /// <summary>
    /// Defines methods to work with a Binary tree.
    /// </summary>
    public interface IBinaryTree<T>
    {
        /// <summary>
        /// Adds a node to the binary tree.
        /// </summary>
        /// <param name="treeNode">The node to be added.</param>
        /// <param name="currentNode">The current node in the search to see if the node can be added or not.</param>
        public void AddTreeNode(BinaryTreeNode<T> treeNode, BinaryTreeNode<T> currentNode, BinaryTree<T> tree);

        /// <summary>
        /// Removes a node from the tree.
        /// </summary>
        /// <param name="treeNode">The node to be removed.</param>
        /// <param name="tree">The tree.</param>
        public void RemoveTreeNode(BinaryTreeNode<T> treeNode, BinaryTree<T> tree);

        /// <summary>
        /// Get the first occurence of a value in the binary tree.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <param name="parent">The parent node.</param>
        /// <param name="tree">The tree.</param>
        /// <returns>The found node.</returns>
        public BinaryTreeNode<T> GetTreeNode(T value, out BinaryTreeNode<T> parent, BinaryTree<T> tree);

        /// <summary>
        /// Checks if a value is a node leaf.
        /// </summary>
        /// <param name="node">The tree node.</param>
        /// <returns>True if the value is a leaf. False otherwise.</returns>
        public bool IsLeaf(BinaryTreeNode<T> node);

        /// <summary>
        /// Gets the successor node for a specific binary tree.
        /// </summary>
        /// <param name="value">The value to have the successor of it found.</param>
        /// <param name="tree">The binary tree.</param>
        /// <returns>The successor node.</returns>
        public BinaryTreeNode<T> GetSuccessor(T value, BinaryTree<T> tree);
    }
}
