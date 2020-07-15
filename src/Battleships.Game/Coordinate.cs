namespace Battleships.Game
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

        public static bool TryParse(string text, out Coordinate coordinate)
        {
            coordinate = default;

            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            var row = char.ToUpper(text[0]);

            if (!byte.TryParse(text.Substring(1, text.Length - 1), out var col))
            {
                return false;
            }

            coordinate = new Coordinate(row, col);
            return true;
        }

        public override string ToString() => $"({Row}, {Col})";
    }
}
