namespace CodeProverBinding;

/// <summary>
/// Represents an expression.
/// </summary>
public abstract class Expression : IExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Expression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    public Expression(Binder binder)
    {
        Binder = binder;
    }

    /// <summary>
    /// Gets the binder.
    /// </summary>
    public Binder Binder { get; }

    internal IExprCapsule ExpressionZ3 { get; private protected set; } = null!;
}
