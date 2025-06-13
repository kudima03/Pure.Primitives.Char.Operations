using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Char;

namespace Pure.Primitives.Char.Operations;

public sealed record IsSeparatorCondition : IBool
{
    private readonly IEnumerable<IChar> _values;

    public IsSeparatorCondition(params IChar[] values) : this(values.AsReadOnly()) { }

    public IsSeparatorCondition(IEnumerable<IChar> values)
    {
        _values = values;
    }

    bool IBool.BoolValue
    {
        get
        {
            if (!_values.Any())
            {
                throw new ArgumentException();
            }

            return _values.All(x => char.IsSeparator(x.CharValue));
        }
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}