namespace Battleships.Game
{
    using System;
    using System.Threading.Tasks;
    using Battleships.Game.Domain;

    public interface IGameStore
    {
        Task Save(IGame game);

        Task<IGame> Get(Guid id);
    }
}
