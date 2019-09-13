using System.Collections.Generic;
using System.Linq;

namespace ColorRevitAddIn
{
    public sealed class Level
    {
        private readonly Dictionary<string, Flat> _flats = new Dictionary<string, Flat>();

        public void Add(Part part)
        {
            if (!_flats.TryGetValue(part.Zone, out var flat))
            {
                flat = new Flat();
                _flats[part.Zone] = flat;
            }

            flat.Add(part);
        }

        public void Process()
        {
            var flats = _flats.OrderBy(_ => _.Key).Select(_ => _.Value).ToList();
            for (var i = 0; i < flats.Count; i++)
            {
                var flat = flats[i];
                var nextFlat = flats[(i + 1) % flats.Count];
                if (!flat.IsSemitone && nextFlat.Subzone() == flat.Subzone())
                {
                    nextFlat.SetSemitone();
                }
            }
        }
    }
}