using DataStructuresPlayground.Domains.Queue;

namespace DataStructuresPlayground.Services.Queue.Interfaces
{
    /// <summary>
    /// Defines methods to manipulate a queue data structure.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueueService<T>
    {
        #region Methods to manipulate the queue itself.

        /// <summary>
        /// Enqueue a node.
        /// </summary>
        /// <param name="node">The node to enqueue.</param>
        /// <param name="queue">The queue to enqueue que node.</param>
        /// <remarks>By default, it adds to the tail.</remarks>
        public void Enqueue(QueueNode<T> node, Domains.Queue.Queue<T> queue);

        /// <summary>
        /// Dequeue a node.
        /// </summary>
        /// <param name="queue">The queue to dequeue the node.</param>
        /// <param name="removedNode">The removed node to be returned.</param>
        /// <remarks>By default, it removes from the head.</remarks>
        public void Dequeue(out QueueNode<T> removedNode, Domains.Queue.Queue<T> queue);

        #endregion

        #region Methods to manipulate single nodes

        /// <summary>
        /// Adds a node to the head of the queue.
        /// </summary>
        /// <param name="node">The node to be added.</param>
        /// <param name="queue">The queue to add a node to the head.</param>
        public void AddHead(QueueNode<T> node, Domains.Queue.Queue<T> queue);

        /// <summary>
        /// Remove a node from the head of the queue.
        /// </summary>
        /// <param name="removedNode">The removed node. Useful to check if the node removed is really the one removed.</param>
        /// <param name="queue">The queue to have the head removed.</param>
        /// <remarks>If it is not possible to remove the node, then out node will be null.</remarks>
        public void RemoveHead(out QueueNode<T> removedNode, Domains.Queue.Queue<T> queue);

        /// <summary>
        /// Adds a node to the queue`s tail.
        /// </summary>
        /// <param name="node">The node to be added to que queue`s tail.</param>
        /// <param name="queue">The queue to have the tail node added.</param>
        public void AddTail(QueueNode<T> node, Domains.Queue.Queue<T> queue);

        /// <summary>
        /// Removes a node from the queue`s tail.
        /// </summary>
        /// <param name="removedTail">The removed tail node.</param>
        /// <param name="queue">The queue to have the node removed from.</param>
        /// <remarks>If it is not possible to remove the node, then out node will be null.</remarks>
        public void RemoveTail(out QueueNode<T> removedTail, Domains.Queue.Queue<T> queue);

        /// <summary>
        /// Checks if the queue is empty.
        /// </summary>
        /// <param name="queue">The queue to be checked.</param>
        /// <returns>True if the queue is empty. False otherwise.</returns>
        public bool IsEmpty(Domains.Queue.Queue<T> queue);

        #endregion
    }
}
