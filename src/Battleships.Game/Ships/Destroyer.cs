namespace Battleships.Game.Ships
{
    public class Destroyer : Ship
    {
        protected override int HitsToSink => 3;

        protected override int Size => 4;
    }
}
