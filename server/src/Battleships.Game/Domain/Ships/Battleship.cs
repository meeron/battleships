namespace Battleships.Game.Domain.Ships
{
    public class Battleship : Ship
    {
        protected override int HitsToSink => 4;

        protected override int Size => 5;
    }
}
