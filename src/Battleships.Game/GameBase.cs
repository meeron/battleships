namespace Battleships.Game
{
    using System;
    using System.Collections.Generic;
    using Battleships.Game.Interfaces;

    public abstract class GameBase
    {
        private readonly Dictionary<Coordinate, ShootResult> _shoots;

        private readonly IOcean _ocean;

        protected GameBase(IOcean ocean)
        {
            Id = Guid.NewGuid();
            _ocean = ocean;
            _shoots = new Dictionary<Coordinate, ShootResult>();
        }

        public Guid Id { get; }

        public string Mode => GetType().Name.Replace("Game", string.Empty);

        public bool IsWon => _ocean.AllShipsSanked;

        public abstract void PlaceShips();

        public ShootResult Shoot(Coordinate coordinate)
        {
            if (_shoots.ContainsKey(coordinate))
            {
                return _shoots[coordinate];
            }

            _shoots.Add(coordinate, new ShootResult());

            var ship = _ocean.FindShip(coordinate);
            if (ship != null)
            {
                ship.Hit();

                _shoots[coordinate].IsHit = true;
                _shoots[coordinate].SankedShip = ship.IsSanked ? ship.Type : string.Empty;
            }

            return _shoots[coordinate];
        }

        protected void PlaceShips<TShip>()
            where TShip : Ship, new()
        {
            _ocean.PlaceShip<TShip>();
        }
    }
}
