namespace Battleships.Game.Domain
{
    using System;

    public abstract class GameBase
    {
        protected GameBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public string Mode => GetType().Name.Replace("Game", string.Empty);
    }
}
