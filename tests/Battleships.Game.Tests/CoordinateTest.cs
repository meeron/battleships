namespace Battleships.Game.Test
{
    using System;
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

        [Theory]
        [InlineData("a5", true)]
        [InlineData("B12", true)]
        [InlineData("1A", false)]
        [InlineData("some text", false)]
        public void TryParse(string text, bool expectedResult)
        {
            // Act
            var result = Coordinate.TryParse(text, out _);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
