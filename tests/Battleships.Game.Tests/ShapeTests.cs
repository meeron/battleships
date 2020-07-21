namespace Battleships.Game.Test
{
    using System;
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

        [Fact]
        public void OverlapOtherShape()
        {
            // Arrange
            var shape = new TestShape('D', 1, 'D', 4);
            var otherShape = new TestShape('B', 3, 'D', 3);

            // Act
            var result = shape.Overlap(otherShape);

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
                : base(new Coordinate(startRow, startCol), new Coordinate(endRow, endCol))
            {
            }
        }
    }
}
