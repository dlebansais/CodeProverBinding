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
        SymbolToAliasTable = new Dictionary<ISymbol, ISymbol>();
        AliasToSymbolTable = new Dictionary<ISymbol, ISymbol>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AliasTable"/> class.
    /// </summary>
    /// <param name="other">The other alias table.</param>
    private AliasTable(AliasTable other)
    {
        SymbolToAliasTable = new Dictionary<ISymbol, ISymbol>(other.SymbolToAliasTable);
        AliasToSymbolTable = new Dictionary<ISymbol, ISymbol>(other.AliasToSymbolTable);
    }

    /// <summary>
    /// Gets a value indicating whether the alias table is empty.
    /// </summary>
    public bool IsEmpty { get => SymbolToAliasTable.Count == 0; }

    /// <summary>
    /// Gets the number of symbols in the table.
    /// </summary>
    public int SymbolCount { get => SymbolToAliasTable.Count; }

    /// <summary>
    /// Sets the current alias of a symbol.
    /// </summary>
    /// <param name="symbolOrAlias">The symbol or alias.</param>
    /// <param name="alias">The alias.</param>
    public void SetAlias(ISymbol symbolOrAlias, ISymbol alias)
    {
        Debug.Assert(alias.IsAlias);
        Debug.Assert(((SymbolBase)alias).Index == ((SymbolBase)symbolOrAlias).Index + 1);
        Debug.Assert(!AliasToSymbolTable.ContainsKey(alias));
        Debug.Assert(!SymbolToAliasTable.ContainsKey(alias));

        ISymbol RootSymbol;

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
    /// Checks that the table contains the provided symbol.
    /// </summary>
    /// <param name="symbol">The symbol.</param>
    internal bool ContainsSymbol(ISymbol symbol)
    {
        Debug.Assert(!symbol.IsAlias);

        return SymbolToAliasTable.ContainsKey(symbol);
    }

    /// <summary>
    /// Checks that the table contains the provided alias.
    /// </summary>
    /// <param name="alias">The alias.</param>
    internal bool ContainsAlias(ISymbol alias)
    {
        Debug.Assert(alias.IsAlias);

        return AliasToSymbolTable.ContainsKey(alias);
    }

    /// <summary>
    /// Returns the current alias of a symbol.
    /// </summary>
    /// <param name="symbol">The symbol.</param>
    internal ISymbol GetAlias(ISymbol symbol)
    {
        Debug.Assert(!symbol.IsAlias);
        Debug.Assert(SymbolToAliasTable.ContainsKey(symbol));

        return SymbolToAliasTable[symbol];
    }

    /// <summary>
    /// Gets a clone of the table.
    /// </summary>
    internal AliasTable Clone()
    {
        return new AliasTable(this);
    }

    /// <summary>
    /// Gets the list of aliases in this table that <paramref name="other"/> does not contain.
    /// </summary>
    /// <param name="other">The other table.</param>
    internal List<ISymbol> GetDifference(AliasTable other)
    {
        List<ISymbol> Result = new();

        foreach (ISymbol Alias in AliasToSymbolTable.Keys)
            if (!other.AliasToSymbolTable.ContainsKey(Alias))
                Result.Add(Alias);

        return Result;
    }

    /// <summary>
    /// Merges this table and the other.
    /// </summary>
    /// <param name="other">The other table.</param>
    internal List<ISymbol> Merge(AliasTable other)
    {
        List<ISymbol> CommonSymbolList = new();
        List<ISymbol> OtherOnlySymbolList = new();
        List<ISymbol> UpdatedAliasList = new();

        foreach (ISymbol Symbol in SymbolToAliasTable.Keys)
            if (other.SymbolToAliasTable.ContainsKey(Symbol))
                CommonSymbolList.Add(Symbol);

        foreach (ISymbol Symbol in other.SymbolToAliasTable.Keys)
            if (!SymbolToAliasTable.ContainsKey(Symbol))
                OtherOnlySymbolList.Add(Symbol);

        foreach (ISymbol Symbol in CommonSymbolList)
        {
            ISymbol ThisAlias = SymbolToAliasTable[Symbol];
            ISymbol OtherAlias = other.SymbolToAliasTable[Symbol];

            if (ThisAlias != OtherAlias)
            {
                ISymbol NewAlias = ThisAlias.NewAlias();
                UpdatedAliasList.Add(NewAlias);
            }
        }

        foreach (ISymbol Symbol in OtherOnlySymbolList)
        {
            ISymbol OtherAlias = other.SymbolToAliasTable[Symbol];
            SymbolToAliasTable.Add(Symbol, OtherAlias);
            AliasToSymbolTable.Add(OtherAlias, Symbol);
        }

        return UpdatedAliasList;
    }

    private Dictionary<ISymbol, ISymbol> SymbolToAliasTable;
    private Dictionary<ISymbol, ISymbol> AliasToSymbolTable;
}
