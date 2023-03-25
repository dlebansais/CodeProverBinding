namespace CodeProverBinding;

/// <summary>
/// Provides information about an arithmetic expression.
/// </summary>
public interface IArithmeticExpression
{
    /// <summary>
    /// Gets the left operand.
    /// </summary>
    IArithmeticExpression LeftOperand { get; }

    /// <summary>
    /// Gets the operator.
    /// </summary>
    ArithmeticOperator Operator { get; }

    /// <summary>
    /// Gets the right operand.
    /// </summary>
    IArithmeticExpression RightOperand { get; }
}
