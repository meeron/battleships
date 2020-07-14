namespace Battleships.Game.Tests.Domain
{
    using System;
    using Battleships.Game.Domain;
    using FluentAssertions;
    using Xunit;

    public class ShapeTests
    {
        [Fact]
        public void EndIsGreaterThanStart_ShouldThrowException()
        {
            // Arrange
            var start = new Coordinate('B', 3);
            var end = new Coordinate('A', 1);

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => new TestShape(start, end));

            // Assert
            ex.Message.Should().Be("Start should be greater than end");
        }

        [Theory]
        [InlineData('A', 1, 'D', 4, 16)]
        [InlineData('A', 1, 'J', 10, 100)]
        [InlineData('B', 3, 'C', 3, 2)]
        [InlineData('D', 1, 'D', 3, 3)]
        public void AreaIsProperlyCalculated(char startRow, byte startCol, char endRow, byte endCol, int expectedArea)
        {
            // Act
            var shape = new TestShape(startRow, startCol, endRow, endCol);

            // Assert
            shape.Area.Should().Be(expectedArea);
        }

        [Theory]
        [InlineData('D', 5, false)]
        [InlineData('C', 2, true)]
        public void ContainsCoordinate(char row, byte col, bool contains)
        {
            // Arrange
            var shape = new TestShape('A', 1, 'D', 4);

            // Act
            var result = shape.Contains(new Coordinate(row, col));

            // Assert
            result.Should().Be(contains);
        }

        [Fact]
        public void ContainsOtherShape()
        {
            // Arrange
            var shape = new TestShape('A', 1, 'D', 4);
            var otherShape = new TestShape('D', 1, 'D', 3);

            // Act
            var result = shape.Contains(otherShape);

            // Assert
            result.Should().BeTrue();
        }

        private class TestShape : Shape
        {
            public TestShape(Coordinate start, Coordinate end)
                : base(start, end)
            {
            }

            public TestShape(char startRow, byte startCol, char endRow, byte endCol)
                : base(startRow, startCol, endRow, endCol)
            {
            }
        }
    }
}
