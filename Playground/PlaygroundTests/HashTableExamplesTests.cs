using System.Collections.Immutable;
using NUnit.Framework;
using Playground.CrackingTheCode;

namespace PlaygroundTests;

[TestFixture]
public class HashTableExamplesTests
{
    [Test]
    public void OnCommonElements_ShouldReturnCommonElements()
    {
        // Arrange
        int[] a = { 1, 4, 6, 8, 3, 10, 9, 3 };
        int[] b = { 10, 20, 5, 3, 6, 15 };
        int[] numsInCommon = { 10, 3, 6 };

        // Act
        int[] commonElements = HashTableExamples.ElementsInCommon(a, b);
        var orderedCommonElements = commonElements.OrderBy(_ => _);
        var orderedNumsInCommon = numsInCommon.OrderBy(_ => _);

        // Assert
        Assert.That(orderedNumsInCommon, Is.EqualTo(orderedCommonElements));
    }
    
}