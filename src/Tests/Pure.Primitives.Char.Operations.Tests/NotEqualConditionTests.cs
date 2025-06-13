using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Char.Operations.Tests;

public sealed record NotEqualConditionTests
{
    [Fact]
    public void TakesPositiveResultOnSameValues()
    {
        IBool equality = new NotEqualCondition(
            new Char('A'),
            new Char('A'),
            new Char('A'),
            new Char('A'),
            new Char('A'));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnTwoSameValues()
    {
        IBool equality = new NotEqualCondition(new Char('A'), new Char('A'));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnDifferentValues()
    {
        IBool equality = new NotEqualCondition(
            new Char('A'),
            new Char('B'),
            new Char('C'),
            new Char('D'),
            new Char('E'));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAllSameOneDifferentValue()
    {
        IBool equality = new NotEqualCondition(
            new Char('A'),
            new Char('A'),
            new Char('A'),
            new Char('A'),
            new Char('B'));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new NotEqualCondition(new Char('X'));
        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new NotEqualCondition();
        Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new NotEqualCondition(new Char('A')).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new NotEqualCondition(new Char('A')).ToString());
    }
}