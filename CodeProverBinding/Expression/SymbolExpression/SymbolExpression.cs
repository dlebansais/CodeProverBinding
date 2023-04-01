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
    /// <param name="binder">The binder.</param>
    /// <param name="symbol">The symbol.</param>
    public SymbolExpression(Binder binder, ISymbol<TSort> symbol)
        : base(binder)
    {
        Symbol = symbol;
    }

    /// <inheritdoc/>
    public ISymbol<TSort> Symbol { get; }
    ISymbol ISymbolExpression.Symbol { get => (ISymbol)Symbol; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return Symbol.ToString();
    }
}
