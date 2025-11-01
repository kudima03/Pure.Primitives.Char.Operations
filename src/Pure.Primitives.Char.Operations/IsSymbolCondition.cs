using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Char;

namespace Pure.Primitives.Char.Operations;

public sealed record IsSymbolCondition : IBool
{
    private readonly IEnumerable<IChar> _values;

    public IsSymbolCondition(params IEnumerable<IChar> values)
    {
        _values = values;
    }

    public bool BoolValue =>
        !_values.Any()
            ? throw new ArgumentException()
            : _values.All(x => char.IsSymbol(x.CharValue));

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
