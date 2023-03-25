namespace CodeProverBinding;

/// <summary>
/// Represents an floating point constant expression.
/// </summary>
public class FloatingPointConstantExpression : ConstantExpression<double>, IFloatingPointConstantExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FloatingPointConstantExpression"/> class.
    /// </summary>
    /// <param name="value">The constant value.</param>
    public FloatingPointConstantExpression(double value)
        : base(value)
    {
    }
}
