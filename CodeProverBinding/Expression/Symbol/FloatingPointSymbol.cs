namespace CodeProverBinding;

/// <summary>
/// Represents a floating point symbol.
/// </summary>
public class FloatingPointSymbol : Symbol<IFloatingPointSort>, IFloatingPointSymbol
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FloatingPointSymbol"/> class.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public FloatingPointSymbol(string name)
        : base(name)
    {
    }

    /// <inheritdoc/>
    public override IFloatingPointSort Sort { get => CodeProverBinding.Sort.FloatingPoint; }
    ISort ISymbol.Sort { get => Sort; }
}
