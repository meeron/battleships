namespace Battleships.Game.Tests.Domain
{
    using System;
    using Battleships.Game.Domain;
    using FluentAssertions;
    using Xunit;

    public class CoordinateTest
    {
        [Fact]
        public void CreateWithLowerRow_ShouldThrowException()
        {
            // Act
            var ex = Assert.Throws<NotSupportedException>(() => new Coordinate('a', 1));

            // Assert
            ex.Message.Should().Be("Only upper characters are valid");
        }

        [Fact]
        public void CreateWithZeroCol_ShouldThrowException()
        {
            // Act
            var ex = Assert.Throws<NotSupportedException>(() => new Coordinate('A', 0));

            // Assert
            ex.Message.Should().Be("Invalid column number");
        }
    }
}
