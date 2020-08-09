namespace Battleships.Game
{
    using System;

    public class Shape
    {
        public Shape(Coordinate start, Coordinate end)
        {
            if (start.Row > end.Row || start.Col > end.Col)
            {
                throw new InvalidOperationException("Start should be greater than end");
            }

            Start = start;
            End = end;
        }

        public Coordinate Start { get; }

        public Coordinate End { get; }

        public bool Contains(Coordinate coordinate)
        {
            return coordinate.Row >= Start.Row
                && coordinate.Row <= End.Row
                && coordinate.Col >= Start.Col
                && coordinate.Col <= End.Col;
        }

        public bool Contains(Shape otherShape) => Contains(otherShape.Start) && Contains(otherShape.End);

        public bool Overlap(Shape otherShape)
        {
            // TODO: Find more efficient solution
            for (byte col = Start.Col; col <= End.Col; col++)
            {
                for (char row = Start.Row; row <= End.Row; row++)
                {
                    if (otherShape.Contains(new Coordinate(row, col)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
