namespace CodeProverBinding;

/// <summary>
/// Represents an floating point symbol expression.
/// </summary>
public class FloatingPointSymbolExpression : ArithmeticSymbolExpression<IFloatingPointSort>, IFloatingPointSymbolExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FloatingPointSymbolExpression"/> class.
    /// </summary>
    /// <param name="symbol">The symbol.</param>
    public FloatingPointSymbolExpression(IFloatingPointSymbol symbol)
        : base(symbol)
    {
    }
}
