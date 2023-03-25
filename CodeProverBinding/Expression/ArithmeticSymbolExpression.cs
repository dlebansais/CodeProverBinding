namespace CodeProverBinding;

/// <summary>
/// Represents an integer symbol expression.
/// </summary>
/// <typeparam name="TSort">The symbol sort.</typeparam>
public class ArithmeticSymbolExpression<TSort> : SymbolExpression<TSort>, IArithmeticSymbolExpression<TSort>
    where TSort : IArithmeticSort
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ArithmeticSymbolExpression{TSort}"/> class.
    /// </summary>
    /// <param name="symbol">The symbol.</param>
    public ArithmeticSymbolExpression(ISymbol<TSort> symbol)
        : base(symbol)
    {
    }
}
