namespace CodeProverBinding;

/// <summary>
/// Provides information about a symbol.
/// </summary>
public interface ISymbol
{
    /// <summary>
    /// Gets the binder.
    /// </summary>
    Binder Binder { get; }

    /// <summary>
    /// Gets the symbol name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets a value indicating whether the symbol is an alias to another symbol.
    /// </summary>
    bool IsAlias { get; }

    /// <summary>
    /// Gets the symbol sort.
    /// </summary>
    ISort Sort { get; }

    /// <summary>
    /// Creates a new symbol as an alias of the current symbol.
    /// </summary>
    ISymbol NewAlias();
}
