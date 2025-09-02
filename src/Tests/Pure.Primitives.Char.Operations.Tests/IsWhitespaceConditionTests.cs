using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Char.Operations.Tests;

public sealed record IsWhitespaceConditionTests
{
    private readonly IEnumerable<char> _whitespaceChars =
    [
        ' ', // Пробел (Space, U+0020)
        '\t', // Табуляция (Tab, U+0009)
        '\n', // Перевод строки (Line Feed, U+000A)
        '\r', // Возврат каретки (Carriage Return, U+000D)
        '\v', // Вертикальная табуляция (Vertical Tab, U+000B)
        '\f', // Перевод страницы (Form Feed, U+000C)
        '\u00A0', // Неразрывный пробел (Non-breaking space, U+00A0)
        '\u1680', // Ogham space mark (U+1680)
        '\u2000', // En quad (U+2000)
        '\u2001', // Em quad (U+2001)
        '\u2002', // En space (U+2002)
        '\u2003', // Em space (U+2003)
        '\u2004', // Three-per-em space (U+2004)
        '\u2005', // Four-per-em space (U+2005)
        '\u2006', // Six-per-em space (U+2006)
        '\u2007', // Figure space (U+2007)
        '\u2008', // Punctuation space (U+2008)
        '\u2009', // Thin space (U+2009)
        '\u200A', // Hair space (U+200A)
        '\u2028', // Line separator (U+2028)
        '\u2029', // Paragraph separator (U+2029)
        '\u202F', // Narrow no-break space (U+202F)
        '\u205F', // Medium mathematical space (U+205F)
        '\u3000', // Ideographic space (U+3000)
    ];

    [Fact]
    public void TakesPositiveResultOnWhitespaces()
    {
        IBool equality = new IsWhitespaceCondition(
            _whitespaceChars.Select(x => new Char(x))
        );

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnAllWhitespacesOneNot()
    {
        IBool equality = new IsWhitespaceCondition(
            _whitespaceChars.Select(x => new Char(x)).Append(new Char('A'))
        );

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnNonWhitespace()
    {
        IBool equality = new IsWhitespaceCondition(new Char('A'));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new IsWhitespaceCondition(new Char(' '));
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new IsWhitespaceCondition();
        _ = Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new IsWhitespaceCondition(new Char('A')).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new IsWhitespaceCondition(new Char('A')).ToString()
        );
    }
}
