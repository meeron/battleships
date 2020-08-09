namespace Battleships.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Battleships.Game.Interfaces;

    public class Ocean : IOcean
    {
        private static readonly Coordinate DefaultStart = new Coordinate('A', 1);

        private readonly List<Ship> _ships;

        private readonly int _maxCapacity;

        public Ocean(int sideSize, int maxCapacity)
        {
            var end = new Coordinate((char)(DefaultStart.Row + sideSize - 1), (byte)(DefaultStart.Col + sideSize - 1));

            _maxCapacity = maxCapacity;
            _ships = new List<Ship>();
            Shape = new Shape(DefaultStart, end);
        }

        public Shape Shape { get; }

        public int ShipsCount => _ships.Count;

        public bool AllShipsSanked => _ships.All(s => s.IsSanked);

        public bool PlaceShip(Ship ship, Coordinate start, ShipDirection direction)
        {
            if (ShipsCount == _maxCapacity)
            {
                return false;
            }

            if (!Shape.Contains(ship.SetShape(start, direction)))
            {
                return false;
            }

            if (_ships.Any(s => s.Shape.Overlap(ship.Shape)))
            {
                return false;
            }

            _ships.Add(ship);

            return true;
        }

        public bool PlaceShip(Ship ship)
        {
            var random = new Random();
            var count = 0;
            var isPlaced = false;

            while (isPlaced == false)
            {
                count++;
                if (count >= 100)
                {
                    return false;
                }

                var row = (char)random.Next(Shape.Start.Row, Shape.End.Row + 1);
                var col = (byte)random.Next(Shape.Start.Col, Shape.End.Col + 1);
                var direction = (ShipDirection)random.Next((int)ShipDirection.Horizontal, (int)ShipDirection.Vertical + 1);

                isPlaced = PlaceShip(ship, new Coordinate(row, col), direction);
            }

            return isPlaced;
        }

        public Ship FindShip(Coordinate coordinate) => _ships.SingleOrDefault(s => s.Shape.Contains(coordinate));
    }
}
