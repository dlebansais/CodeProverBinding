namespace CodeProverBinding;

/// <summary>
/// Represents a constant expression.
/// </summary>
/// <typeparam name="TValue">The value type.</typeparam>
public abstract class ConstantExpression<TValue> : Expression, IConstantExpression<TValue>, IConstantExpression
    where TValue : struct
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConstantExpression{TValue}"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="value">The constant value.</param>
    public ConstantExpression(Binder binder, TValue value)
        : base(binder)
    {
        Value = value;
    }

    /// <inheritdoc/>
    public TValue Value { get; }
    object IConstantExpression.Value { get => Value; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return Value.ToString();
    }
}
