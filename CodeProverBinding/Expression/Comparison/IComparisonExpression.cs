namespace CodeProverBinding;

/// <summary>
/// Provides information about a comparison expression.
/// </summary>
public interface IComparisonExpression
{
    /// <summary>
    /// Gets the left operand.
    /// </summary>
    IArithmeticExpression LeftOperand { get; }

    /// <summary>
    /// Gets the operator.
    /// </summary>
    ComparisonOperator Operator { get; }

    /// <summary>
    /// Gets the right operand.
    /// </summary>
    IArithmeticExpression RightOperand { get; }
}
