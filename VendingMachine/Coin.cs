namespace VendingMachine;

public class Coin(string coin)
{
    public string name = coin;

    public int Parse()
    {
        if (name.EndsWith("E"))
        {
            if (name.StartsWith("2") || name.StartsWith("1"))
            {
                try
                {
                    return (int)(double.Parse(name[0..^1]) * 100);
                }
                catch (FormatException)
                {
                    throw new FormatException("Invalid coin");
                }
            }
            else
            {
                throw new FormatException("Invalid coin");
            }
        }
        else if (name.EndsWith("C"))
        {
            if (name.StartsWith("10") || name.StartsWith("20") || name.StartsWith("50"))
            {
                try
                {
                    return int.Parse(name[0..^1]);
                }
                catch (FormatException)
                {
                    throw new FormatException("Invalid coin");
                }
            }
            else
            {
                throw new FormatException("Invalid coin");
            }
        }
        else
        {
            throw new FormatException("Invalid coin");
        }
    }
}