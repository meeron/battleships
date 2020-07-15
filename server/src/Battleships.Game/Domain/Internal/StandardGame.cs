namespace Battleships.Game.Domain.Internal
{
    using Battleships.Game.Domain.Ships;

    internal class StandardGame : GameBase
    {
        private const int OceanSideSize = 10;

        private const int MaxShipsCapacity = 5;

        public StandardGame()
            : base(OceanSideSize, MaxShipsCapacity)
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
