using NUnit.Framework;
using DataStructuresPlayground.Domains.LinkedList;
using DataStructuresPlayground.Services.LinkedList;
using DataStructuresPlayground.Support.LinkedLists;
using NuGet.Frameworks;
using NUnit.Framework.Internal;


namespace DataStructuresTests.LinkedLists;

[TestFixture]
public class LinkedListTests
{
    #region Fields and Properties

    /// <summary>
    /// The list that will be used for the tests. It is a list of integers.
    /// </summary>
    private DSLinkedList<int>? LinkedIntList { get; set; }
    
    /// <summary>
    /// The service responsible to perform the list operations
    /// </summary>
    private LinkedListService ListService { get; set; }

    #endregion

    #region Setup methods

    /// <summary>
    /// Initialize any required variable for this test.
    /// </summary>
    [SetUp]
    public void Setup_LinkedListTests()
    {
        LinkedIntList = new DSLinkedList<int>();
        ListService = new LinkedListService();
    }

    #endregion

    [Test]
    public void OnLinkedListAdd_ShouldAddNodeToList_WithAddTypeHead()
    {
        // Arrange
        var node = new DSNode<int>(1);

        // Act
        ListService.AddItem(node, LinkedIntList, LinkedListsSupport.AddType.Head);

        // Assert
        Assert.IsNotNull(LinkedIntList.HeadNode);
    }

    [Test]
    public void OnLinkedListAdd_ShouldAddManyNodesToList_WithAddTypeHead()
    {
        // Arrange
        var nodes = new List<DSNode<int>>()
        {
            new DSNode<int>(1),
            new DSNode<int>(2),
            new DSNode<int>(3),
            new DSNode<int>(4),
        };

        // Act
        foreach (DSNode<int> node in nodes)
        {
            ListService.AddItem(node, LinkedIntList, LinkedListsSupport.AddType.Head);
        }

        // Assert
        Assert.IsNotNull(LinkedIntList.TailNode);
        Assert.IsNotNull(LinkedIntList.HeadNode);
        Assert.AreEqual(LinkedIntList.TailNode.PreviousNode, LinkedIntList.HeadNode);
        Assert.AreEqual(LinkedIntList.HeadNode.NextNode, LinkedIntList.TailNode);
        Assert.AreEqual(LinkedIntList.HeadNode.Value, 4);
        Assert.AreEqual(LinkedIntList.Count, 4);
    }

    [Test]
    public void OnLinkedListAdd_ShouldAddManyNodesToList_WithAddTypeTail()
    {
        // Arrange
        var nodes = new List<DSNode<int>>
        {
            new DSNode<int>(1),
            new DSNode<int>(2),
            new DSNode<int>(3),
            new DSNode<int>(4)
        };

        // Act
        foreach (DSNode<int> node in nodes)
        {
            ListService.AddItem(node, LinkedIntList, LinkedListsSupport.AddType.Tail);
        }

        // Assert
        Assert.IsNotNull(LinkedIntList.TailNode);
        Assert.IsNotNull(LinkedIntList.HeadNode);
        Assert.AreEqual(LinkedIntList.TailNode.Value, 4);
        Assert.AreEqual(LinkedIntList.Count, 4);
    }

    [Test]
    public void OnLinkedListRemove_ShouldRemoveItemFromList()
    {
        // Arrange
        var nodes = new List<DSNode<int>>
        {
            new DSNode<int>(1),
            new DSNode<int>(2),
            new DSNode<int>(3),
            new DSNode<int>(4)
        };

        // Let's add the items
        foreach (DSNode<int> node in nodes)
        {
            ListService.AddItem(node, LinkedIntList, LinkedListsSupport.AddType.Head);
        }

        // Act
        ListService.RemoveItem(3, LinkedIntList);

        // Assert
        Assert.IsNull(ListService.SearchNode(3, LinkedIntList));
        Assert.IsNotNull(ListService.SearchNode(2, LinkedIntList));
    }

    [Test]
    public void OnLinkedListList_ShouldListAllNodes()
    {
        // Arrange
        var nodeValues = new List<int>();
        var nodes = new List<DSNode<int>>
        {
            new DSNode<int>(1),
            new DSNode<int>(2),
            new DSNode<int>(3),
            new DSNode<int>(4)
        };

        // Let's add the items
        foreach (DSNode<int> node in nodes)
        {
            ListService.AddItem(node, LinkedIntList, LinkedListsSupport.AddType.Head);
        }

        // Act
        foreach (int nodeValue in ListService.ListAllNodes(LinkedIntList)) nodeValues.Add(nodeValue);

        // Assert
        Assert.AreEqual(nodes.Count, nodeValues.Count);
    }

    [Test]
    public void OnLinkedListSortAdd_ShouldAddNodeSorted()
    {
        // Arrange
        var nodeValues = new List<int>();
        var nodes = new List<DSNode<int>>
        {
            new DSNode<int>(4),
            new DSNode<int>(1),
            new DSNode<int>(3),
            new DSNode<int>(2)
        };

        // Act
        foreach (DSNode<int> node in nodes)
        {
            ListService.SortAddItem(node, LinkedIntList);
        }

        // Assert
        var orderedList = new List<int>();
        int tempValue = LinkedIntList.HeadNode.Value;

        foreach (int nodeValue in LinkedIntList)
        {
            if (tempValue.CompareTo(nodeValue) > 0)
                Assert.Fail("List is not in order.");

            tempValue = nodeValue;
        }
    }

}