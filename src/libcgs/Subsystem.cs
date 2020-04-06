using System;

namespace Citadel
{
    /// <summary>
    /// A subsystem of the game.
    /// </summary>
    public abstract class Subsystem : IDisposable
    {
        private bool _initialized;

        /// <summary>
        /// Initializes the subsystem once the game is created.
        /// </summary>
        /// <param name="game">The game object.</param>
        public virtual bool Initialize(Game game)
        {
            if (_initialized)
            {
                throw new InvalidOperationException();
            }

            _initialized = true;
            return true;
        }

        /// <inheritdoc/>
        public abstract void Dispose();

        /// <summary>
        /// Ticks the subsystem.
        /// </summary>
        public abstract void Tick();

        protected void EnsureInitialized()
        {
            if (!_initialized)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
