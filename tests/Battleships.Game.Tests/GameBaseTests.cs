namespace Battleships.Game.Tests
{
    using Battleships.Game.Interfaces;
    using FluentAssertions;
    using NSubstitute;
    using Xunit;

    public class GameBaseTests
    {
        [Fact]
        public void Shoot_ShipFoundAtCoordinatesAndSanked_ShouldReturnHit()
        {
            // Arrange
            const string shipName = "Typhoon class";

            var mockOcean = Substitute.For<IOcean>();
            var mockShip = Substitute.For<Ship>();

            var game = new TestGame(mockOcean);
            var coordinate = new Coordinate('A', 1);

            mockOcean.FindShip(coordinate).Returns(mockShip);
            mockShip.Name.Returns(shipName);

            // Act
            var result = game.Shoot(coordinate);

            // Assert
            result.IsHit.Should().BeTrue();
            result.SankedShip.Should().Be(shipName);
        }

        [Fact]
        public void Shoot_SameCoordinate_ShouldNotCallFindShip()
        {
            // Arrange
            var mockOcean = Substitute.For<IOcean>();

            var game = new TestGame(mockOcean);
            var coordinate = new Coordinate('A', 1);

            var expected = game.Shoot(coordinate);

            // Act
            var result = game.Shoot(coordinate);

            // Assert
            result.Should().Be(expected);

            mockOcean.Received(1).FindShip(Arg.Any<Coordinate>());
        }

        public class TestGame : GameBase
        {
            public TestGame(IOcean ocean)
                : base(ocean)
            {
            }

            public override void PlaceShips()
            {
            }
        }
    }
}
