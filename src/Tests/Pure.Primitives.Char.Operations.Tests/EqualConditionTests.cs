using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.String;

namespace Pure.Primitives.Char.Operations.Tests;

public sealed record EqualConditionTests
{
    [Fact]
    public void TakesPositiveResultOnSameValues()
    {
        IBool equality = new EqualCondition(
            new Char('A'),
            new Char('A'),
            new Char('A'),
            new Char('A'),
            new Char('A'));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnTwoSameValues()
    {
        IBool equality = new EqualCondition(new Char('A'), new Char('A'));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnDifferentValues()
    {
        IBool equality = new EqualCondition(
            new Char('A'),
            new Char('B'),
            new Char('C'),
            new Char('D'),
            new Char('E'));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAllSameOneDifferentValue()
    {
        IBool equality = new EqualCondition(
            new Char('A'),
            new Char('A'),
            new Char('A'),
            new Char('A'),
            new Char('B'));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new EqualCondition(new Char('X'));
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new EqualCondition(new Char('A')).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new EqualCondition(new Char('A')).ToString());
    }
}