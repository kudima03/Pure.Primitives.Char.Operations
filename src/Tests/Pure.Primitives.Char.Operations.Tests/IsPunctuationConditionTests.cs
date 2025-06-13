using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Char.Operations.Tests;

public sealed record IsPunctuationConditionTests
{
    private readonly IEnumerable<char> _punctuationChars = new[]
    {
        '.', // period
        ',', // comma
        ';', // semicolon
        ':', // colon
        '!', // exclamation mark
        '?', // question mark
        '\'', // apostrophe
        '\"', // quotation mark
        '-', // hyphen-minus
        '—', // em dash (U+2014)
        '–', // en dash (U+2013)
        '(', ')', // parentheses
        '[', ']', // square brackets
        '{', '}', // curly braces
        '/', '\\', // slash and backslash
        '…', // ellipsis (U+2026)
        '·', // middle dot (U+00B7)
        '•', // bullet (U+2022)
        '«', '»', // guillemets (U+00AB, U+00BB)
        '‹', '›'  // single guillemets (U+2039, U+203A)
    };

    [Fact]
    public void TakesPositiveResultOnPunctuation()
    {
        IBool equality = new IsPunctuationCondition(_punctuationChars.Select(x => new Char(x)));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnAllPunctuationOneNot()
    {
        IBool equality = new IsPunctuationCondition(_punctuationChars.Select(x => new Char(x)).Append(new Char('X')));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnNonPunctuation()
    {
        IBool equality = new IsPunctuationCondition(new Char('A'));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new IsPunctuationCondition(_punctuationChars.Select(x => new Char(x)).First());
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new IsPunctuationCondition();
        Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new IsPunctuationCondition(new Char('A')).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new IsPunctuationCondition(new Char('A')).ToString());
    }
}