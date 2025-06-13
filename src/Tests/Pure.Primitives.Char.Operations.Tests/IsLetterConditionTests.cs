using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Char.Operations.Tests;

public sealed record IsLetterConditionTests
{
    private readonly IEnumerable<char> _letterChars = new[] { 'a', 'B', 'c', 'D', 'e', 'F', 'g', 'H', 'i' };

    [Fact]
    public void TakesPositiveResultOnLetters()
    {
        IBool equality = new IsLetterCondition(_letterChars.Select(x => new Char(x)));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnAllLettersOneNot()
    {
        IBool equality = new IsLetterCondition(_letterChars.Select(x => new Char(x)).Append(new Char('.')));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnNonLetter()
    {
        IBool equality = new IsLetterCondition(new Char('?'));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new IsLetterCondition(_letterChars.Select(x => new Char(x)).First());
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new IsLetterCondition();
        Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new IsLetterCondition(new Char('A')).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new IsLetterCondition(new Char('A')).ToString());
    }
}