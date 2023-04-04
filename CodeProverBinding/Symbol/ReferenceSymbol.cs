namespace CodeProverBinding;

/// <summary>
/// Represents a reference symbol.
/// </summary>
public class ReferenceSymbol : Symbol<IReferenceSort>, IReferenceSymbol
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReferenceSymbol"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="name">The symbol name.</param>
    public ReferenceSymbol(Binder binder, string name)
        : base(binder, name)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ReferenceSymbol"/> class.
    /// </summary>
    /// <param name="other">The source symbol.</param>
    public ReferenceSymbol(ReferenceSymbol other)
        : base(other)
    {
    }

    /// <summary>
    /// Creates a new symbol as an alias of the current symbol.
    /// </summary>
    public override ISymbol NewAlias()
    {
        return new ReferenceSymbol(this);
    }

    /// <inheritdoc/>
    public override IReferenceSort Sort { get => CodeProverBinding.Sort.Reference; }
    ISort ISymbol.Sort { get => Sort; }
}
