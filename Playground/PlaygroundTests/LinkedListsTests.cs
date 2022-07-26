using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresPlayground.Domains.LinkedList;
using DataStructuresPlayground.Services.LinkedList;
using DataStructuresPlayground.Support.LinkedLists;
using Playground.CrackingTheCode;

namespace PlaygroundTests
{
    [TestFixture]
    public class LinkedListsTests
    {
        private LinkedListService listService { get; set; }

        [SetUp]
        public void LinkedListsTestsSetup()
        {
            listService = new LinkedListService();
        }

        [Test]
        public void OnRemoveDups_ShouldRemoveAllDuplicatedVals()
        {
            // Arrange
            DSNode<int> node1 = new DSNode<int>(10);
            DSNode<int> node2 = new DSNode<int>(5);
            DSNode<int> node3 = new DSNode<int>(10);
            DSNode<int> node4 = new DSNode<int>(10);
            DSNode<int> node5 = new DSNode<int>(10);
            DSLinkedList<int> list = new DSLinkedList<int>();
            
            listService.AddItem(node1, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node2, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node3, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node4, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node5, list, LinkedListsSupport.AddType.Head);
            
            // Act
            var listWithoutDumps = LinkedLists.RemoveDups(list);

            // Assert: after removing dumps, list should contains 4 items instead of 5.
            Assert.AreEqual(2, listWithoutDumps.Count);
        }

        [Test]
        public void OnRemoveDupsNoBuffer_ShouldRemoveAllDuplicatedVals()
        {
            // Arrange
            DSNode<int> node1 = new DSNode<int>(10);
            DSNode<int> node2 = new DSNode<int>(5);
            DSNode<int> node3 = new DSNode<int>(10);
            DSNode<int> node4 = new DSNode<int>(10);
            DSNode<int> node5 = new DSNode<int>(10);
            DSLinkedList<int> list = new DSLinkedList<int>();

            listService.AddItem(node1, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node2, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node3, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node4, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node5, list, LinkedListsSupport.AddType.Head);

            // Act
            var listWithoutDumps = LinkedLists.RemoveDupsNoBuffer(list);

            // Assert: after removing dumps, list should contains 4 items instead of 5.
            Assert.AreEqual(2, listWithoutDumps.Count);
        }

        [Test]
        public void OnKthToLastElement_ShouldReturnElement()
        {
            // Arrange
            DSNode<int> node1 = new DSNode<int>(5);
            DSNode<int> node2 = new DSNode<int>(8);
            DSNode<int> node3 = new DSNode<int>(2);
            DSNode<int> node4 = new DSNode<int>(3);
            DSNode<int> node5 = new DSNode<int>(1);
            DSLinkedList<int> list = new DSLinkedList<int>();
            listService.AddItem(node1, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node2, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node3, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node4, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node5, list, LinkedListsSupport.AddType.Head);

            int kthElement = 1; // target to be found

            // Act
            var kthFoundElement = LinkedLists.KthFromLastElement(5, list);

            // Assert
            Assert.That(kthFoundElement, Is.EqualTo(kthElement));

        }

        [Test]
        public void OnRemoveMiddleNode_ShouldRemoveNode()
        {
            // Arrange
            DSNode<int> node1 = new DSNode<int>(5);
            DSNode<int> node2 = new DSNode<int>(8);
            DSNode<int> node3 = new DSNode<int>(2);
            DSNode<int> node4 = new DSNode<int>(3);
            DSNode<int> node5 = new DSNode<int>(1);
            DSLinkedList<int> list = new DSLinkedList<int>();
            listService.AddItem(node1, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node2, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node3, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node4, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node5, list, LinkedListsSupport.AddType.Head);

            // Act
            LinkedLists.RemoveMiddleNode(8, list);

            // Assert
            Assert.IsNull(listService.SearchNode(8, list));
        }

        [Test]
        public void OnRemoveMiddleNode_ShouldNotRemoveFirstNode()
        {
            // Arrange
            DSNode<int> node1 = new DSNode<int>(5);
            DSNode<int> node2 = new DSNode<int>(8);
            DSNode<int> node3 = new DSNode<int>(2);
            DSNode<int> node4 = new DSNode<int>(3);
            DSNode<int> node5 = new DSNode<int>(1);
            DSLinkedList<int> list = new DSLinkedList<int>();
            listService.AddItem(node1, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node2, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node3, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node4, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node5, list, LinkedListsSupport.AddType.Head);

            // Act
            LinkedLists.RemoveMiddleNode(node1.Value, list);

            // Assert
            Assert.IsNotNull(listService.SearchNode(node1.Value, list));
        }

