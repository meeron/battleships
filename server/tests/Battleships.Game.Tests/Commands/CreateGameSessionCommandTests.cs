namespace Battleships.Game.Tests.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Battleships.Game.Commands;
    using Battleships.Game.Domain;
    using Battleships.Game.Factories;
    using FluentAssertions;
    using NSubstitute;
    using NSubstitute.ExceptionExtensions;
    using Xunit;

    public class CreateGameSessionCommandTests
    {
        private readonly IGameFactory _mockGameFactory;

        private readonly IGameStore _mockGameStore;

        private readonly CreateGameSessionCommand.Handler _handler;

        public CreateGameSessionCommandTests()
        {
            _mockGameFactory = Substitute.For<IGameFactory>();
            _mockGameStore = Substitute.For<IGameStore>();

            _handler = new CreateGameSessionCommand.Handler(
                _mockGameFactory,
                _mockGameStore);
        }

        [Fact]
        public async Task GivenWrogGameMode_ShouldThrowException()
        {
            // Arrange
            const string mode = "NotSupportedMode";

            var cmd = new CreateGameSessionCommand
            {
                GameMode = mode,
            };

            _mockGameFactory.Create(mode).Returns((IGame)null);

            // Act
            var result = await Assert.ThrowsAsync<NotSupportedException>(() => _handler.Handle(cmd, CancellationToken.None));

            // Arrange
            result.Message.Should().Be($"{mode} game is not supported");

            await _mockGameStore.DidNotReceive().Save(Arg.Any<GameBase>());
        }

        [Fact]
        public async Task GivenProperMode_ShouldCreateGameSessionWithProperMode()
        {
            // Arrange
            const string mode = "Test";

            var cmd = new CreateGameSessionCommand
            {
                GameMode = mode,
            };
            var game = Substitute.For<IGame>();
            game.Mode.Returns(mode);

            _mockGameFactory.Create(mode).Returns(game);

            // Act
            var result = await _handler.Handle(cmd, CancellationToken.None);

            // Assert
            result.Mode.Should().Be(mode);

            await _mockGameStore.Received(1).Save(game);
            game.Received(1).PlaceShips();
        }
    }
}
