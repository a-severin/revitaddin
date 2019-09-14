namespace ColorRevitAddIn
{
    public class FakePart : IPart
    {
        public FakePart(string block, string level, string subzone, string zone)
        {
            Block = block;
            Level = level;
            Subzone = subzone;
            Zone = zone;
        }

        public bool IsSemistone { get; private set; }

        public string Block { get; }
        public string Level { get; }
        public string Subzone { get; }
        public string Zone { get; }
        public void SetSemitone()
        {
            IsSemistone = true;
        }
    }
}