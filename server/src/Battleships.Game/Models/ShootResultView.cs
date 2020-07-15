namespace Battleships.Game.Models
{
    using Battleships.Game.Domain;

    public class ShootResultView
    {
        public ShootResult Result { get; set; }

        public bool IsGameWon { get; set; }
    }
}
