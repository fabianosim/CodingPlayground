using System.Collections;

namespace DataStructuresPlayground.Domains.LinkedList
{
    /// <summary>
    ///     Represents the Linked List. Can be of any type.
    /// </summary>
    public class DSLinkedList<T> : ICollection where T : IComparable<T>
    {
        #region Class fields and properties

        /// <summary>
        /// Represents the first node of the list.
        /// </summary>
        public DSNode<T>? HeadNode { get; set; }

        /// <summary>
        /// Represents the last node of the list.
        /// </summary>
        public DSNode<T>? TailNode { get; set; }
        #endregion

        #region ICollection Implementations
        
        public IEnumerator GetEnumerator()
        {
            var tempNode = HeadNode;

            while (tempNode != null)
            {
                yield return tempNode.Value;
                tempNode = tempNode.NextNode;
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tells how many nodes exist in the list.
        /// </summary>
        public int Count { get; set; }
        public bool IsSynchronized { get; }
        public object SyncRoot { get; }

        #endregion
    }
}
