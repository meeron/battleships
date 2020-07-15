namespace Battleships.Game
{
    using System;
    using System.Collections.Generic;

    public abstract class GameBase
    {
        private readonly Dictionary<Coordinate, ShootResult> _shoots;

        private readonly Ocean _ocean;

        protected GameBase(int oceanSideSize, int maxShipsCapacity)
        {
            Id = Guid.NewGuid();
            _ocean = new Ocean(oceanSideSize, maxShipsCapacity);
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
                _shoots[coordinate].SankedShip = ship.IsSanked ? ship.GetType().Name : string.Empty;
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
