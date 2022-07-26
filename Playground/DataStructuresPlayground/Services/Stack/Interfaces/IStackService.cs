using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresPlayground.Domains.Queue;

namespace DataStructuresPlayground.Services.Stack.Interfaces
{
    public interface IStackService<T>
    {
        #region Methods to manipulate the queue itself.

        /// <summary>
        /// Enqueue a node.
        /// </summary>
        /// <param name="node">The node to enqueue.</param>
        /// <param name="stack">The stack to stack up the node.</param>
        /// <remarks>By default, it adds to the tail.</remarks>
        public void StackUp(QueueNode<T> node, Domains.Stack.Stack<T> stack);

        /// <summary>
        /// Dequeue a node.
        /// </summary>
        /// <param name="stack">The stack to unstack the node.</param>
        /// <param name="removedNode">The removed node to be returned.</param>
        /// <remarks>By default, it removes from the head.</remarks>
        public void Unstack(out QueueNode<T> removedNode, Domains.Stack.Stack<T> stack);

        #endregion

        #region Methods to manipulate single nodes

        /// <summary>
        /// Adds a node to the head of the queue.
        /// </summary>
        /// <param name="node">The node to be added.</param>
        /// <param name="stack">The stack to add a node to the head.</param>
        public void AddHead(QueueNode<T> node, Domains.Stack.Stack<T> stack);

        /// <summary>
        /// Remove a node from the head of the queue.
        /// </summary>
        /// <param name="removedNode">The removed node. Useful to check if the node removed is really the one removed.</param>
        /// <param name="stack">The stack to have the head removed.</param>
        /// <remarks>If it is not possible to remove the node, then out node will be null.</remarks>
        public void RemoveHead(out QueueNode<T> removedNode, Domains.Stack.Stack<T> stack);

        /// <summary>
        /// Checks if the queue is empty.
        /// </summary>
        /// <param name="stack">The stack to be checked.</param>
        /// <returns>True if the queue is empty. False otherwise.</returns>
        public bool IsEmpty(Domains.Stack.Stack<T> stack);

        #endregion
    }
}
