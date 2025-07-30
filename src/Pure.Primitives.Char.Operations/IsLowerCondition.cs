using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Char;

namespace Pure.Primitives.Char.Operations;

public sealed record IsLowerCondition : IBool
{
    private readonly IEnumerable<IChar> _values;

    public IsLowerCondition(params IEnumerable<IChar> values)
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

            return _values.All(x => char.IsLower(x.CharValue));
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