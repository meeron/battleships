namespace Battleships.Game
{
    using System;
    using System.Threading.Tasks;
    using Battleships.Game.Domain;

    public interface IGameStore
    {
        Task Save(GameBase game);

        Task<GameBase> Get(Guid id);
    }
}
