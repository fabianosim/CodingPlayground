using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPlayground.Domains.BinaryTree
{
    public class BinaryTree<T>
    {
        #region Constructors

        public BinaryTree() { }

        /// <summary>
        /// Initializes the binary tree with the root node.
        /// </summary>
        /// <param name="rootNode"></param>
        public BinaryTree(BinaryTreeNode<T> rootNode) 
        {
            Root = rootNode;
        }

        #endregion

        #region Fields and Properties
        
        /// <summary>
        /// The root node. Every binary tree starts with the root. 
        /// </summary>
        public BinaryTreeNode<T>? Root { get; set; }
        
        #endregion

    }
}
