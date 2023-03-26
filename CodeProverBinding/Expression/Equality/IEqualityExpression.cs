namespace CodeProverBinding;

/// <summary>
/// Provides information about an equality expression.
/// </summary>
public interface IEqualityExpression
{
    /// <summary>
    /// Gets the left operand.
    /// </summary>
    IExpression LeftOperand { get; }

    /// <summary>
    /// Gets the operator.
    /// </summary>
    EqualityOperator Operator { get; }

    /// <summary>
    /// Gets the right operand.
    /// </summary>
    IExpression RightOperand { get; }
}
