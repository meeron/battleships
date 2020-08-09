namespace Battleships.Game
{
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
            _ocean.PlaceShip(Ship.CreateDestroyer());
            _ocean.PlaceShip(Ship.CreateDestroyer());
            _ocean.PlaceShip(Ship.CreateBattletship());
        }
    }
}
