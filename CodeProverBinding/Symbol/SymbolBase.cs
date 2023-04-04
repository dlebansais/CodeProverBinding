namespace CodeProverBinding;

/// <summary>
/// Represents the base class of a symbol.
/// </summary>
public abstract class SymbolBase
{
    /// <summary>
    /// Gets the alias index.
    /// </summary>
    public int Index { get; private protected set; }

    /// <summary>
    /// Creates a new symbol as an alias of the current symbol.
    /// </summary>
    public abstract ISymbol NewAlias();
}
