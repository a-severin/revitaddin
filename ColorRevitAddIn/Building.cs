using System;
using System.Collections.Generic;
using System.Linq;

namespace ColorRevitAddIn
{
    public sealed class Building
    {
        private readonly Dictionary<string, Block> _blocks = new Dictionary<string, Block>();

        public void Add(IEnumerable<Part> parts)
        {
            foreach (var part in parts)
            {
                if (!_blocks.TryGetValue(part.Block, out var block))
                {
                    block = new Block();
                    _blocks[part.Block] = block;
                }

                block.Add(part);
            }
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _blocks.Select(_ => $"{_.Key}"));
        }

        public void Process()
        {
            foreach (var block in _blocks.Values)
            {
                block.Process();
            }
        }
    }
}