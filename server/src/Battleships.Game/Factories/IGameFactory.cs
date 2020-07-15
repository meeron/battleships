namespace Battleships.Game.Factories
{
    using Battleships.Game.Domain;

    public interface IGameFactory
    {
        IGame Create(string mode);
    }
}
