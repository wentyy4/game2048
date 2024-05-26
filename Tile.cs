public class Tile
{
    public int Value { get; private set; }
    public bool Merged { get; set; }

    public Tile(int value)
    {
        Value = value;
        Merged = false;
    }

    public void Merge(Tile other)
    {
        if (Value == other.Value && !Merged && !other.Merged)
        {
            Value *= 2;
            other.Value = 0;
            Merged = true;
        }
    }
}
