namespace CodeProverBinding;

/// <summary>
/// Represents a choice of how alias are named.
/// </summary>
public interface IAliasNaming
{
    /// <summary>
    /// Gets the alias name of a symbol.
    /// </summary>
    /// <param name="symbol">The symbol.</param>
    string GetAliasName(ISymbol symbol);
}
