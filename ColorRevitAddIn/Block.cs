using System.Collections.Generic;

namespace ColorRevitAddIn
{
    public sealed class Block
    {
        private readonly Dictionary<string, Level> _levels = new Dictionary<string, Level>();

        public void Add(IPart part)
        {
            if (!_levels.TryGetValue(part.Level, out var level))
            {
                level = new Level();
                _levels[part.Level] = level;
            }

            level.Add(part);
        }

        public void Process()
        {
            foreach (var level in _levels.Values)
            {
                level.Process();
            }
        }
    }
}