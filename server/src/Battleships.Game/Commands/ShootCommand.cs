namespace Battleships.Game.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Battleships.Game.Domain;
    using Battleships.Game.Models;
    using MediatR;

    public class ShootCommand : IRequest<ShootResultView>
    {
        public Guid GameId { get; set; }

        public char Row { get; set; }

        public byte Col { get; set; }

        public class Handler : IRequestHandler<ShootCommand, ShootResultView>
        {
            private readonly IGameStore _gameStore;

            public Handler(IGameStore gameStore)
            {
                _gameStore = gameStore;
            }

            public async Task<ShootResultView> Handle(ShootCommand request, CancellationToken cancellationToken)
            {
                var game = await _gameStore.Get(request.GameId);
                if (game == null)
                {
                    throw new Exception("Game not found");
                }

                var shootResult = game.Shoot(new Coordinate(request.Row, request.Col));

                return new ShootResultView
                {
                    Result = shootResult,
                    IsGameWon = game.IsWon,
                };
            }
        }
    }
}
