using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Char.Operations.Tests;

public sealed record IsDigitConditionTests
{
    private readonly IEnumerable<char> _digits = new[] { '0', '1', '2', '4', '5', '6', '7', '8', '9' };

    [Fact]
    public void TakesPositiveResultOnDigits()
    {
        IBool equality = new IsDigitCondition(_digits.Select(x => new Char(Convert.ToChar(x))));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnAllDigitsOneNot()
    {
        IBool equality =
            new IsDigitCondition(_digits.Select(x => new Char(Convert.ToChar(x)))
                .Append(new Char('A')));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultLetter()
    {
        IBool equality = new IsDigitCondition(new Char('A'));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new IsDigitCondition(new Char('0'));
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new IsDigitCondition();
        Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new IsDigitCondition(new Char('A')).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new IsDigitCondition(new Char('A')).ToString());
    }
}