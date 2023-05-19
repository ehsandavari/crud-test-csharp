namespace Domain.ValueObject;

public class PhoneNumber : ValueObject
{
    public PhoneNumber(int prefix, ulong number)
    {
        Prefix = prefix;
        Number = number;
    }

    public int Prefix { get; }
    public ulong Number { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Prefix;
        yield return Number;
    }
}