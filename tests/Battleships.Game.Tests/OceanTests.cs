namespace Battleships.Game.Test
{
    using FluentAssertions;
    using Xunit;

    public class OceanTests
    {
        [Fact]
        public void PlaceShip_WithOutsideCoordinates_ShouldBeFalse()
        {
            // Arrange
            var start = new Coordinate('B', 15);
            var ocean = new Ocean(4, 1);

            // Act
            var result = ocean.PlaceShip(Ship.CreateDestroyer(), start, ShipDirection.Horizontal);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void PlaceShip_MaximumCapacityReached_ShouldBeFalse()
        {
            // Arrange
            var ocean = new Ocean(4, 1);
            ocean.PlaceShip(Ship.CreateDestroyer(), new Coordinate('A', 1), ShipDirection.Horizontal);

            // Act
            var result = ocean.PlaceShip(Ship.CreateDestroyer(), new Coordinate('B', 2), ShipDirection.Horizontal);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void PlaceShip_NewShipShouldBeInTheOcean()
        {
            // Arrange
            var ship = Ship.CreateDestroyer();
            var ocean = new Ocean(4, 1);

            // Act
            ocean.PlaceShip(ship, new Coordinate('A', 1), ShipDirection.Horizontal);

            // Assert
            ocean.ShipsCount.Should().Be(1);
            ocean.Shape.Contains(ship.Shape).Should().BeTrue();
        }

        [Fact]
        public void PlaceShip_TwoShipsOverlapEachOther_ShouldReturnNull()
        {
            // Arrange
            var ocean = new Ocean(4, 2);
            ocean.PlaceShip(Ship.CreateDestroyer(), new Coordinate('A', 1), ShipDirection.Horizontal);

            // Act
            var result = ocean.PlaceShip(Ship.CreateDestroyer(), new Coordinate('A', 1), ShipDirection.Vertical);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void PlaceShip_AtRandomPosition()
        {
            // Arrange
            var ocean = new Ocean(10, 4);

            // Act
            var result1 = ocean.PlaceShip(Ship.CreateDestroyer());
            var result2 = ocean.PlaceShip(Ship.CreateDestroyer());
            var result3 = ocean.PlaceShip(Ship.CreateDestroyer());

            // Assert
            result1.Should().BeTrue();
            result2.Should().BeTrue();
            result3.Should().BeTrue();
        }

        [Fact]
        public void FindShip()
        {
            // Arrange
            var ocean = new Ocean(4, 2);
            var ship = Ship.CreateDestroyer();
            ocean.PlaceShip(ship, new Coordinate('A', 1), ShipDirection.Horizontal);

            // Act
            var result1 = ocean.FindShip(ship.Shape.End);
            var result2 = ocean.FindShip(ocean.Shape.End);

            // Assert
            result1.Should().Be(ship);
            result2.Should().BeNull();
        }
    }
}
