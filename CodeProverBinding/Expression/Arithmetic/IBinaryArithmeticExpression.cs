namespace CodeProverBinding;

/// <summary>
/// Provides information about a binary arithmetic expression.
/// </summary>
public interface IBinaryArithmeticExpression : IArithmeticExpression
{
    /// <summary>
    /// Gets the left operand.
    /// </summary>
    IArithmeticExpression LeftOperand { get; }

    /// <summary>
    /// Gets the operator.
    /// </summary>
    BinaryArithmeticOperator Operator { get; }

    /// <summary>
    /// Gets the right operand.
    /// </summary>
    IArithmeticExpression RightOperand { get; }
}
