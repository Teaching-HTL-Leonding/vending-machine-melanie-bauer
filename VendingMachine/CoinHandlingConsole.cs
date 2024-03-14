namespace VendingMachine;

public class CoinHandlingConsole
{
    public virtual void WriteLine(string s) => Console.WriteLine(s);
    public virtual string ReadLine() => Console.ReadLine()!;
    public double CoinHandling()
    {
        var price = 0;

        while (price == 0)
        {
            try
            {
                Console.Write("Price: ");
                var stringPrice = Console.ReadLine()!;
                price = (int)(100 * double.Parse(stringPrice[..^1]));
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
        var changeCalculator = new ChangeCalculator(price);
        while (changeCalculator.TotalAmount < price)
        {
            try
            {
                Console.Write("Coin: ");
                var currentCoin = new Coin(Console.ReadLine()!);
                changeCalculator.AddCoin(currentCoin);

                Console.WriteLine($"Total: {changeCalculator.TotalAmount / 100d}E");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        return changeCalculator.GetChange();
    }
}
