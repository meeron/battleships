namespace Battleships.Game.Interfaces
{
    public interface IOcean
    {
        bool AllShipsSanked { get; }

        Ship FindShip(Coordinate coordinate);

        Ship PlaceShip<TShip>(Coordinate start, ShipDirection direction)
             where TShip : Ship, new();

        Ship PlaceShip<TShip>()
             where TShip : Ship, new();
    }
}
