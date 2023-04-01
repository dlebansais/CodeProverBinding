namespace CodeProverBinding;

/// <summary>
/// Represents a boolean symbol.
/// </summary>
public class XxxArraySymbol : Symbol<IIntegerSort>, IXxxArraySymbol
{
    /// <summary>
    /// Initializes a new instance of the <see cref="XxxArraySymbol"/> class.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public XxxArraySymbol(string name)
        : base(name)
    {
    }

    /// <inheritdoc/>
    public override IIntegerSort Sort { get => CodeProverBinding.Sort.Integer; }
    ISort ISymbol.Sort { get => Sort; }
}
