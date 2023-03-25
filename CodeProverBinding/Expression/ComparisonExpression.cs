namespace CodeProverBinding;

/// <summary>
/// Represents a comparison expression.
/// </summary>
public class ComparisonExpression : Expression, IComparisonExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ComparisonExpression"/> class.
    /// </summary>
    /// <param name="leftOperand">The left operand.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="rightOperand">The right operand.</param>
    public ComparisonExpression(IArithmeticExpression leftOperand, ComparisonOperator @operator, IArithmeticExpression rightOperand)
    {
        LeftOperand = leftOperand;
        Operator = @operator;
        RightOperand = rightOperand;
    }

    /// <summary>
    /// Gets the left operand.
    /// </summary>
    public IArithmeticExpression LeftOperand { get; }

    /// <summary>
    /// Gets the operator.
    /// </summary>
    public ComparisonOperator Operator { get; }

    /// <summary>
    /// Gets the right operand.
    /// </summary>
    public IArithmeticExpression RightOperand { get; }
}
