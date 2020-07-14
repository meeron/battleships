namespace Battleships.Game.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public class Ocean : Shape
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

            //if (_ships.Any(s => s.Shape.Overlap(ship.Shape)))
            //{
            //    return null;
            //}

            _ships.Add(ship);

            return ship;
        }

        private static Coordinate CreateEnd(int sideSize) =>
            new Coordinate((char)(DefaultStart.Row + sideSize - 1), (byte)(DefaultStart.Col + sideSize - 1));
    }
}
