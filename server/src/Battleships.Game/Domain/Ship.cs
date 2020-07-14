namespace Battleships.Game.Domain
{
    public abstract class Ship
    {
        private int _hits;

        protected Ship()
        {
            _hits = 0;
        }

        public bool IsSanked => HitsToSink == _hits;

        public ShipShape Shape { get; private set; }

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
