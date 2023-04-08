namespace CodeProverBinding;

using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Represents a table associating symbols and aliases.
/// </summary>
internal class AliasTable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AliasTable"/> class.
    /// </summary>
    public AliasTable()
    {
        SymbolToAliasTable = new Dictionary<SymbolBase, SymbolBase>();
        AliasToSymbolTable = new Dictionary<SymbolBase, SymbolBase>();
    }

    /// <summary>
    /// Gets a value indicating whether the alias table is empty.
    /// </summary>
    public bool IsEmpty { get => SymbolToAliasTable.Count == 0; }

    /// <summary>
    /// Sets the current alias of a symbol.
    /// </summary>
    /// <param name="symbolOrAlias">The symbol or alias.</param>
    /// <param name="alias">The alias.</param>
    public void SetAlias(SymbolBase symbolOrAlias, SymbolBase alias)
    {
        Debug.Assert(alias.IsAlias);
        Debug.Assert(alias.Index == symbolOrAlias.Index + 1);
        Debug.Assert(!AliasToSymbolTable.ContainsKey(alias));
        Debug.Assert(!SymbolToAliasTable.ContainsKey(alias));

        SymbolBase RootSymbol;

        if (symbolOrAlias.IsAlias)
        {
            Debug.Assert(AliasToSymbolTable.ContainsKey(symbolOrAlias));

            RootSymbol = AliasToSymbolTable[symbolOrAlias];

            Debug.Assert(SymbolToAliasTable[RootSymbol] == symbolOrAlias);
        }
        else
        {
            RootSymbol = symbolOrAlias;
            SymbolToAliasTable.Add(RootSymbol, alias);
        }

        AliasToSymbolTable.Add(alias, RootSymbol);
        SymbolToAliasTable[RootSymbol] = alias;
    }

    /// <summary>
    /// Returns the current alias of a symbol.
    /// </summary>
    /// <param name="symbol">The symbol.</param>
    internal SymbolBase GetAlias(SymbolBase symbol)
    {
        Debug.Assert(!symbol.IsAlias);
        Debug.Assert(SymbolToAliasTable.ContainsKey(symbol));

        return SymbolToAliasTable[symbol];
    }

    private Dictionary<SymbolBase, SymbolBase> SymbolToAliasTable;
    private Dictionary<SymbolBase, SymbolBase> AliasToSymbolTable;
}
