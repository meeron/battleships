namespace Battleships.Game
{
    using Battleships.Game.Ships;

    public class StandardGame : GameBase
    {
        private const int OceanSideSize = 10;

        private const int MaxShipsCapacity = 5;

        public StandardGame()
            : base(new Ocean(OceanSideSize, MaxShipsCapacity))
        {
        }

        public override void PlaceShips()
        {
            PlaceShips<Destroyer>();
            PlaceShips<Destroyer>();
            PlaceShips<Battleship>();
        }
    }
}
