namespace Battleships.Game.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Battleships.Game.Factories;
    using Battleships.Game.Models;
    using MediatR;

    public class CreateGameSessionCommand : IRequest<GameSessionView>
    {
        public string GameMode { get; set; }

        public class Handler : IRequestHandler<CreateGameSessionCommand, GameSessionView>
        {
            private readonly IGameFactory _gameFactory;

            private readonly IGameStore _gameStore;

            public Handler(IGameFactory gameFactory, IGameStore gameStore)
            {
                _gameFactory = gameFactory;
                _gameStore = gameStore;
            }

            public async Task<GameSessionView> Handle(CreateGameSessionCommand request, CancellationToken cancellationToken)
            {
                var game = _gameFactory.Create(request.GameMode);

                await _gameStore.Save(game);

                return new GameSessionView
                {
                    Id = game.Id,
                    Mode = game.Mode,
                };
            }
        }
    }
}
