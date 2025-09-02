using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Char.Operations.Tests;

public sealed record IsSymbolConditionTests
{
    private readonly IEnumerable<char> _symbolChars =
    [
        // Currency symbols
        '$',
        '€',
        '£',
        '¥',
        '¢',
        // Mathematical symbols
        '+',
        '=',
        '×',
        '÷',
        '<',
        '>',
        '±',
        // Modifier and other symbols
        '^',
        '~',
        '|',
        // Special symbols
        '©',
        '®',
        '™',
        '✓',
        '✗',
    ];

    [Fact]
    public void TakesPositiveResultOnSymbols()
    {
        IBool equality = new IsSymbolCondition(_symbolChars.Select(x => new Char(x)));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnAllSymbolsOneNot()
    {
        IBool equality = new IsSymbolCondition(
            _symbolChars.Select(x => new Char(x)).Append(new Char('A'))
        );

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnNonSeparator()
    {
        IBool equality = new IsSymbolCondition(new Char('A'));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new IsSymbolCondition(
            _symbolChars.Select(x => new Char(x)).First()
        );
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new IsSymbolCondition();
        _ = Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new IsSymbolCondition(new Char('A')).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new IsSymbolCondition(new Char('A')).ToString()
        );
    }
}
