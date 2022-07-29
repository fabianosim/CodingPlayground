using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresPlayground.Domains.LinkedList;

namespace Playground.CrackingTheCode
{
    public class StacksAndQueues
    {
        /// <summary>
        /// Exercise 3.5
        /// Sort a Stack
        /// Time Complexity: O(N^2)
        /// Space Complexity: O(N)
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        public static Stack<int> SortStack(Stack<int> stack, out int countOps)
        {
            Stack<int> tempStack = new Stack<int>();
            countOps = 0;

            if (stack.Count <= 1) return stack;

            // Push the first item in the ordered stack
            tempStack.Push(stack.Pop());

            while (stack.Count > 0)
            {
                int tempValue = stack.Pop();

                while (tempStack.Count > 0 && tempValue > tempStack.Peek())
                {
                    stack.Push(tempStack.Pop());
                    countOps++;
                }

                tempStack.Push(tempValue);

                countOps++;
            }

            return tempStack;
        }

    }

    

    /// <summary>
    /// Exercise 3.6
    /// Animal Shelter
    /// </summary>
    public class AnimalShelter
    {
        #region Fields and Properties

        public enum AnimalType
        {
            Dog,
            Cat
        };

        private LinkedList<AnimalType> Shelter { get; set; }
        
        #endregion

        #region Constructors

        public AnimalShelter()
        {
            Shelter = new LinkedList<AnimalType>();
        }

        #endregion

        #region Methods

        public void Enqueue(AnimalType animalType)
        {
            var newAnimal = new LinkedListNode<AnimalType>(animalType);
            Shelter.AddLast(animalType);
        }

        public LinkedListNode<AnimalType>? DequeueAny()
        {
            if (Shelter.Count == 0) return null;
            var tempAnimal = Shelter.First;
            Shelter.RemoveFirst();

            return tempAnimal;
        }

        public LinkedListNode<AnimalType>? DequeueDog()
        {
            return DequeueAnimal(AnimalType.Dog);
        }

        public LinkedListNode<AnimalType>? DequeueCat()
        {
            return DequeueAnimal(AnimalType.Cat);
        }

        public LinkedListNode<AnimalType>? DequeueAnimal(AnimalType type)
        {
            if (Shelter.Count == 0) return null;
            LinkedListNode<AnimalType> tempAnimal = Shelter.First;

            while (tempAnimal != null)
            {
                if (tempAnimal.Value == type)
                    break;

                tempAnimal = tempAnimal.Next;
            }

            return tempAnimal;
        }

        public int AnimalCount()
        {
            return Shelter.Count;
        }
        #endregion

    }


    /// <summary>
    /// Part of Exercise 3.3
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SetOfStacks<T> where T : IComparable<T>
    {
        // The max number of items a stack can have.
        public int Threshold { get; set; }

        public List<SingleStack<T>> Stacks { get; set; }

        // Push a node to the first list containing less nodes than the threshold
        public void Push(DSNode<T> node)
        {
            // Check if we can insert
            if (NeedsNewStackOrExisting(out var stackIndexToPush))
            {
                var newStack = new SingleStack<T>();
                newStack.Push(node);
                Stacks.Add(newStack);
            }
            else
            {
                Stacks[stackIndexToPush].Push(node);
            }
        }

        private bool NeedsNewStackOrExisting(out int indexToPush)
        {
            bool needsNewStack = false;
            int stackIndexToPush = -1;

            // Loop through the stacks to check which one we should insert.
            for (int i = 0; i < Stacks.Count; i++)
            {
                if (Stacks[i].Length() == Threshold && (i != Stacks.Count - 1))
                    continue;

                if (Stacks.Count - 1 == i)
                {
                    needsNewStack = true;
                    break;
                }

                stackIndexToPush = i;
                break;
            }

            indexToPush = stackIndexToPush;
            return needsNewStack;
        }

        // Pops a node from the last stack
        public DSNode<T> Pop()
        {
            int lastStackIndex = Stacks.Count - 1;
            var poppedItem = Stacks[lastStackIndex].Pop();
            RemoveStackIfNeeded(lastStackIndex);

            return poppedItem;
        }

        // Pops out a node from the stack at a specific index.
        public DSNode<T> PopAt(int stackIndex)
        {
            var poppedItem = Stacks[stackIndex].Pop();
            RemoveStackIfNeeded(stackIndex);

            return poppedItem;
        }

        public void RemoveStackIfNeeded(int stackIndex)
        {
            if (Stacks[stackIndex].IsEmpty())
            {
                Stacks.RemoveAt(stackIndex);
            }
        }
    }

    /// <summary>
    /// Part of Exercise 3.3.
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public class SingleStack<T> where T : IComparable<T>
    {
        public DSNode<T>? Head { get; set; }
        public int Count { get; set; }
        public SingleStack()
        {
            Count = 0;
        }

        public void Push(DSNode<T> node)
        {
            var tempNode = Head;
            tempNode.NextNode = node;
            Head = node;
            Count++;
        }

        public DSNode<T> Pop()
        {
            if (Head == null) return null;

            var poppedNode = Head;
            Head = poppedNode.NextNode;
            Count--;

            return Head;
        }

        public DSNode<T>? Peek()
        {
            return Head;
        }

        public int Length()
        {
            return Count;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }
    }

    public class MyQueue<T>
    {
        private Stack<T?> stackNewest { get; set; }
        private Stack<T?> stackOldest { get; set; }

        public MyQueue()
        {
            stackNewest = new Stack<T?>();
            stackOldest = new Stack<T?>();
        }

        public void Enqueue(T? item)
        {
            stackNewest.Push(item);
        }

        public T? Peek()
        {
            ShiftStacks();
            return stackOldest.Peek();
        }

        public T? Dequeue()
        {
            ShiftStacks();
            if (stackOldest.Count > 0) 
                return stackOldest.Pop();

            return default(T);
        }

        public int Size()
        {
            return stackOldest.Count + stackNewest.Count;
        }

        private void ShiftStacks()
        {
            if (stackOldest.Count == 0)
            {
                while (stackNewest.Count > 0)
                {
                    stackOldest.Push(stackNewest.Pop());
                }
            }
        }
    }
}
