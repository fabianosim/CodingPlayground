using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Playground.CrackingTheCode;

namespace PlaygroundTests
{
    [TestFixture]
    public class ArraysAndStringTests
    {
        [Test]
        public void OnIsUnique_ShouldReturnTrue()
        {
            // Arrange
            var inputString = "abeftgu";

            // Act
            var isUnique = ArraysAndStrings.IsUnique(inputString);

            // Assert
            Assert.IsTrue(isUnique);
        }

        [Test]
        public void OnIsUnique_ShouldReturnFalse()
        {
            // Arrange
            var inputString = "fabiano";

            // Act
            var isUnique = ArraysAndStrings.IsUnique(inputString);

            // Assert
            Assert.IsFalse(isUnique);
        }

        [Test]
        public void OnIsUnique2_ShouldReturnTrue()
        {
            // Arrange
            var inputString = "abeftgu";

            // Act
            var isUnique = ArraysAndStrings.IsUnique2(inputString);

            // Assert
            Assert.IsTrue(isUnique);
        }

        [Test]
        public void OnIsUnique2_ShouldReturnFalse()
        {
            // Arrange
            var inputString = "fabiano";

            // Act
            var isUnique = ArraysAndStrings.IsUnique2(inputString);

            // Assert
            Assert.IsFalse(isUnique);
        }

        [Test]
        public void OnCheckPermutation_ShouldReturnTrue()
        {
            // Arrange
            var str1 = "fabiano";
            var str2 = "ianofab";

            // Act
            var checkPermutation = ArraysAndStrings.CheckPermutation(str1, str2);

            // Assert
            Assert.IsTrue(checkPermutation);
        }

        [Test]
        public void OnCheckPermutation_ShouldReturnFalse()
        {
            // Arrange
            var str1 = "fabiano";
            var str2 = "asdasdasd";

            // Act
            var checkPermutation = ArraysAndStrings.CheckPermutation(str1, str2);

            // Assert
            Assert.IsFalse(checkPermutation);
        }

        [Test]
        public void OnURLFyString_ShouldReturnURLString()
        {
            // Arrange
            var str1 = "Mr John Smith ";
            var targetString = "Mr%20John%20Smith%20";

            // Act
            var urlString = ArraysAndStrings.URLFyString(str1);

            // Assert
            Assert.AreEqual(urlString, targetString);
        }

        [Test]
        public void OnIsPalindromePermutation_ShouldReturnTrue()
        {
            // Arrange
            var str1 = "Tact Coa";

            // Act and Aesert

            // Assert
            Assert.IsTrue(ArraysAndStrings.IsPalindromePermutation(str1));
        }

        [Test]
        public void OnIsPalindromePermutation_ShouldReturnFalse()
        {
            // Arrange
            var str1 = "Tact Coasaa";

            // Act and Aesert

            // Assert
            Assert.IsFalse(ArraysAndStrings.IsPalindromePermutation(str1));
        }

        [Test]
        public void OnIsOneOrZeroEdit_ShouldReturnTrue()
        {
            // Arrange
            var str1 = "pales";
            var str2 = "pale";
            
            // Act and Assert
            Assert.IsTrue(ArraysAndStrings.IsOneOrZeroEdit(str1, str2));
        }

        [Test]
        public void OnIsOneOrZeroEdit_ShouldReturnFalse()
        {
            // Arrange
            var str1 = "palesasaa";
            var str2 = "pale";

            // Act and Assert
            Assert.IsFalse(ArraysAndStrings.IsOneOrZeroEdit(str1, str2));
        }

        [Test]
        public void OnIsOneOrZeroEdit2_ShouldReturnFalse()
        {
            // Arrange
            var str1 = "plae";
            var str2 = "pale";

            // Act and Assert
            Assert.IsFalse(ArraysAndStrings.IsOneOrZeroEdit(str1, str2));
        }

        [Test]
        public void OnCompressString_ShouldReturnCompressedString()
        {
            // Arrange
            var str1 = "aaabbbbddccedada";
            var strTarget = "a3b4d2c2e1d1a1d1a1";

            // Act
            var strResult = ArraysAndStrings.CompressString(str1);

            // Assert
            Assert.AreEqual(strTarget, strResult);
        }

        [Test]
        public void OnCompressString_ShouldReturnOriginalString()
        {
            // Arrange
            var str1 = "aabbccddee";

            // Act
            var strResult = ArraysAndStrings.CompressString(str1);

            // Assert
            Assert.AreEqual(strResult, str1);
        }

        [Test]
        public void OnCompressString_ShouldReturnEmptyString()
        {
            // Arrange
            var str1 = string.Empty;

            // Act
            var strResult = ArraysAndStrings.CompressString(str1);

            // Assert
            Assert.AreEqual(strResult, str1);
        }

        [Test]
        public void OnRotateMatrix_ShouldReturnRotatedMatrix()
        {
            // Arrange
            int[][] matrix = new int[][]
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12 },
                new int[] { 13, 14, 15, 16 }
            };

            // Act
            var newMatrix = ArraysAndStrings.RotateMatrix(matrix);

            // Assert
            Assert.IsNotNull(newMatrix);
        }

        [Test]
        public void OnZeroMatrix_ShouldReturnMatrixWithZeros()
        {
            // Arrange
            int[,] matrix = {
                { 1, 2, 0, 4 },
                { 0, 6, 7, 8 },
                { 9, 0, 11, 12 },
                { 13, 14, 15, 16 }
            };

            int[,] expectedMatrix = {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 16 }
            };

            // Act
            var zeroMatrix = ArraysAndStrings.ZeroMatrix(matrix);

            // Assert
            Assert.That(expectedMatrix, Is.EqualTo(zeroMatrix));
        }

        [Test]
        public void OnZeroMatrix2_ShouldReturnMatrixWithZeros()
        {
            // Arrange
            int[,] matrix = {
                { 1, 2, 0, 4 },
                { 0, 6, 7, 8 },
                { 9, 0, 11, 12 },
                { 13, 14, 15, 16 }
            };

            int[,] expectedMatrix = {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 16 }
            };

            // Act
            var zeroMatrix = ArraysAndStrings.ZeroMatrix2(matrix);

            // Assert
            Assert.That(expectedMatrix, Is.EqualTo(zeroMatrix));
        }

        [Test]
        public void OnIsSubstring_ShouldReturnTrue()
        {
            // Arrange
            var str1 = "waterbottle";
            var str2 = "erbottlewat";

            // Act
            bool isSubString = ArraysAndStrings.IsSubstring(str1, str2);

            // Assert
            Assert.IsTrue(isSubString);
        }

        [Test]
        public void OnIsSubstring_ShouldReturnFalse()
        {
            // Arrange
            var str1 = "waterbottle";
            var str2 = "erbowatasdfsafsa";

            // Act
            bool isSubString = ArraysAndStrings.IsSubstring(str1, str2);

            // Assert
            Assert.IsFalse(isSubString);
        }

        [Test]
        public void OnIsSubstring_WhenStr1IsGreaterThanStr2ShouldReturnFalse()
        {
            // Arrange
            var str1 = "waterbottle";
            var str2 = "water";

            // Act
            bool isSubString = ArraysAndStrings.IsSubstring(str1, str2);

            // Assert
            Assert.IsFalse(isSubString);
        }


    }
}
