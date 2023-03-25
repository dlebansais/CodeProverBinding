namespace CodeProverBinding;

/// <summary>
/// Represents a constant expression.
/// </summary>
/// <typeparam name="TSort">The symbol sort.</typeparam>
public abstract class SymbolExpression<TSort> : Expression, ISymbolExpression<TSort>, ISymbolExpression
    where TSort : ISort
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SymbolExpression{TSort}"/> class.
    /// </summary>
    /// <param name="symbol">The symbol.</param>
    public SymbolExpression(ISymbol<TSort> symbol)
    {
        Symbol = symbol;
    }

    /// <summary>
    /// Gets the constant value.
    /// </summary>
    public ISymbol<TSort> Symbol { get; }
    ISymbol ISymbolExpression.Symbol { get => (ISymbol)Symbol; }
}
