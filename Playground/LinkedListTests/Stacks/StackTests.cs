using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DataStructuresPlayground.Services.Stack;
using DataStructuresPlayground.Domains.Queue;
using DataStructuresPlayground.Domains.Stack;

namespace DataStructuresTests.Stacks
{
    [TestFixture]
    public class StackTests
    {
        private StackService<int> stackService { get; set; }
        private DataStructuresPlayground.Domains.Stack.Stack<int> stack { get; set; }

        [SetUp]
        public void SetUp()
        {
            stackService = new StackService<int>();
            stack = new DataStructuresPlayground.Domains.Stack.Stack<int>();
        }

        [Test]
        public void OnStackUp_ShouldStackUpNode()
        {
            // Arrange
            QueueNode<int> node = new QueueNode<int>(1);
            QueueNode<int> node2 = new QueueNode<int>(2);
            QueueNode<int> node3 = new QueueNode<int>(3);
            QueueNode<int> node4 = new QueueNode<int>(4);

            // Act
            stackService.StackUp(node, stack);
            stackService.StackUp(node2, stack);
            stackService.StackUp(node3, stack);
            stackService.StackUp(node4, stack);

            // Assert
            Assert.AreEqual(4, stack.Count);
            Assert.AreEqual(node4.Value, stack.Head.Value);
        }

        [Test]
        public void OnUnstack_ShouldUnstackNode()
        {
            // Arrange
            QueueNode<int> node = new QueueNode<int>(1);
            QueueNode<int> node2 = new QueueNode<int>(2);
            QueueNode<int> node3 = new QueueNode<int>(3);
            QueueNode<int> node4 = new QueueNode<int>(4);

            // Act
            stackService.StackUp(node, stack);
            stackService.StackUp(node2, stack);
            stackService.StackUp(node3, stack);
            stackService.StackUp(node4, stack);

            // Unstack some nodes
            stackService.Unstack(out _, stack);
            stackService.Unstack(out _, stack);
            stackService.Unstack(out _, stack);

            // Assert
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(node.Value, stack.Head.Value);

        }

        [Test]
        public void OnUnstackEmptyStack_ShouldNotUnstackNode()
        {
            // Arrange and Act
            stackService.Unstack(out _, stack);
            stackService.Unstack(out _, stack);
            stackService.Unstack(out _, stack);

            stackService.StackUp(new QueueNode<int>(1), stack);
            stackService.StackUp(new QueueNode<int>(2), stack);

            stackService.Unstack(out _, stack);
            stackService.Unstack(out _, stack);
            stackService.Unstack(out _, stack);

            // Assert
            Assert.AreEqual(0, stack.Count);
        }
    }
}
