using DataStructuresPlayground.Domains.LinkedList;
using DataStructuresPlayground.Support.LinkedLists;

namespace DataStructuresPlayground.Services.LinkedList.Interfaces
{
    /// <summary>
    ///     Defines the methods to be implemented by LinkedList Service.
    /// </summary>
    public interface ILinkedListService
    {
        #region Attributes and Properties signatures

        #endregion

        #region Method signatures

        /// <summary>
        /// Add an item to a linked list.
        /// </summary>
        /// <typeparam name="T">The generic type. Can be any object.</typeparam>
        /// <param name="item">The item to be added.</param>
        /// <param name="linkedList">The linked where the item will be added to.</param>
        /// <param name="addType">Indicates whether the item should be added to the start or end of a list.</param>
        public void AddItem<T>(DSNode<T> item, Domains.LinkedList.DSLinkedList<T> linkedList, LinkedListsSupport.AddType addType) where T : IComparable<T>;

        #endregion
    }
}
