namespace Battleships.Game.Factories
{
    using Battleships.Game.Domain;

    public interface IGameFactory
    {
        GameBase Create(string mode);
    }
}
