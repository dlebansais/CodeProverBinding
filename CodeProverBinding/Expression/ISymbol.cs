namespace CodeProverBinding;

/// <summary>
/// Provides information about a symbol.
/// </summary>
public interface ISymbol
{
    /// <summary>
    /// Gets the symbol name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the symbol sort.
    /// </summary>
    ISort Sort { get; }
}
