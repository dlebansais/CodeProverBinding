namespace CodeProverBinding;

/// <summary>
/// Represents an boolean constant expression.
/// </summary>
public class BooleanConstantExpression : ConstantExpression<bool>, IBooleanConstantExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BooleanConstantExpression"/> class.
    /// </summary>
    /// <param name="value">The constant value.</param>
    public BooleanConstantExpression(bool value)
        : base(value)
    {
    }
}
