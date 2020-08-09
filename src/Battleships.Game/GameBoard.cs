namespace Battleships.Game
{
    using System.Collections.Generic;

    public class GameBoard
    {
        private readonly Dictionary<Coordinate, ShootResult> _shoots;

        private readonly Ocean _ocean;

        public GameBoard(Ocean ocean)
        {
            _ocean = ocean;
            _shoots = new Dictionary<Coordinate, ShootResult>();
        }

        public bool IsWon => _ocean.AllShipsSanked;

        public static GameBoard CreateStandardGame()
        {
            var ocean = new Ocean(10, 5);
            ocean.PlaceShip(Ship.CreateDestroyer());
            ocean.PlaceShip(Ship.CreateDestroyer());
            ocean.PlaceShip(Ship.CreateBattletship());

            return new GameBoard(ocean);
        }

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
                _shoots[coordinate].SankedShip = ship.IsSanked ? ship.Name : string.Empty;
            }

            return _shoots[coordinate];
        }
    }
}
