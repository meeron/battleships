namespace Battleships.Game
{
    public class ShipShape : Shape
    {
        public ShipShape(int size, Coordinate start, ShipDirection direction)
            : base(start, CreateEnd(size, start, direction))
        {
        }

        private static Coordinate CreateEnd(int size, Coordinate start, ShipDirection direction)
        {
            return new Coordinate(
                direction == ShipDirection.Vertical ? (char)(start.Row + size - 1) : start.Row,
                direction == ShipDirection.Horizontal ? (byte)(start.Col + size - 1) : start.Col);
        }
    }
}
