using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.CrackingTheCode;

namespace PlaygroundTests
{
    [TestFixture]
    public class StacksAndQueuesTests
    {
        [Test]
        public void OnMyQueueEnqueue_ShouldEnqueueItems()
        {
            // Arrange
            MyQueue<int> queue = new MyQueue<int>();

            // Act
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            // Assert
            Assert.That(5, Is.EqualTo(queue.Size()));
        }

        [Test]
        public void OnMyQueueEnqueueAndPop_ShouldDequeueItems_ShouldShowDequeuedItems()
        {
            // Arrange
            MyQueue<int> queue = new MyQueue<int>();

            // Act
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            int value1 = queue.Dequeue();
            int value2 = queue.Dequeue();

            queue.Enqueue(5);

            int value3 = queue.Dequeue();
            int value4 = queue.Dequeue();
            int value5 = queue.Dequeue();
            int value6 = queue.Dequeue();

            // Assert
            Assert.That(1, Is.EqualTo(value1));
            Assert.That(2, Is.EqualTo(value2));
            Assert.That(3, Is.EqualTo(value3));
            Assert.That(4, Is.EqualTo(value4));
            Assert.That(5, Is.EqualTo(value5));
            Assert.That(5, Is.EqualTo(value6));
        }

        [Test]
        public void OnSortStack_ShouldSortStack()
        {
            // Arrange
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            // Act
            Stack<int> sortedStack = StacksAndQueues.SortStack(stack, out int countOperations);

            // Assert
            Assert.That(sortedStack.Pop(), Is.EqualTo(1));
            Assert.That(sortedStack.Pop(), Is.EqualTo(2));
            Assert.That(sortedStack.Pop(), Is.EqualTo(3));
            Assert.That(sortedStack.Pop(), Is.EqualTo(4));
            Assert.That(sortedStack.Pop(), Is.EqualTo(5));
            Assert.That(0, Is.LessThan(countOperations));
        }

        [Test]
        public void OnSortStack_ShouldSortBigStack()
        {
            // Arrange
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            stack.Push(5);
            stack.Push(1);
            stack.Push(2);
            stack.Push(10);
            stack.Push(8);
            stack.Push(7);
            stack.Push(6);
            stack.Push(3);
            stack.Push(9);
            stack.Push(4);
            stack.Push(999);

            // Act
            Stack<int> sortedStack = StacksAndQueues.SortStack(stack, out int countOperations);

            // Assert
            Assert.That(sortedStack.Pop(), Is.EqualTo(0));
            Assert.That(sortedStack.Pop(), Is.EqualTo(1));
            Assert.That(sortedStack.Pop(), Is.EqualTo(2));
            Assert.That(sortedStack.Pop(), Is.EqualTo(3));
            Assert.That(sortedStack.Pop(), Is.EqualTo(4));
            Assert.That(sortedStack.Pop(), Is.EqualTo(5));
            Assert.That(sortedStack.Pop(), Is.EqualTo(6));
            Assert.That(sortedStack.Pop(), Is.EqualTo(7));
            Assert.That(sortedStack.Pop(), Is.EqualTo(8));
            Assert.That(sortedStack.Pop(), Is.EqualTo(9));  
            Assert.That(sortedStack.Pop(), Is.EqualTo(10));
            Assert.That(sortedStack.Pop(), Is.EqualTo(999));
            Assert.That(0, Is.LessThan(countOperations));
        }

        [Test]
        public void OnAnimalShelterEnqueueDog_ShouldEnqueueDog()
        {
            // Arrange 
            var animalShelter = new AnimalShelter();
            
            // Act
            animalShelter.Enqueue(AnimalShelter.AnimalType.Dog);

            // Assert
            Assert.That(animalShelter.AnimalCount(), Is.GreaterThan(0));
            Assert.That(AnimalShelter.AnimalType.Dog, Is.EqualTo(animalShelter.DequeueDog().Value));
        }

        [Test]
        public void OnAnimalShelterEnqueueAnimals_ShouldDequeueDog()
        {
            // Arrange 
            var animalShelter = new AnimalShelter();

            // Act
            animalShelter.Enqueue(AnimalShelter.AnimalType.Cat);
            animalShelter.Enqueue(AnimalShelter.AnimalType.Cat);
            animalShelter.Enqueue(AnimalShelter.AnimalType.Dog);
            animalShelter.Enqueue(AnimalShelter.AnimalType.Cat);

            // Assert
            Assert.That(animalShelter.AnimalCount(), Is.GreaterThan(0));
            Assert.That(AnimalShelter.AnimalType.Dog, Is.EqualTo(animalShelter.DequeueDog().Value));
        }

        [Test]
        public void OnAnimalShelterEnqueueAnimals_ShouldDequeueCat()
        {
            // Arrange 
            var animalShelter = new AnimalShelter();

            // Act
            animalShelter.Enqueue(AnimalShelter.AnimalType.Dog);
            animalShelter.Enqueue(AnimalShelter.AnimalType.Cat);
            animalShelter.Enqueue(AnimalShelter.AnimalType.Cat);
            animalShelter.Enqueue(AnimalShelter.AnimalType.Cat);

            var cat = animalShelter.DequeueCat();

            // Assert
            Assert.That(animalShelter.AnimalCount(), Is.GreaterThan(0));
            Assert.That(cat, Is.Not.Null);
            Assert.That(AnimalShelter.AnimalType.Cat, Is.EqualTo(cat.Value));
        }

        [Test]
        public void OnAnimalShelterEnqueueAnimals_ShouldDequeueAny()
        {
            // Arrange 
            var animalShelter = new AnimalShelter();

            // Act
            animalShelter.Enqueue(AnimalShelter.AnimalType.Dog);
            animalShelter.Enqueue(AnimalShelter.AnimalType.Cat);
            animalShelter.Enqueue(AnimalShelter.AnimalType.Cat);
            animalShelter.Enqueue(AnimalShelter.AnimalType.Cat);

            var dog = animalShelter.DequeueAny();

            // Assert
            Assert.That(animalShelter.AnimalCount(), Is.GreaterThan(0));
            Assert.That(dog, Is.Not.Null);
            Assert.That(AnimalShelter.AnimalType.Dog, Is.EqualTo(dog.Value));
        }
    }
}
