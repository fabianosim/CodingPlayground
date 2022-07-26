using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPlayground.Domains.Queue
{
    /// <summary>
    /// Represents a queue node.
    /// </summary>
    /// <typeparam name="T">The value for this node.</typeparam>
    public class QueueNode<T>
    {
        #region Constructors

        /// <summary>
        /// Creates a queue node with a value assigned.
        /// </summary>
        /// <param name="value">The value of this node.</param>
        public QueueNode(T value)
        {
            Value = value;
        }

        #endregion

        #region Fields and Properties

        /// <summary>
        /// The node value. Can be of any type.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The reference to the next node.
        /// </summary>
        public QueueNode<T>? Next { get; set; }

        /// <summary>
        /// The reference to the previous node.
        /// </summary>
        public QueueNode<T>? Previous { get; set; }

        #endregion
    }
}
