namespace CodeProverBinding;

/// <summary>
/// Represents an integer symbol.
/// </summary>
public class IntegerSymbol : Symbol<IIntegerSort>, IIntegerSymbol
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerSymbol"/> class.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public IntegerSymbol(string name)
        : base(name)
    {
    }

    /// <inheritdoc/>
    public override IIntegerSort Sort { get => CodeProverBinding.Sort.Integer; }
    ISort ISymbol.Sort { get => Sort; }
}
