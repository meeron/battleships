namespace Battleships.Game.Tests.Domain
{
    using System;
    using Battleships.Game.Domain;
    using FluentAssertions;
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

        public class TestShip : Ship
        {
            public TestShip()
                : base()
            {
            }

            protected override int HitsToSink => 1;

            protected override int Size => 2;
        }
    }
}
