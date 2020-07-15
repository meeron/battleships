namespace Battleships.Presistance
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Battleships.Game;
    using Battleships.Game.Domain;

    public class GameStore : IGameStore
    {
        private readonly Dictionary<Guid, IGame> _games;

        public GameStore()
        {
            _games = new Dictionary<Guid, IGame>();
        }

        public async Task<IGame> Get(Guid id)
        {
            if (!_games.TryGetValue(id, out var game))
            {
                return null;
            }

            await Task.CompletedTask;
            return game;
        }

        public async Task Save(IGame game)
        {
            if (!_games.ContainsKey(game.Id))
            {
                _games.Add(game.Id, null);
            }

            _games[game.Id] = game;

            await Task.CompletedTask;
        }
    }
}
