namespace CodeProverBinding;

/// <summary>
/// Provides information about a binary logical expression.
/// </summary>
public interface IBinaryLogicalExpression
{
    /// <summary>
    /// Gets the left operand.
    /// </summary>
    IBooleanExpression LeftOperand { get; }

    /// <summary>
    /// Gets the operator.
    /// </summary>
    BinaryLogicalOperator Operator { get; }

    /// <summary>
    /// Gets the right operand.
    /// </summary>
    IBooleanExpression RightOperand { get; }
}
