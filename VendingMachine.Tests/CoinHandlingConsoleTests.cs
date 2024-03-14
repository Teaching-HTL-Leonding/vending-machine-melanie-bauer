namespace VendingMachine.Tests;
public class CoinHandlingConsoleTests
{
    [Fact]
    public void AddingValidCoins_ShouldPrintNoChange()
    {
        var inputs = new string[] { "1,5E", "1E", "50C" };
        var console = new CoinHandlingConsoleMock(inputs);

        Assert.Equal(0, console.CoinHandling());
        Assert.Equal(
            [
                "Price: ",
                "Coin: ",
                "Total: 1E",
                "Coin: ",
                "Total: 1,5E"
            ], console.Outputs);
    }

    [Fact]
    public void AddingValidCoins_ShouldReturnChange()
    {
        var inputs = new string[] { "1,5E", "2E" };
        var console = new CoinHandlingConsoleMock(inputs);

        Assert.Equal(0.5, console.CoinHandling());
        Assert.Equal(
            [
                "Price: ",
                "Coin: ",
                "Total: 2E",
            ], console.Outputs);
    }

    [Fact]
    public void AddingInvalidCoins_ShouldPrintErrorMessages()
    {
        var inputs = new string[] { "1,5E", "1E", "1D", "50", "50C" };
        var console = new CoinHandlingConsoleMock(inputs);

        Assert.Equal(0, console.CoinHandling());
        Assert.Equal(
            [
                "Price: ",
                "Coin: ",
                "Total: 1E",
                "Coin: ",
                "Coin: ",
                "System.FormatException: Invalid coin",
                "Coin: ",
                "System.FormatException: Invalid coin",
                "Total: 1,5E",

            ], console.Outputs);
    }

}