namespace Battleships.Console
{
    using System;
    using Battleships.Game;

    public class Program
    {
        public static void Main(string[] args)
        {
            var game = GameBoard.CreateStandardGame();

            Console.WriteLine("Standard game started");

            Console.WriteLine("Now you may enter target to shoot. For instance: 'a10'. Enter 'q' to exit program");

            while (true)
            {
                Console.Write("Target: ");
                var coordinatesText = Console.ReadLine();

                if (coordinatesText.ToUpper() == "Q")
                {
                    break;
                }

                if (!Coordinate.TryParse(coordinatesText, out var coordinate))
                {
                    continue;
                }

                var result = game.Shoot(coordinate);

                Console.WriteLine($"{coordinate}: {CreateResultText(result)}");

                if (game.IsWon)
                {
                    Console.WriteLine("Congratulations! You've won");
                    break;
                }
            }
        }

        private static string CreateResultText(ShootResult result)
        {
            var text = result.IsHit ? "Hit" : "Miss";

            if (!string.IsNullOrWhiteSpace(result.SankedShip))
            {
                text += $" ({result.SankedShip} sanked)";
            }

            return text;
        }
    }
}
