using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Char;

namespace Pure.Primitives.Char.Operations;

public sealed record IsLetterOrDigitCondition : IBool
{
    private readonly IEnumerable<IChar> _values;

    public IsLetterOrDigitCondition(params IEnumerable<IChar> values)
    {
        _values = values;
    }

    bool IBool.BoolValue =>
        !_values.Any()
            ? throw new ArgumentException()
            : _values.All(x => char.IsLetterOrDigit(x.CharValue));

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
