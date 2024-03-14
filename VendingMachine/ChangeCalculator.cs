namespace VendingMachine;

public class ChangeCalculator(int productPrice)
{
    public int ProductPrice { get; set; } = productPrice;
    public int TotalAmount { get; private set; }
    public bool IsEnoughMoney = false;

    public void AddCoin(Coin coin)
    {
        try
        {
            checked
            {
                TotalAmount += coin.Parse();
            }
        }
        catch (OverflowException)
        {
            throw new OverflowException("The amount exceeds the maximum amount");
        }

        if (TotalAmount >= ProductPrice)
        {
            IsEnoughMoney = true;
        }
    }

    public double GetChange()
    {
        if (TotalAmount < ProductPrice)
        {
            throw new InvalidOperationException("Not enough money");
        }
        else
        {
            return (TotalAmount - ProductPrice) / 100d;
        }
    }
}