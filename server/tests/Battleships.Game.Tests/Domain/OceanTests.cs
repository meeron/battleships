namespace Battleships.Game.Tests.Domain
{
    using Battleships.Game.Domain;
    using Battleships.Game.Domain.Ships;
    using FluentAssertions;
    using System.Reflection.PortableExecutable;
    using Xunit;

    public class OceanTests
    {
        [Fact]
        public void PlaceShip_WithOutsideCoordinates_ShouldReturnNull()
        {
            // Arrange
            var start = new Coordinate('B', 15);
            var ocean = new Ocean(4, 1);

            // Act
            var newShip = ocean.PlaceShip<TestShip>(start, ShipDirection.Horizontal);

            // Assert
            newShip.Should().BeNull();
        }

        [Fact]
        public void PlaceShip_MaximumCapacityReached_ShouldReturnNull()
        {
            // Arrange
            var ocean = new Ocean(4, 1);
            ocean.PlaceShip<TestShip>(new Coordinate('A', 1), ShipDirection.Horizontal);

            // Act
            var newShip = ocean.PlaceShip<TestShip>(new Coordinate('B', 2), ShipDirection.Horizontal);

            // Assert
            newShip.Should().BeNull();
        }

        [Fact]
        public void PlaceShip_NewShipShouldBeInTheOcean()
        {
            // Arrange
            var ocean = new Ocean(4, 1);

            // Act
            var ship = ocean.PlaceShip<TestShip>(new Coordinate('A', 1), ShipDirection.Horizontal);

            // Assert
            ocean.ShipsCount.Should().Be(1);
            ocean.Contains(ship.Shape).Should().BeTrue();
        }

        [Fact]
        public void PlaceShip_TwoShipsOverlapEachOther_ShouldReturnNull()
        {
            // Arrange
            var ocean = new Ocean(4, 2);
            ocean.PlaceShip<TestShip>(new Coordinate('A', 1), ShipDirection.Horizontal);

            // Act
            var newShip = ocean.PlaceShip<TestShip>(new Coordinate('A', 1), ShipDirection.Vertical);

            // Assert
            newShip.Should().BeNull();
        }

        [Fact]
        public void PlaceShip_AtRandomPosition()
        {
            // Arrange
            var ocean = new Ocean(10, 4);

            // Act
            var ship1 = ocean.PlaceShip<Destroyer>();
            var ship2 = ocean.PlaceShip<Destroyer>();
            var ship3 = ocean.PlaceShip<Battleship>();

            // Assert
            ship1.Should().NotBeNull();
            ship2.Should().NotBeNull();
            ship3.Should().NotBeNull();
        }

        [Fact]
        public void FindShip()
        {
            // Arrange
            var ocean = new Ocean(4, 2);
            var ship = ocean.PlaceShip<TestShip>(new Coordinate('A', 1), ShipDirection.Horizontal);

            // Act
            var result1 = ocean.FindShip(ship.Shape.End);
            var result2 = ocean.FindShip(ocean.End);

            // Assert
            result1.Should().Be(ship);
            result2.Should().BeNull();
        }

        public class TestShip : Ship
        {
            protected override int HitsToSink => 1;

            protected override int Size => 2;
        }
    }
}
