namespace CodeProverBinding;

/// <summary>
/// Represents a choice of how alias are named.
/// </summary>
internal class AliasNaming : IAliasNaming
{
    /// <inheritdoc/>
    public string GetAliasName(ISymbol symbol)
    {
        int Index = ((SymbolBase)symbol).Index;

        if (Index == 0)
            return symbol.Name;
        else
            return $"{symbol.Name}_{Index}";
    }
}
