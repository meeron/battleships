namespace Battleships.Console
{
    using System;
    using System.Threading.Tasks;
    using Battleships.Game.Commands;
    using Battleships.Game.Domain;
    using Battleships.Game.Startup;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddGame(true)
                .BuildServiceProvider();

            var mediator = serviceProvider.GetService<IMediator>();

            var gameSession = await mediator.Send(new CreateGameSessionCommand { GameMode = "Standard" });
            Console.WriteLine("Standard game started");

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Now you may enter target to shoot. For instance: 'a10'. Enter 'q' to exit program");
            Console.WriteLine(Environment.NewLine);

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

                var result = await mediator.Send(new ShootCommand
                {
                    GameId = gameSession.Id,
                    Row = coordinate.Row,
                    Col = coordinate.Col,
                });

                Console.WriteLine($"{coordinate}: {CreateResultText(result.Result)}");

                if (result.IsGameWon)
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
