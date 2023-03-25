namespace CodeProverBinding;

/// <summary>
/// Represents an integer symbol expression.
/// </summary>
public class IntegerSymbolExpression : ArithmeticSymbolExpression<IIntegerSort>, IIntegerSymbolExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerSymbolExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="symbol">The symbol.</param>
    public IntegerSymbolExpression(Binder binder, IIntegerSymbol symbol)
        : base(binder, symbol)
    {
    }
}
