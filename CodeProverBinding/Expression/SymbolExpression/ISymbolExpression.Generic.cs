namespace CodeProverBinding;

/// <summary>
/// Represents a symbol expression.
/// </summary>
/// <typeparam name="TSort">The symbol sort.</typeparam>
public interface ISymbolExpression<TSort> : IExpression
    where TSort : ISort
{
    /// <summary>
    /// Gets the symbol.
    /// </summary>
    ISymbol<TSort> Symbol { get; }
}
