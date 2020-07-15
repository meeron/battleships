namespace Battleships.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Battleships.Game.Interfaces;

    public class Ocean : Shape, IOcean
    {
        private static readonly Coordinate DefaultStart = new Coordinate('A', 1);

        private readonly List<Ship> _ships;

        private readonly int _maxCapacity;

        public Ocean(int sideSize, int maxCapacity)
            : base(DefaultStart, CreateEnd(sideSize))
        {
            _maxCapacity = maxCapacity;
            _ships = new List<Ship>();
        }

        public int ShipsCount => _ships.Count;

        public bool AllShipsSanked => _ships.All(s => s.IsSanked);

        public Ship PlaceShip<TShip>(Coordinate start, ShipDirection direction)
            where TShip : Ship, new()
        {
            if (ShipsCount == _maxCapacity)
            {
                return null;
            }

            var ship = new TShip();

            if (!Contains(ship.SetShape(start, direction)))
            {
                return null;
            }

            if (_ships.Any(s => s.Shape.Overlap(ship.Shape)))
            {
                return null;
            }

            _ships.Add(ship);

            return ship;
        }

        public Ship PlaceShip<TShip>()
            where TShip : Ship, new()
        {
            var random = new Random();
            Ship newShip = null;
            var count = 0;

            while (newShip == null)
            {
                count++;
                if (count >= 100)
                {
                    return null;
                }

                var row = (char)random.Next(Start.Row, End.Row + 1);
                var col = (byte)random.Next(Start.Col, End.Col + 1);
                var direction = (ShipDirection)random.Next((int)ShipDirection.Horizontal, (int)ShipDirection.Vertical + 1);

                newShip = PlaceShip<TShip>(new Coordinate(row, col), direction);
            }

            return newShip;
        }

        public Ship FindShip(Coordinate coordinate) => _ships.SingleOrDefault(s => s.Shape.Contains(coordinate));

        private static Coordinate CreateEnd(int sideSize) =>
            new Coordinate((char)(DefaultStart.Row + sideSize - 1), (byte)(DefaultStart.Col + sideSize - 1));
    }
}