        [Test]
        public void OnRemoveMiddleNode_ShouldNotRemoveLastNode()
        {
            // Arrange
            DSNode<int> node1 = new DSNode<int>(5);
            DSNode<int> node2 = new DSNode<int>(8);
            DSNode<int> node3 = new DSNode<int>(2);
            DSNode<int> node4 = new DSNode<int>(3);
            DSNode<int> node5 = new DSNode<int>(1);
            DSLinkedList<int> list = new DSLinkedList<int>();
            listService.AddItem(node1, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node2, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node3, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node4, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node5, list, LinkedListsSupport.AddType.Head);

            // Act
            LinkedLists.RemoveMiddleNode(node5.Value, list);

            // Assert
            Assert.IsNotNull(listService.SearchNode(node5.Value, list));
        }

        [Test]
        public void OnPartitionList_ShouldPartitionList()
        {
            // Arrange
            DSNode<int> node1 = new DSNode<int>(3);
            DSNode<int> node2 = new DSNode<int>(5);
            DSNode<int> node3 = new DSNode<int>(8);
            DSNode<int> node4 = new DSNode<int>(5);
            DSNode<int> node5 = new DSNode<int>(10);
            DSNode<int> node6 = new DSNode<int>(2);
            DSNode<int> node7 = new DSNode<int>(1);
            DSLinkedList<int> list = new DSLinkedList<int>();
            listService.AddItem(node1, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node2, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node3, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node4, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node5, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node6, list, LinkedListsSupport.AddType.Head);
            listService.AddItem(node7, list, LinkedListsSupport.AddType.Head);
            
            // Act
            LinkedLists.PartitionList(node2.Value, list);

            // Assert
            Assert.IsNotNull(list.HeadNode);
        }

        [Test]
        public void OnSumLists_ShouldReturnListWithSumNumbers()
        {
            // Arrange
            // List 1
            DSNode<int> node1 = new DSNode<int>(7);
            DSNode<int> node2 = new DSNode<int>(1);
            DSNode<int> node3 = new DSNode<int>(6);

            // List 2
            DSNode<int> node4 = new DSNode<int>(5);
            DSNode<int> node5 = new DSNode<int>(9);
            DSNode<int> node6 = new DSNode<int>(2);
            
            DSLinkedList<int> list1 = new DSLinkedList<int>();
            DSLinkedList<int> list2 = new DSLinkedList<int>();
            listService.AddItem(node1, list1, LinkedListsSupport.AddType.Head);
            listService.AddItem(node2, list1, LinkedListsSupport.AddType.Head);
            listService.AddItem(node3, list1, LinkedListsSupport.AddType.Head);
            listService.AddItem(node4, list2, LinkedListsSupport.AddType.Head);
            listService.AddItem(node5, list2, LinkedListsSupport.AddType.Head);
            listService.AddItem(node6, list2, LinkedListsSupport.AddType.Head);

            // Act
            var sumList = LinkedLists.SumLists(list1, list2);

            // Assert
            Assert.That(2, Is.EqualTo(sumList.HeadNode.Value));
            Assert.That(1, Is.EqualTo(sumList.HeadNode.NextNode.Value));
            Assert.That(9, Is.EqualTo(sumList.HeadNode.NextNode.NextNode.Value));
        }

        /*[Test]
        public void OnSumListsNoStrings_ShouldReturnListWithSumNumbers()
        {
            // Arrange
            // List 1
            DSNode<int> node1 = new DSNode<int>(6);
            DSNode<int> node2 = new DSNode<int>(1);
            DSNode<int> node3 = new DSNode<int>(7);

            node1.NextNode = node2;
            node2.NextNode = node3;

            // List 2
            DSNode<int> node4 = new DSNode<int>(2);
            DSNode<int> node5 = new DSNode<int>(9);
            DSNode<int> node6 = new DSNode<int>(5);

            node4.NextNode = node5;
            node5.NextNode = node6;

            // Act
            var sumList = LinkedLists.SumListsNoStrings(node1, node2, 0);

            // Assert
            Assert.That(2, Is.EqualTo(sumList.Value));
            Assert.That(1, Is.EqualTo(sumList.NextNode.Value));
            Assert.That(9, Is.EqualTo(sumList.NextNode.NextNode.Value));
        }*/
    }
}
