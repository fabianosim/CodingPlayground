using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.CrackingTheCode;

namespace PlaygroundTests
{
    [TestFixture]
    public class RecursionDynamicProgTests
    {
        [Test]
        public void OnTripleStep_ShouldReturnWaysToClimbStaircase()
        {
            // Arrange
            int staircaseSteps = 5;
            int expectedWays = 13;

            // Act
            int waysToClimb = RecursionDynamicProg.TripleStep(staircaseSteps);

            // Assert
            Assert.That(expectedWays, Is.EqualTo(waysToClimb));
        }

        [Test]
        public void OnTripleStepDynamic_ShouldReturnWaysToClimbStaircase()
        {
            // Arrange
            int staircaseSteps = 5;
            int expectedWays = 13;

            // Act
            int waysToClimb = RecursionDynamicProg.TripleStepDynamic(staircaseSteps);

            // Assert
            Assert.That(expectedWays, Is.EqualTo(waysToClimb));
        }

        [Test]
        public void OnTripleStepDynamicIterative_ShouldReturnWaysToClimbStaircase()
        {
            // Arrange
            int staircaseSteps = 5;
            int expectedWays = 13;

            // Act
            int waysToClimb = RecursionDynamicProg.TripleStepDynamicIterative(staircaseSteps);

            // Assert
            Assert.That(expectedWays, Is.EqualTo(waysToClimb));
        }

        [Test]
        public void OnFindRobotPath_ShouldReachBottomRightEnd()
        {
            // Arrange
            var validPath = new List<Tuple<int, int>>();
            int[][] grid =
            {
                new [] { 0, 1, 0 },
                new [] { 0, 0, 0 },
                new [] { 0, 1, 0 }
            };

            // Act
            validPath = RecursionDynamicProg.FindRobotPath(grid);

            // Assert
            Assert.Contains(new Tuple<int, int>(0, 0), validPath);
        }
    }
}
