using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground;

namespace PlaygroundTests
{
    [TestFixture]
    public class PlaygroundTests
    {
        [Test]
        public void OnPiggyBankSets_ShouldReturnValidSet()
        {
            // Arrange
            var piggyBankSet = new int[] { 1, 2, 3, 4 };
            var legoPrice = 6;
            var playground = new PlaygroundExercises();

            // Act
            var piggyBanks = playground.PiggyBankIDs(piggyBankSet, legoPrice);

            // Assert
            Assert.That(piggyBanks.Length, Is.EqualTo(2));
            Assert.That(piggyBanks[0], Is.EqualTo(1)); //index 1
            Assert.That(piggyBanks[1], Is.EqualTo(3)); // index 3
        }

        [Test]
        public void OnPiggyBankSets_ForABigArray_ShouldReturnValidSet()
        {
            // Arrange
            var piggyBankSet = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 22, 55, 33, 14, 20 };
            var legoPrice = 65;
            var playground = new PlaygroundExercises();

            // Act
            var piggyBanks = playground.PiggyBankIDs(piggyBankSet, legoPrice);

            // Assert
            Assert.That(piggyBanks.Length, Is.EqualTo(2));
            Assert.That(piggyBanks[0], Is.EqualTo(9)); //index 11
            Assert.That(piggyBanks[1], Is.EqualTo(11)); // index 3
        }

        [Test]
        public void OnPiggyBankSets_EdgeCase1_ShouldReturnValidSet()
        {
            // Arrange
            var piggyBankSet = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var legoPrice = 10;
            var playground = new PlaygroundExercises();

            // Act
            var piggyBanks = playground.PiggyBankIDs(piggyBankSet, legoPrice);

            // Assert
            Assert.That(piggyBanks.Length, Is.EqualTo(2));
            Assert.That(piggyBanks[0], Is.EqualTo(0)); //index 0
            Assert.That(piggyBanks[1], Is.EqualTo(10)); // index 10
        }

        [Test]
        public void OnPiggyBankSets_InOptimizedSolution_ShouldReturnValidSet()
        {
            // Arrange
            var piggyBankSet = new int[] { 1, 2, 3, 4 };
            var legoPrice = 6;
            var playground = new PlaygroundExercises();

            // Act
            var piggyBanks = playground.PiggyBankIDsLinear(piggyBankSet, legoPrice);

            // Assert
            Assert.That(piggyBanks.Length, Is.EqualTo(2));
            Assert.That(piggyBanks[0], Is.EqualTo(1)); //index 1
            Assert.That(piggyBanks[1], Is.EqualTo(3)); // index 3
        }
    }
}
