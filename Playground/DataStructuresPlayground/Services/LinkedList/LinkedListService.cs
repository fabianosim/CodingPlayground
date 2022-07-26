using System.Xml;
using DataStructuresPlayground.Domains.LinkedList;
using DataStructuresPlayground.Services.LinkedList.Interfaces;
using DataStructuresPlayground.Support.LinkedLists;

namespace DataStructuresPlayground.Services.LinkedList
{
    public class LinkedListService : ILinkedListService
    {

        #region Fields and Properties

        #endregion

        #region Constructors

        #endregion

        #region Methods

        #region Add

        /// <summary>
        /// Searches for an item in a given list.
        /// </summary>
        /// <typeparam name="T">The data type for the node value.</typeparam>
        /// <param name="node">The node.</param>
        /// <param name="linkedList">The linked list where the node will be add to.</param>.
        /// <param name="addType">Tells if a node should be added to the start or end of a list</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddItem<T>(DSNode<T> node, Domains.LinkedList.DSLinkedList<T> linkedList, LinkedListsSupport.AddType addType) where T : IComparable<T>
        {
            if (linkedList == null)
                throw new ArgumentNullException("linkedList is null.");

            if (addType == LinkedListsSupport.AddType.Head)
                AddItemToHead(node, linkedList);
            else
                AddItemToTail(node, linkedList);
        }

        /// <summary>
        /// Adds an item to the start of the list.
        /// </summary>
        /// <typeparam name="T">The data type for the node value.</typeparam>
        /// <param name="node">The node.</param>
        /// <param name="linkedList">The linked list where the node will be add to.</param>
        public void AddItemToHead<T>(DSNode<T> node, Domains.LinkedList.DSLinkedList<T> linkedList) where T : IComparable<T>
        {
            if (linkedList.Count == 0)
                linkedList.HeadNode = node;
            else
            {
                var tempNode = linkedList.HeadNode;

                linkedList.HeadNode = node;
                linkedList.TailNode = tempNode;
                
                // Now we have to link both nodes
                linkedList.HeadNode.NextNode = linkedList.TailNode;
                linkedList.TailNode.PreviousNode = linkedList.HeadNode;
            }

            linkedList.Count++;
        }

        /// <summary>
        /// Adds an item to the end of the list.
        /// </summary>
        /// <typeparam name="T">The data type for the node value.</typeparam>
        /// <param name="node">The node.</param>
        /// <param name="linkedList">The linked list where the node will be add to.</param>
        public void AddItemToTail<T>(DSNode<T> node, Domains.LinkedList.DSLinkedList<T> linkedList) where T : IComparable<T>
        {
            if (linkedList.Count == 0)
                linkedList.TailNode = node;
            else
            {
                var tempNode = linkedList.TailNode;

                linkedList.HeadNode = tempNode;
                linkedList.TailNode = node;

                // Now we have to link both nodes
                linkedList.HeadNode.NextNode = linkedList.TailNode;
                linkedList.TailNode.PreviousNode = linkedList.HeadNode;
            }

            linkedList.Count++;
        }

        /// <summary>
        /// Add item in such position in the list that it will be sorted
        /// </summary>
        /// <typeparam name="T">The item value</typeparam>
        /// <param name="node">The node to be added</param>
        /// <param name="linkedList">The linked list to have the node added to.</param>
        public void SortAddItem<T>(DSNode<T> node, Domains.LinkedList.DSLinkedList<T> linkedList) where T : IComparable<T>
        {
            if (linkedList.HeadNode == null)
            {
                // List is null, let's insert
                AddItem(node, linkedList, LinkedListsSupport.AddType.Head);
                linkedList.TailNode = node;
            }
            else if (linkedList.HeadNode.Value.CompareTo(node.Value) > 0)
            {
                // Adding before the head node
                linkedList.HeadNode.PreviousNode = node;
                node.NextNode = linkedList.HeadNode;
                linkedList.HeadNode = node;
            }
            else if (linkedList.TailNode.Value.CompareTo(node.Value) < 0)
            {
                // Adding after the tail node
                linkedList.TailNode.NextNode = node;
                node.PreviousNode = linkedList.TailNode;
                linkedList.TailNode = node;
            }
            else
            {
                // Let's find the insertion point
                var nodeAddBefore = linkedList.HeadNode;

                while (nodeAddBefore.Value.CompareTo(node.Value) < 0)
                {
                    nodeAddBefore = nodeAddBefore.NextNode;
                }

                node.NextNode = nodeAddBefore;
                node.PreviousNode = nodeAddBefore.PreviousNode;
                nodeAddBefore.PreviousNode.NextNode = node;
                nodeAddBefore.PreviousNode = node;
            }

            linkedList.Count++;
        }

        #endregion

        /// <summary>
        /// Removes an item from a given Linked List.
        /// </summary>
        /// <typeparam name="T">The data type for the node value.</typeparam>
        /// <param name="value">The value to be removed.</param>
        /// <param name="linkedList">The linked list where this value should be removed from.</param>
        public void RemoveItem<T>(T value, Domains.LinkedList.DSLinkedList<T> linkedList) where T : IComparable<T>
        {
            if (linkedList == null)
                throw new ArgumentNullException("The LinkedList to have the node removed deos not exist. It is null.");

            var nodeFound = SearchNode(value, linkedList);

            if (nodeFound == null)
                return;

            var nextNode = nodeFound.NextNode;
            var previousNode = nodeFound.PreviousNode;

            if (previousNode == null)
            {
                // This is the Head node, as PreviousNode is null.
                linkedList.HeadNode = nextNode;

                if (linkedList.HeadNode != null) linkedList.HeadNode.PreviousNode = null;
            }
            else
            {
                previousNode.NextNode = nextNode;
            }

            if(nextNode == null)
            {
                // This is the Tail node, as nextNode is null.
                linkedList.TailNode = previousNode;

                if (linkedList.TailNode != null) linkedList.TailNode.NextNode = null;
            }
            else
            {
                nextNode.PreviousNode = previousNode;
            }

            // Make sure the tail and head does not point to the node found
            if (linkedList.HeadNode.Equals(nodeFound)) linkedList.HeadNode = previousNode;
            if (linkedList.TailNode.Equals(nodeFound)) linkedList.TailNode = nextNode;

            linkedList.Count--;
        }

        /// <summary>
        /// Search for a node. If found, return it.
        /// </summary>
        /// <typeparam name="T">The type of the value to search.</typeparam>
        /// <param name="value">The value to be searched.</param>
        /// <param name="linkedList">The linked list where the value will be searched.</param>
        /// <returns></returns>
        public DSNode<T>? SearchNode<T>(T value, Domains.LinkedList.DSLinkedList<T> linkedList) where T : IComparable<T>
        {
            var currentNode = linkedList.HeadNode;

            // Search forward
            while (currentNode != null)
            {
                if (currentNode.Value != null && currentNode.Value.Equals(value))
                    return currentNode;

                currentNode = currentNode.NextNode;
            }

            currentNode =linkedList.TailNode;

            // Search Backwards
            while (currentNode != null)
            {
                if (currentNode.Value != null && currentNode.Value.Equals(value))
                    return currentNode;

                currentNode = currentNode.PreviousNode;
            }

            return null;
        }

        /// <summary>
        /// List all nodes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="linkedList"></param>
        /// <returns></returns>
        public IEnumerable<T> ListAllNodes<T>(Domains.LinkedList.DSLinkedList<T> linkedList) where T : IComparable<T>
        {
            // From Head to Tail
            var currentNode = linkedList.HeadNode;

            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        #endregion
    }
}
