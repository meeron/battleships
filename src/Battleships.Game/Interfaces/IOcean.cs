namespace Battleships.Game.Interfaces
{
    public interface IOcean
    {
        bool AllShipsSanked { get; }

        Ship FindShip(Coordinate coordinate);

        bool PlaceShip(Ship ship, Coordinate start, ShipDirection direction);

        bool PlaceShip(Ship ship);
    }
}
