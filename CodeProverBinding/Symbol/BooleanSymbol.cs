namespace CodeProverBinding;

/// <summary>
/// Represents a boolean symbol.
/// </summary>
public class BooleanSymbol : Symbol<IBooleanSort>, IBooleanSymbol
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BooleanSymbol"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="name">The symbol name.</param>
    public BooleanSymbol(Binder binder, string name)
        : base(binder, name)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BooleanSymbol"/> class.
    /// </summary>
    /// <param name="other">The source symbol.</param>
    public BooleanSymbol(BooleanSymbol other)
        : base(other)
    {
    }

    /// <summary>
    /// Creates a new symbol as an alias of the current symbol.
    /// </summary>
    public override ISymbol NewAlias()
    {
        return new BooleanSymbol(this);
    }

    /// <inheritdoc/>
    public override IBooleanSort Sort { get => CodeProverBinding.Sort.Boolean; }
    ISort ISymbol.Sort { get => Sort; }
}
