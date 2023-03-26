namespace CodeProverBinding;

/// <summary>
/// Represents an integer constant expression.
/// </summary>
/// <typeparam name="TInteger">The integer type.</typeparam>
public abstract class IntegerConstantExpression<TInteger> : ConstantExpression<TInteger>, IIntegerConstantExpression
    where TInteger : struct
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerConstantExpression{TInteger}"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="value">The constant value.</param>
    public IntegerConstantExpression(Binder binder, TInteger value)
        : base(binder, value)
    {
    }

    internal IIntExprCapsule IntegerExpressionZ3 => (IIntExprCapsule)ExpressionZ3;
}
