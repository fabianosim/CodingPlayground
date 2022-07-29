using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataStructuresPlayground;
using DataStructuresPlayground.Domains.LinkedList;
using DataStructuresPlayground.Services.LinkedList;
using DataStructuresPlayground.Support.LinkedLists;

namespace Playground.CrackingTheCode
{
    public static class LinkedLists
    {
        /// <summary>
        /// Write code to remove duplicates from an unsorted linked list.
        /// Exercise 2.1
        /// Time complexity: O(N)
        /// Space complexity: O(N^2)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DSLinkedList<int> RemoveDups(DSLinkedList<int> list)
        {
            // If the list is null, then it is not possible to remove anything.
            if (list.HeadNode == null) return list;

            var currentNode = list.HeadNode;
            var lastNode = list.HeadNode;
            Hashtable listElements = new Hashtable();

            while (currentNode != null)
            {
                if (listElements.ContainsKey(currentNode.Value))
                {
                    lastNode.NextNode = currentNode.NextNode;
                    list.Count -= 1;
                }
                else
                {
                    listElements.Add(currentNode.Value, true); // set any value to this key, since we won't use it.
                    lastNode = currentNode;
                }

                currentNode = currentNode.NextNode;
            }

            return list;
        }

        /// <summary>
        /// Write code to remove duplicates from an unsorted linked list.
        /// This time, without buffer.
        /// Exercise 2.1
        /// Time complexity: 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DSLinkedList<int> RemoveDupsNoBuffer(DSLinkedList<int> list)
        {
            // If the list is null, then it is not possible to remove anything.
            if (list.HeadNode == null) return list;

            var currentNode = list.HeadNode;

            while (currentNode != null)
            {
                var currentRunnerNode = currentNode;

                while (currentRunnerNode.NextNode != null)
                {
                    if (currentRunnerNode.NextNode.Value == currentNode.Value)
                    {
                        currentRunnerNode.NextNode = currentRunnerNode.NextNode.NextNode;
                        list.Count -= 1;
                    }
                    else
                    {
                        currentRunnerNode = currentRunnerNode.NextNode;
                    }
                }

                currentNode = currentNode.NextNode;
            }

            return list;
        }

        /// <summary>
        /// Implement an algorithm to find the kth to last element of a singly linked list
        /// Exercise 2.2
        /// Time complexity: O(N+N) = O(N)
        /// Space complexity: O(2N)
        /// </summary>
        /// <remarks>
        /// Simple approach would be to use a stack.
        /// - First, stack all items until NextNode is null
        /// - Outside of the while loop, start popping out the items until it reaches the desired one
        /// - return the kth popped item from the stack.
        /// </remarks>
        /// <param name="kElement"></param>
        public static int KthFromLastElement(int kElement, DSLinkedList<int> list)
        {
            Stack<int> stackOfValues = new Stack<int>();
            var currentNode = list.HeadNode;
            int resultVal = 0;

            while (currentNode != null)
            {
                stackOfValues.Push(currentNode.Value);
                currentNode = currentNode.NextNode;
            }

            // If the stack doesn't have enough values, it will not possible to return the values.
            if (stackOfValues.Count < kElement)
                return -1;

            // pop out kth element from the stack
            for (int i = 0; i < kElement; i++)
                resultVal = stackOfValues.Pop();

            return resultVal;
        }

        /// <summary>
        /// Exercise 2.3
        /// Use 2 variables for the nodes. current and next
        /// compare the input with the first one. If it is found, skip it.
        /// the comparison inside the loop will happen from the next node and further
        /// if the next node doesn’t have a next node, then we are in the end.
        /// if the next node contains the value, update the current node to the next of next node
        ///
        /// Time Complexity: O(N)
        /// Space Complexity: O(1)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="list"></param>
        public static void RemoveMiddleNode(int value, DSLinkedList<int> list)
        {
            var currentNode = list.HeadNode;

            // For value being found in the first node, do nothing.
            if (currentNode.Value.Equals(value))
                return;

            while (currentNode != null)
            {
                // First comparison is already done, we can skip to the next right away
                var nextNode = currentNode.NextNode;

                if (nextNode.Value.Equals(value))
                {
                    // If we are in the last node, return
                    if (nextNode.NextNode == null)
                        return;

                    // Node is found, remove it. Check for last node is already done.
                    currentNode.NextNode = nextNode.NextNode;
                    list.Count -= 1; // Update the count, so we can easily test if node was removed.
                    return;
                }

                currentNode = currentNode.NextNode;
            }
        }

