using System;
using System.Collections.Generic;
using System.Linq;
using SdlSharp;

namespace Citadel
{
    /// <summary>
    /// The game itself.
    /// </summary>
    public sealed class Game : IDisposable
    {
        private readonly List<Subsystem> _subsystems;
        private readonly Application _application;

        /// <summary>
        /// Creates a new game.
        /// </summary>
        /// <param name="configurations">Configurations for the desired subsystems.</param>
        public Game(IEnumerable<Configuration> configurations)
        {
            var sdlConfiguration = new SdlConfiguration();
            _subsystems = configurations.Select(c => c.Create(sdlConfiguration)).ToList();
            _application = new Application(sdlConfiguration.Subsystems, sdlConfiguration.ImageFormats);
        }

        public bool Initialize() => _subsystems.All(s => s.Initialize(this));

        /// <summary>
        /// Runs the game.
        /// </summary>
        public void Run()
        {
            while (_application.DispatchEvent())
            {
                foreach (var subsystem in _subsystems)
                {
                    subsystem.Tick();
                }
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            foreach (var subsystem in _subsystems)
            {
                subsystem.Dispose();
            }
        }
    }
}
