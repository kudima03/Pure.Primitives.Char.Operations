using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Char;

namespace Pure.Primitives.Char.Operations;

public sealed record EqualCondition : IBool
{
    private readonly IEnumerable<IChar> _values;

    public EqualCondition(params IEnumerable<IChar> values)
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

            return _values.DistinctBy(x => x.CharValue).Count() == 1;
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