using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Char.Operations.Tests;

public sealed record IsSeparatorConditionTests
{
    private const char Space = '\u0020'; // space
    private const char Nbsp = '\u00A0'; // non-breaking space
    private const char OghamSpace = '\u1680'; // ogham space mark
    private const char EnQuad = '\u2000'; // en quad
    private const char EmQuad = '\u2001'; // em quad
    private const char EnSpace = '\u2002'; // en space
    private const char EmSpace = '\u2003'; // em space
    private const char NarrowNbsp = '\u202F'; // narrow non-breaking space
    private const char MathSpace = '\u205F'; // medium mathematical space
    private const char IdeographicSpace = '\u3000'; // ideographic space
    private const char LineSeparator = '\u2028'; // line separator
    private const char ParagraphSeparator = '\u2029'; // paragraph separator

    [Fact]
    public void TakesPositiveResultOnSeparators()
    {
        IBool equality = new IsSeparatorCondition(
            new Char(Space),
            new Char(Nbsp),
            new Char(OghamSpace),
            new Char(EnQuad),
            new Char(EmQuad),
            new Char(EnSpace),
            new Char(EmSpace),
            new Char(NarrowNbsp),
            new Char(MathSpace),
            new Char(IdeographicSpace),
            new Char(LineSeparator),
            new Char(ParagraphSeparator)
        );

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnAllSeparatorsOneNot()
    {
        IBool equality = new IsSeparatorCondition(
            new Char(Space),
            new Char(Nbsp),
            new Char(OghamSpace),
            new Char(EnQuad),
            new Char(EmQuad),
            new Char(EnSpace),
            new Char(EmSpace),
            new Char(NarrowNbsp),
            new Char(MathSpace),
            new Char(IdeographicSpace),
            new Char(LineSeparator),
            new Char(ParagraphSeparator),
            new Char('A')
        );

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnNonSeparator()
    {
        IBool equality = new IsSeparatorCondition(new Char('A'));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new IsSeparatorCondition(new Char(ParagraphSeparator));
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new IsSeparatorCondition();
        _ = Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new IsSeparatorCondition(new Char('A')).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new IsSeparatorCondition(new Char('A')).ToString()
        );
    }
}
