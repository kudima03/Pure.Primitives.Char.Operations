using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Char.Operations.Tests;

public sealed record IsUpperConditionTests
{
    [Fact]
    public void TakesPositiveResultOnUppers()
    {
        IBool equality = new IsUpperCondition(
            new Char('A'),
            new Char('B'),
            new Char('C'),
            new Char('D'),
            new Char('Y'),
            new Char('H'));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnAllUppersOneNot()
    {
        IBool equality = new IsUpperCondition(
            new Char('A'),
            new Char('B'),
            new Char('C'),
            new Char('D'),
            new Char('Y'),
            new Char('H'),
            new Char('k'));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnLower()
    {
        IBool equality = new IsUpperCondition(new Char('a'));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new IsUpperCondition(new Char('A'));
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new IsUpperCondition();
        Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new IsUpperCondition(new Char('A')).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new IsUpperCondition(new Char('A')).ToString());
    }
}