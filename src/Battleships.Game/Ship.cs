namespace Battleships.Game
{
    public class Ship
    {
        private readonly int _hitsToSink;

        private readonly int _size;

        private int _hits;

        private Ship(string name, int hitsToSank, int size)
        {
            _hitsToSink = hitsToSank;
            _size = size;
            Name = name;
        }

        public bool IsSanked => _hits >= _hitsToSink;

        public string Name { get; }

        public Shape Shape { get; private set; }

        public static Ship CreateDestroyer() => new Ship("Destroyer", 4, 3);

        public static Ship CreateBattletship() => new Ship("Battletship", 4, 5);

        public void Hit()
        {
            _hits++;
        }

        public Shape SetShape(Coordinate start, ShipDirection direction)
        {
            var end = new Coordinate(
                direction == ShipDirection.Vertical ? (char)(start.Row + _size - 1) : start.Row,
                direction == ShipDirection.Horizontal ? (byte)(start.Col + _size - 1) : start.Col);

            Shape = new Shape(start, end);
            return Shape;
        }
    }
}
