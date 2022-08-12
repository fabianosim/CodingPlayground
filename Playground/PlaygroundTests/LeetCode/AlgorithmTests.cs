using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.LeetCode;

namespace PlaygroundTests.LeetCode
{
    [TestFixture]
    public class AlgorithmTests
    {
        [Test]
        public void OnIsIntPalindromeWithoutConversion_ShouldReturnTrue()
        {
            // Arrange
            int x = 12344321;

            // Act
            bool isPalindrome = Algorithms.IsIntPalindromeWithoutConversion(x);

            // Assert
            Assert.That(isPalindrome, Is.True);
        }

        [Test]
        public void OnIsIntPalindromeWithoutConversion_ShouldReturnFalse()
        {
            // Arrange
            int x = 129654;

            // Act
            bool isPalindrome = Algorithms.IsIntPalindromeWithoutConversion(x);

            // Assert
            Assert.That(isPalindrome, Is.False);
        }

        [Test]
        public void OnIsIntPalindrome_ShouldReturnTrue()
        {
            // Arrange
            int x = 12344321;

            // Act
            bool isPalindrome = Algorithms.IsIntPalindrome(x);

            // Assert
            Assert.That(isPalindrome, Is.True);
        }
    }
}
