using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresPlayground.Domains.Queue;
using DataStructuresPlayground.Services.Queue.Interfaces;

namespace DataStructuresPlayground.Services.Queue
{
    /// <summary>
    /// Implementation of <see cref="IQueueService{T}"/>
    /// </summary>
    /// <typeparam name="T">The value of the queue node.</typeparam>
    public class QueueService<T> : IQueueService<T>
    {
        #region Interface Methods

        /// <inheritdoc cref="IQueueService{T}"/>
        public void Enqueue(QueueNode<T> node, Domains.Queue.Queue<T> queue)
        {
            AddTail(node, queue);
        }

        /// <inheritdoc cref="IQueueService{T}"/>
        public void Dequeue(out QueueNode<T> removedNode, Domains.Queue.Queue<T> queue)
        {
            RemoveHead(out removedNode, queue);
        }

        /// <inheritdoc cref="IQueueService{T}"/>
        public void AddHead(QueueNode<T> node, Domains.Queue.Queue<T> queue)
        {
            QueueNode<T> currentHead = queue.Head;
            node.Previous = currentHead;
            queue.Head = node;
        }

        /// <inheritdoc cref="IQueueService{T}"/>
        public void RemoveHead(out QueueNode<T> removedNode, Domains.Queue.Queue<T> queue)
        {
            if (IsEmpty(queue))
            {
                removedNode = null;
                return;
            }

            var currentHead = queue.Head;
            queue.Head = queue.Head.Previous;
            removedNode = currentHead;
            queue.Count--;
        }

        /// <inheritdoc cref="IQueueService{T}"/>
        public void AddTail(QueueNode<T> node, Domains.Queue.Queue<T> queue)
        {
            if (queue.Tail == null)
            {
                // If tail is null, queue is empty. Head and tail should be the same.
                queue.Tail = node;
                queue.Head = node;
            }
            else
            {
                // Updates tail node
                QueueNode<T> currentTail = queue.Tail;
                currentTail.Previous = node;
                node.Next = currentTail;
                queue.Tail = node;
            }

            queue.Count++;
        }

        /// <inheritdoc cref="IQueueService{T}"/>
        public void RemoveTail(out QueueNode<T> removedTail, Domains.Queue.Queue<T> queue)
        {
            if (IsEmpty(queue))
            {
                removedTail = null;
                return;
            }

            var currentTail = queue.Tail;
            queue.Tail = currentTail.Next;
            removedTail = currentTail;
            queue.Count--;
        }

        public bool IsEmpty(Domains.Queue.Queue<T> queue)
        {
            return (queue.Head == null || queue.Tail == null);
        }
        
        #endregion
    }
}
