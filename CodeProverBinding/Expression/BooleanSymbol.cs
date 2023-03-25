namespace CodeProverBinding;

/// <summary>
/// Represents a boolean symbol.
/// </summary>
public class BooleanSymbol : Symbol<IBooleanSort>, IBooleanSymbol
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BooleanSymbol"/> class.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public BooleanSymbol(string name)
        : base(name)
    {
    }

    /// <inheritdoc/>
    public override IBooleanSort Sort { get => CodeProverBinding.Sort.Boolean; }
    ISort ISymbol.Sort { get => Sort; }
}
