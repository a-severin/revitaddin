using System.Collections.Generic;
using System.Linq;

namespace ColorRevitAddIn
{
    public sealed class Flat
    {
        private readonly List<Part> _parts = new List<Part>();

        public bool IsSemitone { get; private set; }

        public void Add(Part part)
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