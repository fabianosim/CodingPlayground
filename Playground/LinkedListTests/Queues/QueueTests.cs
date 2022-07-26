using DataStructuresPlayground.Domains.Queue;
using DataStructuresPlayground.Services.Queue;
using NUnit.Framework;

namespace DataStructuresTests.Queues;

[TestFixture]
public class QueueTests
{
    private QueueService<int> queueService;
    private DataStructuresPlayground.Domains.Queue.Queue<int> queue;

    [SetUp]
    public void QueueTestsSetUp()
    {
        queueService = new QueueService<int>();
        queue = new DataStructuresPlayground.Domains.Queue.Queue<int>();
    }

    [Test]
    public void OnQueueServiceEnqueue_ShoudlEnqueueNode()
    {
        // Arrange
        QueueNode<int> node1 = new QueueNode<int>(1);
        QueueNode<int> node2 = new QueueNode<int>(2);
        QueueNode<int> node3 = new QueueNode<int>(3);
        QueueNode<int> node4 = new QueueNode<int>(4);

        // Act
        queueService.Enqueue(node1, queue);
        queueService.Enqueue(node2, queue);
        queueService.Enqueue(node3, queue);
        queueService.Enqueue(node4, queue);

        // Assert
        Assert.AreEqual(queue.Head.Value, node1.Value);
        Assert.AreEqual(queue.Tail.Value, node4.Value);
        Assert.AreEqual(queue.Count, 4);
    }

    [Test]
    public void OnQueueServiceDequeue_ShoudlDequeueNode()
    {
        // Arrange
        QueueNode<int> node1 = new QueueNode<int>(1);
        QueueNode<int> node2 = new QueueNode<int>(2);
        QueueNode<int> node3 = new QueueNode<int>(3);
        QueueNode<int> node4 = new QueueNode<int>(4);

        // Act
        // Enqueue all items first
        queueService.Enqueue(node1, queue);
        queueService.Enqueue(node2, queue);
        queueService.Enqueue(node3, queue);
        queueService.Enqueue(node4, queue);

        // Dequeue an item
        QueueNode<int> dequeuedNode;
        queueService.Dequeue(out dequeuedNode, queue);

        // Assert
        Assert.AreEqual(queue.Head.Value, node2.Value);
        Assert.AreEqual(dequeuedNode.Value, node1.Value);
        Assert.AreEqual(queue.Count, 3);
    }

    [Test]
    public void OnQueueServiceDequeue_ShoudlDequeueManyNodes()
    {
        // Arrange
        QueueNode<int> node1 = new QueueNode<int>(1);
        QueueNode<int> node2 = new QueueNode<int>(2);
        QueueNode<int> node3 = new QueueNode<int>(3);
        QueueNode<int> node4 = new QueueNode<int>(4);

        // Act
        // Enqueue all items first
        queueService.Enqueue(node1, queue);
        queueService.Enqueue(node2, queue);
        queueService.Enqueue(node3, queue);
        queueService.Enqueue(node4, queue);

        // Dequeue an item
        QueueNode<int> dequeuedNode;
        queueService.Dequeue(out dequeuedNode, queue);
        queueService.Dequeue(out dequeuedNode, queue);
        queueService.Dequeue(out dequeuedNode, queue);

        // Assert
        Assert.AreEqual(queue.Head.Value, node4.Value);
        Assert.AreEqual(dequeuedNode.Value, node3.Value);
        Assert.AreEqual(queue.Count, 1);
    }
}