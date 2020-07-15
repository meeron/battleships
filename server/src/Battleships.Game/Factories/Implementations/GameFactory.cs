namespace Battleships.Game.Factories.Implementations
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Battleships.Game.Domain;

    public class GameFactory : IGameFactory
    {
        public IGame Create(string mode)
        {
            var gameType = Assembly.GetExecutingAssembly().DefinedTypes
                .SingleOrDefault(t => t.Name == $"{mode}Game" && t.BaseType == typeof(GameBase));

            if (gameType == null)
            {
                return null;
            }

            return Activator.CreateInstance(gameType) as IGame;
        }
    }
}
