using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPlayground.Domains.Queue
{
    /// <summary>
    /// Represents a queue item.
    /// </summary>
    /// <typeparam name="T">The value of the queue's items.</typeparam>
    public class Queue<T> : ICollection<T>
    {
        #region Constructors

        public Queue(){}

        /// <summary>
        /// Initializes a queue with head and tail.
        /// </summary>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        public Queue(QueueNode<T> head, QueueNode<T> tail)
        {
            Head = head;
            Tail = tail;
        }

        #endregion

        #region Fields and Properties

        /// <summary>
        /// The head node.
        /// </summary>
        public QueueNode<T>? Head { get; set; }

        /// <summary>
        /// The tail node.
        /// </summary>
        public QueueNode<T>? Tail { get; set; }

        

        #endregion

        /// <summary>
        /// Enumerates the items from head to tail
        /// </summary>
        /// <returns>The enumerator that will get all nodes one by one.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerator<T> GetEnumerator()
        {
            QueueNode<T> currentNode = Head;

            while (currentNode.Previous != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Previous;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; set; }
        public bool IsReadOnly { get; set; }
    }
}
