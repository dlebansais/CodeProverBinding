namespace CodeProverBinding;

using System.Diagnostics;

/// <summary>
/// Represents a symbol.
/// </summary>
/// <typeparam name="TSort">The sort.</typeparam>
public abstract class Symbol<TSort> : SymbolBase, ISymbol<TSort>, ISymbol
    where TSort : ISort
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Symbol{TSort}"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="name">The symbol name.</param>
    public Symbol(Binder binder, string name)
    {
        Debug.Assert(name != string.Empty);

        Binder = binder;
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Symbol{TSort}"/> class.
    /// </summary>
    /// <param name="other">The source symbol.</param>
    public Symbol(Symbol<TSort> other)
    {
        Binder = other.Binder;
        Name = other.Name;
        Index = other.Index + 1;

        Binder.AliasTable.SetAlias(other, this);
    }

    /// <inheritdoc/>
    public Binder Binder { get; }

    /// <inheritdoc/>
    public string Name { get; }

    /// <inheritdoc/>
    public abstract TSort Sort { get; }
    ISort ISymbol.Sort => Sort;

    /// <inheritdoc/>
    public override string ToString()
    {
        return Binder.AliasNaming.GetAliasName((ISymbol)this);
    }
}
