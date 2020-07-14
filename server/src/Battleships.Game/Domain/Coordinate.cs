namespace Battleships.Game.Domain
{
    using System;

    public readonly struct Coordinate
    {
        public Coordinate(char row, byte col)
        {
            if (char.IsLower(row))
            {
                throw new NotSupportedException("Only upper characters are valid");
            }

            if (col == 0)
            {
                throw new NotSupportedException("Invalid column number");
            }

            Row = row;
            Col = col;
        }

        public char Row { get; }

        public byte Col { get; }
    }
}
