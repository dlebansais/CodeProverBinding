namespace CodeProverBinding;

/// <summary>
/// Provides information about a unary arithmetic expression.
/// </summary>
public interface IUnaryArithmeticExpression
{
    /// <summary>
    /// Gets the operator.
    /// </summary>
    UnaryArithmeticOperator Operator { get; }

    /// <summary>
    /// Gets the operand.
    /// </summary>
    IArithmeticExpression Operand { get; }
}
