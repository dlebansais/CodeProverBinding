namespace CodeProverBinding;

/// <summary>
/// Represents a floating point symbol.
/// </summary>
public class FloatingPointSymbol : Symbol<IFloatingPointSort>, IFloatingPointSymbol
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FloatingPointSymbol"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="name">The symbol name.</param>
    public FloatingPointSymbol(Binder binder, string name)
        : base(binder, name)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FloatingPointSymbol"/> class.
    /// </summary>
    /// <param name="other">The source symbol.</param>
    public FloatingPointSymbol(FloatingPointSymbol other)
        : base(other)
    {
    }

    /// <summary>
    /// Creates a new symbol as an alias of the current symbol.
    /// </summary>
    public override ISymbol NewAlias()
    {
        return new FloatingPointSymbol(this);
    }

    /// <inheritdoc/>
    public override IFloatingPointSort Sort { get => CodeProverBinding.Sort.FloatingPoint; }
}
