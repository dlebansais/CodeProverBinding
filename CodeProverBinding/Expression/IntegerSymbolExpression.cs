namespace CodeProverBinding;

/// <summary>
/// Represents an integer symbol expression.
/// </summary>
public class IntegerSymbolExpression : ArithmeticSymbolExpression<IIntegerSort>, IIntegerSymbolExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerSymbolExpression"/> class.
    /// </summary>
    /// <param name="symbol">The symbol.</param>
    public IntegerSymbolExpression(IIntegerSymbol symbol)
        : base(symbol)
    {
    }
}
