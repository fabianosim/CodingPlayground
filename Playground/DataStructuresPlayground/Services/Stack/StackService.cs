using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresPlayground.Domains.Queue;
using DataStructuresPlayground.Services.Stack.Interfaces;

namespace DataStructuresPlayground.Services.Stack
{
    /// <summary>
    /// Service to manipulate a stack.
    /// </summary>
    public class StackService<T> : IStackService<T>
    {
        #region Constructors

        public StackService() { }

        /// <inheritdoc cref="IStackService{T}"/>
        public void AddHead(QueueNode<T> node, Domains.Stack.Stack<T> stack)
        {
            if (stack.Head == null)
            {
                stack.Head = node;
            }
            else
            {
                var currentHead = stack.Head;
                stack.Head = node;
                node.Previous = currentHead;
            }

            stack.Count++;
        }

        /// <inheritdoc cref="IStackService{T}"/>
        public bool IsEmpty(Domains.Stack.Stack<T> stack)
        {
            return stack.Head == null;
        }

        /// <inheritdoc cref="IStackService{T}"/>
        public void RemoveHead(out QueueNode<T> removedNode, Domains.Stack.Stack<T> stack)
        {
            if (stack.Head == null)
            {
                removedNode = null;
                return;
            }

            var currentNode = stack.Head;
            stack.Head = currentNode.Previous;
            stack.Count--;
            removedNode = currentNode;
        }

        #endregion

        #region Methods

        /// <inheritdoc cref="IStackService{T}"/>
        public void StackUp(QueueNode<T> stackNode, Domains.Stack.Stack<T> stack)
        {
            AddHead(stackNode, stack);
        }

        /// <inheritdoc cref="IStackService{T}"/>
        public void Unstack(out QueueNode<T> removedNode, Domains.Stack.Stack<T> stack)
        {
            RemoveHead(out removedNode, stack);
        }

        #endregion
    }
}
