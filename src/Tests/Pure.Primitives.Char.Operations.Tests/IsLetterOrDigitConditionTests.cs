using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Char.Operations.Tests;

public sealed record IsLetterOrDigitConditionTests
{
    private readonly IEnumerable<char> _letterOrDigitChars =
    [
        'a',
        'B',
        'c',
        'D',
        'e',
        'F',
        'g',
        'H',
        'i',
        '0',
        '1',
        '2',
        '4',
        '5',
        '6',
        '7',
        '8',
        '9',
    ];

    [Fact]
    public void TakesPositiveResultOnDigits()
    {
        IBool equality = new IsLetterOrDigitCondition(
            _letterOrDigitChars.Select(x => new Char(Convert.ToChar(x)))
        );

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnAllDigitsOneNot()
    {
        IBool equality = new IsLetterOrDigitCondition(
            _letterOrDigitChars
                .Select(x => new Char(Convert.ToChar(x)))
                .Append(new Char('.'))
        );

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnLetters()
    {
        IBool equality = new IsLetterOrDigitCondition(
            _letterOrDigitChars.Select(x => new Char(x))
        );

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnAllLettersOneNot()
    {
        IBool equality = new IsLetterOrDigitCondition(
            _letterOrDigitChars.Select(x => new Char(x)).Append(new Char('.'))
        );

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnNonLetter()
    {
        IBool equality = new IsLetterOrDigitCondition(new Char('?'));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new IsLetterOrDigitCondition(
            _letterOrDigitChars.Select(x => new Char(x)).First()
        );
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new IsLetterOrDigitCondition();
        _ = Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new IsLetterOrDigitCondition(new Char('A')).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new IsLetterOrDigitCondition(new Char('A')).ToString()
        );
    }
}
