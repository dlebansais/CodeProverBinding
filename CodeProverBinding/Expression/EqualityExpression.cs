namespace CodeProverBinding;

/// <summary>
/// Represents an equality expression.
/// </summary>
public class EqualityExpression : Expression, IEqualityExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EqualityExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="leftOperand">The left operand.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="rightOperand">The right operand.</param>
    public EqualityExpression(Binder binder, IExpression leftOperand, EqualityOperator @operator, IExpression rightOperand)
        : base(binder)
    {
        LeftOperand = leftOperand;
        Operator = @operator;
        RightOperand = rightOperand;
    }

    /// <summary>
    /// Gets the left operand.
    /// </summary>
    public IExpression LeftOperand { get; }

    /// <summary>
    /// Gets the operator.
    /// </summary>
    public EqualityOperator Operator { get; }

    /// <summary>
    /// Gets the right operand.
    /// </summary>
    public IExpression RightOperand { get; }
}
