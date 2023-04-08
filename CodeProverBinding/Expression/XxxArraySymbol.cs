namespace CodeProverBinding;

/// <summary>
/// Represents a boolean symbol.
/// </summary>
public record XxxArraySymbol : Symbol<IIntegerSort>, IXxxArraySymbol
{
    /// <summary>
    /// Initializes a new instance of the <see cref="XxxArraySymbol"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="name">The symbol name.</param>
    public XxxArraySymbol(Binder binder, string name)
        : base(binder, name)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XxxArraySymbol"/> class.
    /// </summary>
    /// <param name="other">The source symbol.</param>
    public XxxArraySymbol(XxxArraySymbol other)
        : base(other)
    {
    }

    /// <summary>
    /// Creates a new symbol as an alias of the current symbol.
    /// </summary>
    public override ISymbol NewAlias()
    {
        return new XxxArraySymbol(this);
    }

    /// <inheritdoc/>
    public override IIntegerSort Sort { get => CodeProverBinding.Sort.Integer; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return Binder.AliasNaming.GetAliasName((ISymbol)this);
    }
}
