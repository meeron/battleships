namespace Battleships.Game.Tests
{
    using FluentAssertions;
    using NSubstitute;
    using Xunit;

    public class GameBaseTests
    {
        [Fact]
        public void Shoot_ShipFoundAtCoordinatesAndSanked_ShouldReturnHit()
        {
            // Arrange
            var coordinate = new Coordinate('A', 1);
            var ship = Ship.CreateBattletship();

            var ocean = new Ocean(10, 1);
            ocean.PlaceShip(ship, coordinate, ShipDirection.Horizontal);

            var game = new GameBoard(ocean);

            // Act
            var result = game.Shoot(coordinate);

            // Assert
            result.IsHit.Should().BeTrue();
        }

        [Fact]
        public void Shoot_SameCoordinate_ShouldNotCallFindShip()
        {
            // Arrange
            var coordinate = new Coordinate('A', 1);
            var ship = Ship.CreateBattletship();

            var ocean = new Ocean(10, 1);
            ocean.PlaceShip(ship, coordinate, ShipDirection.Horizontal);

            var game = new GameBoard(ocean);
            var expected = game.Shoot(coordinate);

            // Act
            var result = game.Shoot(coordinate);

            // Assert
            result.Should().Be(expected);
        }
    }
}
