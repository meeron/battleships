namespace Battleships.Game.Domain.Ships
{
    public class Destroyer : Ship
    {
        public Destroyer()
            : base()
        {
        }

        protected override int HitsToSink => 2;

        protected override int Size => 4;
    }
}
