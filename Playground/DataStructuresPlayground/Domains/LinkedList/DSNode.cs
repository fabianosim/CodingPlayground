using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPlayground.Domains.LinkedList
{
    /// <summary>
    /// Represents a node of the Linked List.
    /// </summary>
    public class DSNode<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Constructor that sets the value to the node directly.
        /// </summary>
        /// <param name="value"></param>
        public DSNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// The value of a node.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        ///     The reference to the next node in the list's chain.
        /// </summary>
        /// <remarks>
        ///     Reference to the next item is not required.
        /// </remarks>
        public DSNode<T> NextNode { get; set; }

        /// <summary>
        ///     The reference to the previous node in the list's chain.
        /// </summary>
        /// <remarks>
        ///     Reference to the previous item is not required.
        /// </remarks>
        public DSNode<T> PreviousNode { get; set; }
    }
}
