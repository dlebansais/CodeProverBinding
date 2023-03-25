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
    /// <param name="value">The constant value.</param>
    public ConstantExpression(TValue value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets the constant value.
    /// </summary>
    public TValue Value { get; }
    object IConstantExpression.Value { get => Value; }
}
