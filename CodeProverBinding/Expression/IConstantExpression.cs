namespace CodeProverBinding;

/// <summary>
/// Represents a constant expression.
/// </summary>
public interface IConstantExpression : IExpression
{
    /// <summary>
    /// Gets the constant value.
    /// </summary>
    object Value { get; }
}
