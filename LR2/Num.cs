public class Num
{
    public int Value { get; set; }
    public bool IsFree { get; set; }

    public Num(int value)
    {
        Value = value;
        IsFree = true;
    }
}
