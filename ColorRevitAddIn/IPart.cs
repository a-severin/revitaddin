namespace ColorRevitAddIn
{
    public interface IPart
    {
        string Block { get; }
        string Level { get; }
        string Subzone { get; }
        string Zone { get; }
        void SetSemitone();
    }
}