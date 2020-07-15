namespace Battleships.Game.Startup
{
    using System.Reflection;
    using Battleships.Game.Factories;
    using Battleships.Game.Factories.Implementations;
    using Battleships.Presistance;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public static class Startup
    {
        public static void AddGame(this IServiceCollection services, bool isDevelopment)
        {
            services.AddLogging(config =>
            {
                config.ClearProviders();

                if (isDevelopment)
                {
                    config.AddConsole();
                }
            });

            services.AddSingleton<IGameFactory, GameFactory>();
            services.AddSingleton<IGameStore, GameStore>();

            services.AddMediatR(Assembly.GetAssembly(typeof(GameFactory)));
        }
    }
}
