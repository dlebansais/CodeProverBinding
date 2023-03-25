namespace CodeProverBinding;

/// <summary>
/// Represents an integer constant expression.
/// </summary>
public class IntegerConstantExpression : ConstantExpression<long>, IIntegerConstantExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerConstantExpression"/> class.
    /// </summary>
    /// <param name="value">The constant value.</param>
    public IntegerConstantExpression(long value)
        : base(value)
    {
    }
}
