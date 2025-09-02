using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Char.Operations.Tests;

public sealed record IsLowerConditionTests
{
    [Fact]
    public void TakesPositiveResultOnLowers()
    {
        IBool equality = new IsLowerCondition(
            new Char('a'),
            new Char('s'),
            new Char('d'),
            new Char('f'),
            new Char('g'),
            new Char('h')
        );

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnAllLowersOneNot()
    {
        IBool equality = new IsLowerCondition(
            new Char('a'),
            new Char('s'),
            new Char('d'),
            new Char('S'),
            new Char('f'),
            new Char('g'),
            new Char('h')
        );

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnUpper()
    {
        IBool equality = new IsLowerCondition(new Char('A'));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new IsLowerCondition(new Char('a'));
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new IsLowerCondition();
        _ = Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new IsLowerCondition(new Char('A')).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new IsLowerCondition(new Char('A')).ToString()
        );
    }
}
