using DataStructuresPlayground.Domains.BinaryTree;
using DataStructuresPlayground.Services.BinaryTree.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPlayground.Services.BinaryTree
{
    public class BinaryTreeService<T> : IBinaryTree<T>
    {
        public void AddTreeNode(BinaryTreeNode<T> treeNode, BinaryTreeNode<T> currentNode, BinaryTree<T> tree)
        {
            if (tree.Root == null)
            {
                // Tree is empty, set it as root node of the tree.
                tree.Root = treeNode;
            }
            else
            {
                // If the current node is null, then we need to start from the root.
                if (currentNode == null) currentNode = tree.Root;

                // Go to the right if node is greater than currentNode
                var currentNodeVal = Convert.ToInt32(currentNode.Value);
                var treeNodeVal = Convert.ToInt32(treeNode.Value);
                var nodeComparison = treeNodeVal.CompareTo(currentNodeVal);

                if (nodeComparison >= 0)
                    if (currentNode.Right == null)
                        currentNode.Right = treeNode;
                    else
                        AddTreeNode(treeNode, currentNode.Right, tree);
                else
                    if (currentNode.Left == null)
                        currentNode.Left = treeNode;
                    else
                        AddTreeNode(treeNode, currentNode.Left, tree);
            }
        }

        public BinaryTreeNode<T> GetSuccessor(T value, BinaryTree<T> tree)
        {
            throw new NotImplementedException();
        }

        public BinaryTreeNode<T> GetTreeNode(T value, out BinaryTreeNode<T> parent, BinaryTree<T> tree)
        {
            // Start from root.
            var currentNode = tree.Root;
            var valueToCompare = Convert.ToInt32(value);
            parent = null;

            while (valueToCompare.CompareTo(currentNode.Value) != 0)
            {
                if (valueToCompare.CompareTo(currentNode.Value) < 0)
                {
                    parent = currentNode;
                    currentNode = currentNode.Left;
                }

                if (valueToCompare.CompareTo(currentNode.Value) > 0)
                {
                    parent = currentNode;
                    currentNode = currentNode.Right;
                }

            }

            return currentNode;
        }

        public bool IsLeaf(BinaryTreeNode<T> node)
        {
            return node.Left == null && node.Right == null;
        }

        public void RemoveTreeNode(BinaryTreeNode<T> treeNode, BinaryTree<T> tree)
        {
            throw new NotImplementedException();
        }
    }
}