        /// <summary>
        /// Exercise 2.4
        /// </summary>
        /// <param name="value"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DSNode<int> PartitionList(int value, DSLinkedList<int> list)
        {
            DSNode<int> head = list.HeadNode;
            DSNode<int> tail = list.TailNode;
            var currentNode = list.HeadNode;

            while (currentNode != null)
            {
                DSNode<int> next = currentNode.NextNode;

                if (currentNode.Value < value)
                {
                    // Insert node at the head.
                    currentNode.NextNode = head;
                    head = currentNode;
                }
                else
                {
                    // Insert node at the tail
                    tail.NextNode = currentNode;
                    tail = currentNode;
                }

                currentNode = next;
            }

            tail.NextNode = null;

            return head;
        }

        /// <summary>
        /// Exercise 2.5
        /// Sum two linked lists.
        /// Time Complexity:
        /// </summary>
        /// <remarks>
        ///     - Questions:
        ///         - Do I know the length of the list?
        ///         - Is the tail node known? Assuming no.
        ///         - Do I have any null value? Assuming no.
        ///     - Assumptions
        ///         - Tail node is not known
        ///         - Length of both lists is not known either.
        ///     - Solution
        ///         - If tail node is not known, then will iterate through list and add each single number in an array of integers.
        ///         - Since we are iterating from the head, this is the order we want.
        ///         - Do the same for the other list.
        ///         - Sum the numbers
        ///         - Convert to string and split characters
        ///         - Perform a final loop to form up a new list
        /// 
        ///
        /// </remarks>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static DSLinkedList<int> SumLists(DSLinkedList<int> list1, DSLinkedList<int> list2)
        {
            // That will store both numbers
            StringBuilder sbNumber1 = new StringBuilder();
            StringBuilder sbNumber2 = new StringBuilder();
            DSLinkedList<int> finalSumList = new DSLinkedList<int>();
            LinkedListService listService = new LinkedListService();

            // Forming up first SB
            var currentHeadList1 = list1.HeadNode;

            while (currentHeadList1 != null)
            {
                sbNumber1.Append(currentHeadList1.Value);
                currentHeadList1 = currentHeadList1.NextNode;
            }

            // Forming up the second SB
            var currentHeadList2 = list2.HeadNode;

            while (currentHeadList2 != null)
            {
                sbNumber2.Append(currentHeadList2.Value);
                currentHeadList2 = currentHeadList2.NextNode;
            }

            // Sum the numbers
            string sumAsString = (int.Parse(sbNumber1.ToString()) + int.Parse(sbNumber2.ToString())).ToString();

            foreach (var sumChar in sumAsString)
                listService.AddItem(new DSNode<int>(int.Parse(sumChar.ToString())), finalSumList,
                    LinkedListsSupport.AddType.Head);

            return finalSumList;
        }

        /// <summary>
        /// Exercise 2.5
        /// List without string concatenation
        /// Time Complexity: O(N)
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <param name="carry"></param>
        /// <returns></returns>
        public static DSNode<int> SumListsNoStrings(DSNode<int> node1, DSNode<int> node2, int carry)
        {
            LinkedListService listService = new LinkedListService();

            if (node1 == null && node2 == null && carry == 0)
                return null;

            DSNode<int> sumNode = new DSNode<int>(0);
            int value = carry;

            if (node1 != null)
            {
                value += node1.Value;
            }

            if (node2 != null)
            {
                value += node2.Value;
            }

            // Retrieves the second digit of the number
            sumNode.Value = value % 10;

            // Let's go for recursion
            if (node1 != null || node2 != null)
            {
                DSNode<int> more = SumListsNoStrings(node1 == null ? null : node1.NextNode,
                    node2 == null ? null : node2.NextNode, value >= 10 ? 1 : 0);

                sumNode.NextNode = more;
            }

            return sumNode;
        }

