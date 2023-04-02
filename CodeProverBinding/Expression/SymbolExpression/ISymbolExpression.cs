namespace CodeProverBinding;

/// <summary>
/// Represents a symbol expression.
/// </summary>
public interface ISymbolExpression : IExpression
{
    /// <summary>
    /// Gets the symbol.
    /// </summary>
    ISymbol Symbol { get; }
}
