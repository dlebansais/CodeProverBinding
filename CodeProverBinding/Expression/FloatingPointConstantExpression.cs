namespace CodeProverBinding;

/// <summary>
/// Represents an floating point constant expression.
/// </summary>
public class FloatingPointConstantExpression : ConstantExpression<double>, IFloatingPointConstantExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FloatingPointConstantExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="value">The constant value.</param>
    public FloatingPointConstantExpression(Binder binder, double value)
        : base(binder, value)
    {
    }
}
