namespace VendingMachine.Tests;

public class CoinTests
{
    [Fact]
    public void ParsingOfValidCoins_ShouldPrintNoError()
    {
        var coins = new string[] { "10C", "20C", "50C", "1E", "2E" };

        Assert.Equal(
            [10, 20, 50, 100, 200],
            coins.Select(coin => new Coin(coin).Parse())
        );
    }
    [Fact]
    public void ParsingOfInvalidCoins_ShouldPrintError()
    {
        var coins = new string[] { "3E", "1D", "50", "20Cents" };

        foreach (var coin in coins)
        {
            Assert.Throws<FormatException>(() => new Coin(coin).Parse());
        }
    }
}