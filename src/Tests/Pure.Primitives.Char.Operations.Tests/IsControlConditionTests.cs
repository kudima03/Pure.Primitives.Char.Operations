﻿using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Char.Operations.Tests;

public sealed record IsControlConditionTests
{
    private readonly IEnumerable<char> _controlChars = new char[]
    {
        '\u0000', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005', '\u0006', '\u0007', '\u0008', '\u0009',
        '\u000A', '\u000B', '\u000C', '\u000D', '\u000E', '\u000F', '\u0010', '\u0011', '\u0012', '\u0013',
        '\u0014', '\u0015', '\u0016', '\u0017', '\u0018', '\u0019', '\u001A', '\u001B', '\u001C', '\u001D',
        '\u001E', '\u001F', '\u007F', '\u0080', '\u0081', '\u0082', '\u0083', '\u0084', '\u0085', '\u0086',
        '\u0087', '\u0088', '\u0089', '\u008A', '\u008B', '\u008C', '\u008D', '\u008E', '\u008F', '\u0090',
        '\u0091', '\u0092', '\u0093', '\u0094', '\u0095', '\u0096', '\u0097', '\u0098', '\u0099', '\u009A',
        '\u009B', '\u009C', '\u009D', '\u009E', '\u009F',
    };

    [Fact]
    public void TakesPositiveResultOnControls()
    {
        IBool equality = new IsControlCondition(_controlChars.Select(x => new Char(x)));

        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnAllControlsOneNot()
    {
        IBool equality = new IsControlCondition(_controlChars.Select(x => new Char(x)).Append(new Char('A')));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesFalseResultOnNonControl()
    {
        IBool equality = new IsControlCondition(new Char('A'));

        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ProduceTrueOnSingleElementInCollection()
    {
        IBool equality = new IsControlCondition(_controlChars.Select(x => new Char(x)).First());
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyArguments()
    {
        IBool equality = new IsControlCondition();
        Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new IsControlCondition(new Char('A')).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new IsControlCondition(new Char('A')).ToString());
    }
}