namespace Battleships.Game.Startup
{
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
        }
    }
}
