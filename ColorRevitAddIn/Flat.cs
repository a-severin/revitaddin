using System.Collections.Generic;
using System.Linq;

namespace ColorRevitAddIn
{
    public sealed class Flat
    {
        private readonly List<IPart> _parts = new List<IPart>();

        public bool IsSemitone { get; private set; }

        public void Add(IPart part)
        {
            _parts.Add(part);
        }

        public void SetSemitone()
        {
            foreach (var part in _parts)
            {
                part.SetSemitone();
            }

            IsSemitone = true;
        }

        public string Subzone()
        {
            return _parts.FirstOrDefault()?.Subzone;
        }
    }
}