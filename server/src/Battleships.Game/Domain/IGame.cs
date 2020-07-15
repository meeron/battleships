namespace Battleships.Game.Domain
{
    using System;

    public interface IGame
    {
        Guid Id { get; }

        string Mode { get; }

        bool IsWon { get; }

        ShootResult Shoot(Coordinate coordinate);

        void PlaceShips();
    }
}
