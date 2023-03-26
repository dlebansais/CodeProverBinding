namespace CodeProverBinding;

/// <summary>
/// Provides information about a unary logical expression.
/// </summary>
public interface IUnaryLogicalExpression
{
    /// <summary>
    /// Gets the operator.
    /// </summary>
    UnaryLogicalOperator Operator { get; }

    /// <summary>
    /// Gets the operand.
    /// </summary>
    IBooleanExpression Operand { get; }
}
