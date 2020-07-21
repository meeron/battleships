namespace Battleships.Game
{
    using System.Collections.Generic;
    using Battleships.Game.Interfaces;

    public abstract class GameBase
    {
        private readonly Dictionary<Coordinate, ShootResult> _shoots;

        private readonly IOcean _ocean;

        protected GameBase(IOcean ocean)
        {
            _ocean = ocean;
            _shoots = new Dictionary<Coordinate, ShootResult>();
        }

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

        protected void PlaceShip<TShip>()
            where TShip : Ship, new()
        {
            _ocean.PlaceShip<TShip>();
        }
    }
}
