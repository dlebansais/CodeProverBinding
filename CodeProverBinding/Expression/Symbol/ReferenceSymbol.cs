namespace CodeProverBinding;

/// <summary>
/// Represents a reference symbol.
/// </summary>
public class ReferenceSymbol : Symbol<IReferenceSort>, IReferenceSymbol
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReferenceSymbol"/> class.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public ReferenceSymbol(string name)
        : base(name)
    {
    }

    /// <inheritdoc/>
    public override IReferenceSort Sort { get => CodeProverBinding.Sort.Reference; }
    ISort ISymbol.Sort { get => Sort; }
}
