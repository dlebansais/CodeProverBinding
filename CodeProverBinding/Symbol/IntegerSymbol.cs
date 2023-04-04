namespace CodeProverBinding;

/// <summary>
/// Represents an integer symbol.
/// </summary>
public class IntegerSymbol : Symbol<IIntegerSort>, IIntegerSymbol
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerSymbol"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="name">The symbol name.</param>
    public IntegerSymbol(Binder binder, string name)
        : base(binder, name)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerSymbol"/> class.
    /// </summary>
    /// <param name="other">The source symbol.</param>
    public IntegerSymbol(IntegerSymbol other)
        : base(other)
    {
    }

    /// <summary>
    /// Creates a new symbol as an alias of the current symbol.
    /// </summary>
    public override ISymbol NewAlias()
    {
        return new IntegerSymbol(this);
    }

    /// <inheritdoc/>
    public override IIntegerSort Sort { get => CodeProverBinding.Sort.Integer; }
    ISort ISymbol.Sort { get => Sort; }
}