        /// <summary>
        /// Exercise 2.6
        /// Is linked list a palindrome?
        /// Time Complexity: O(N)
        /// Space complexity: O(N)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsLinkedListPalindrome(DSLinkedList<int> list)
        {
            // Empty list is not a palindrome, right?
            if (list.HeadNode == null)
                return false;

            Stack<int> listValuesStack = new Stack<int>();
            DSNode<int> currentNode = list.HeadNode;

            // First loop to store the values
            while (currentNode != null)
            {
                listValuesStack.Push(currentNode.Value);
                currentNode = currentNode.NextNode;
            }

            // Second loop is to compare if all values are the same.
            // Given that I don’t know the size of the list, then I need to do this second loop
            currentNode = list.HeadNode;

            while (currentNode != null)
            {
                int stackedValue = listValuesStack.Pop();
                if (!stackedValue.Equals(currentNode.Value))
                    return false;

                currentNode = currentNode.NextNode;
            }

            return true;
        }

        /// <summary>
        /// Exercise 2.6
        /// Same as before, but now with runner technique
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsLinkedListPalindromeRunner(DSLinkedList<int> list)
        {
            DSNode<int> fast = list.HeadNode;
            DSNode<int> slow = list.HeadNode;

            Stack<int> halfListValues = new Stack<int>();

            while (fast != null && fast.NextNode != null)
            {
                halfListValues.Push(slow.Value);
                slow = slow.NextNode;
                fast = fast.NextNode.NextNode;
            }

            // check for odd values
            if (fast != null)
                slow = slow.NextNode;

            while (slow != null)
            {
                int top = halfListValues.Pop();

                // If values are different, it is not a palindrome.
                if (!top.Equals(slow.Value))
                    return false;

                slow = slow.NextNode;
            }

            return true;
        }

        /// <summary>
        /// Exercise 2.7
        /// Check if a list is intersecting with another list by reference.
        /// Time Complexity: O(A + B)
        /// Space Complexity: O(A) or O(B)
        /// </summary>
        /// <remarks>
        ///     One approach would be to:
        ///     - create a dictionary with Node keys and populate it with one of the lists
        ///     - loop through the other list and check if the node exists in the first list
        ///     - if exists, then they intersect
        ///     - since a Dictionary is strong typed, we can store the node itself to the list. the comparison will compare both objects to check if they are the same in memory.
        /// </remarks>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static bool IsIntersection(DSLinkedList<int> list1, DSLinkedList<int> list2)
        {
            Dictionary<DSNode<int>, int> listNodes = new Dictionary<DSNode<int>, int>();

            // Loop through list 1
            var currentNode = list1.HeadNode;

            while (currentNode != null)
            {
                listNodes.Add(currentNode, currentNode.Value);
                currentNode = currentNode.NextNode;
            }

            // Now let's loop through the second list
            currentNode = list2.HeadNode;

            while (currentNode != null)
            {
                if (listNodes.ContainsKey(currentNode))
                    return true;
                
                currentNode = currentNode.NextNode;
            }

            return false;
        }

        /// <summary>
        /// Exercise 2.8
        /// Return the node that corrupts a linked list.
        /// Time Complexity: O(N)
        /// Space Complexity: O(N)
        /// </summary>
        /// <remarks>
        ///     Approach:
        ///     - throw all items in a hashtable or dictionary
        ///     - in each iteration, check if the next node already exists.
        ///     - if yes, then that is the corrupted node.
        ///     - return that node.
        /// </remarks>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DSNode<int>? LinkedListCorrupted(DSLinkedList<int> list)
        {
            if (list.HeadNode == null || list.TailNode == null) return null;

            Hashtable nodesTable = new Hashtable();
            var currentNode = list.HeadNode;

            while (currentNode != null)
            {
                // If node exists in hashtable, then the list is circular.
                if (nodesTable.ContainsKey(currentNode))
                    return currentNode;
                
                nodesTable.Add(currentNode, currentNode.Value);
                currentNode = currentNode.NextNode;
            }

            return null;
        }

        public static DSNode<int>? LinkedListCorruptedWithCollision(DSLinkedList<int> list)
        {
            DSNode<int> slow = list.HeadNode;
            DSNode<int> fast = list.HeadNode;

            // Find meeting point.
            while (fast != null && fast.NextNode != null)
            {
                slow = slow.NextNode;
                fast = fast.NextNode.NextNode;

                if (slow == fast) // collision!
                    break;
            }

            // Error check to see if there is no loop. 
            if (fast == null || fast.NextNode == null) return null;

            // Moving slow to head and start walking at the same pace. They should meet each other at the collision point.
            slow = list.HeadNode;

            while (slow != fast)
            {
                slow = slow.NextNode;
                fast = fast.NextNode;
            }

            // Both nodes point to the start of the loop.
            return fast;
        }
    }
}
