namespace Battleships.Game
{
    public abstract class Ship
    {
        private int _hits;

        public bool IsSanked => _hits >= HitsToSink;

        public ShipShape Shape { get; private set; }

        public virtual string Type => GetType().Name;

        protected abstract int HitsToSink { get; }

        protected abstract int Size { get; }

        public void Hit()
        {
            _hits++;
        }

        public ShipShape SetShape(Coordinate start, ShipDirection direction) =>
            Shape ??= new ShipShape(Size, start, direction);
    }
}
