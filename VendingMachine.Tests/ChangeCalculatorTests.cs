namespace VendingMachine.Tests;

public class ChangeCalculatorTest{
    [Fact]
    public void TotalAmountIsInitiallyZero()
    {
        var changeCalculator = new ChangeCalculator(100);
        Assert.Equal(0, changeCalculator.TotalAmount);
    }

    [Fact]
    public void TotalAmountIsCorrectlyUpdated()
    {
        var changeCalculator = new ChangeCalculator(100);
        changeCalculator.AddCoin(new Coin("1E"));
        changeCalculator.AddCoin(new Coin("50C"));
        changeCalculator.AddCoin(new Coin("20C"));
        changeCalculator.AddCoin(new Coin("20C"));
        Assert.Equal(190, changeCalculator.TotalAmount);
    }

    [Fact]
    public void AddCoinsThrowsOverflowException_WhenTotalAmountExceedsMaximum()
    {
        var changeCalculator = new ChangeCalculator(100);
        for(int i = 0; i < 10737418; i++)
        {
            changeCalculator.AddCoin(new Coin("2E"));
        }
        Assert.Throws<OverflowException>(() => changeCalculator.AddCoin(new Coin("2E")));
    }
    [Fact]
    public void IsEnoughMoneyReturnsTrue_IfTotalAmountEqualsOrExceedsPrice()
    {
        var changeCalculator = new ChangeCalculator(100);
        changeCalculator.AddCoin(new Coin("1E"));
        Assert.True(changeCalculator.IsEnoughMoney);
    }
    [Fact]
    public void IsEnoughMoneyReturnsFalse_IfTotalAmountIsLessPrice()
    {
        var changeCalculator = new ChangeCalculator(100);
        changeCalculator.AddCoin(new Coin("50C"));
        Assert.False(changeCalculator.IsEnoughMoney);
    }
    [Fact]
    public void GetChangeReturnsCorrectChange()
    {
        var changeCalculator = new ChangeCalculator(100);
        changeCalculator.AddCoin(new Coin("1E"));
        changeCalculator.AddCoin(new Coin("50C"));
        Assert.Equal(0.5, changeCalculator.GetChange());
    }
    [Fact]
    public void GetChangeThrowsInvalidOperationException_WhenTotalAmountIsLessPrice()
    {
        var changeCalculator = new ChangeCalculator(100);
        changeCalculator.AddCoin(new Coin("50C"));
        Assert.Throws<InvalidOperationException>(() => changeCalculator.GetChange());
    }
}