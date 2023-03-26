namespace CodeProverBinding;

/// <summary>
/// Represents a constant expression.
/// </summary>
/// <typeparam name="TValue">The value type.</typeparam>
public interface IConstantExpression<TValue> : IExpression
    where TValue : struct
{
    /// <summary>
    /// Gets the constant value.
    /// </summary>
    TValue Value { get; }
}
