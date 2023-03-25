namespace CodeProverBinding;

using System.Diagnostics;

/// <summary>
/// Represents an arithmetic expression.
/// </summary>
public class ArithmeticExpression : Expression, IArithmeticExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ArithmeticExpression"/> class.
    /// </summary>
    /// <param name="leftOperand">The left operand.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="rightOperand">The right operand.</param>
    public ArithmeticExpression(IArithmeticExpression leftOperand, ArithmeticOperator @operator, IArithmeticExpression rightOperand)
    {
        Debug.Assert(@operator != ArithmeticOperator.Modulo || (leftOperand is IIntegerExpression && rightOperand is IIntegerExpression));

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
    public ArithmeticOperator Operator { get; }

    /// <summary>
    /// Gets the right operand.
    /// </summary>
    public IArithmeticExpression RightOperand { get; }
}
