using Playground.Uber;

namespace PlaygroundTests
{
    public class UberTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MockExerciseTest()
        {
            // Arrange
            int[][] trips1 = 
            {
                new [] { 2, 3, 6 },
                new [] { 1, 2, 3 }
            };
            int capacity1 = 4;

            int[][] trips2 =
            {
                new [] { 2, 3, 6 },
                new [] { 1, 2, 4 }
            };
            int capacity2 = 2;

            int[][] trips3 =
            {
                new [] { 2, 3, 6 }
            };
            int capacity3 = 2;

            int[][] trips4 =
            {
                new [] { 2, 3, 6 }
            };
            int capacity4 = 0;

            int[][] trips5 =
            {
                new [] { 2, 3, 6 },
                new [] { 1, 3, 5 },
                new [] { 5, 6, 7 }
            };
            int capacity5 = 3;

            // Act
            var testCase1 = Exercises.CanMakeAllTrips(trips1, capacity1);
            var testCase2 = Exercises.CanMakeAllTrips(trips2, capacity2);
            var testCase3 = Exercises.CanMakeAllTrips(trips3, capacity3);
            var testCase4 = Exercises.CanMakeAllTrips(trips4, capacity4);
            var testCase5 = Exercises.CanMakeAllTrips(trips5, capacity5);

            // Assert
            Assert.That(testCase1, Is.True);
            Assert.That(testCase2, Is.False);
            Assert.That(testCase3, Is.True);
            Assert.That(testCase4, Is.False);
            Assert.That(testCase5, Is.False);
        }

        [Test]
        public void OnFindHighestFrequencyNumber_ShouldReturnHighestFrequency()
        {
            // Arrange
            var elements = new int[] { 1, 2, 2, 3, 4, 4, 4, 4, 4, 5, 5, 5 };

            // Act
            int highestFrequency = Exercises.FindElementWithHighestFrequency(elements);

            // Assert
            Assert.That(highestFrequency, Is.EqualTo(4));
        }
    }
}