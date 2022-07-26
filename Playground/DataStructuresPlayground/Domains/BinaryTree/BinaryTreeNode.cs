using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPlayground.Domains.BinaryTree
{
    public class BinaryTreeNode<T> : IComparable<int>
    {
        #region Fields and Properties

        /// <summary>
        /// The node value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The left node.
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }

        /// <summary>
        /// The right node.
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }

        #endregion

        #region Constructors

        public BinaryTreeNode(T value) 
        { 
            Value = value;
        }

        /// <summary>
        /// Compares Value with other.
        /// </summary>
        /// <param name="other">The value to be compared.</param>
        /// <returns>Same to CompareTo logic from C# language.</returns>
        /// <remarks>Only works with <see cref="int"/> type.</remarks>
        public int CompareTo(int other)
        {
            // Convert Value to int for comparison
            int instanceValue = Convert.ToInt32(Value);

            return instanceValue.CompareTo(other);
        }

        #endregion
    }
}
