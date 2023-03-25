namespace CodeProverBinding;

/// <summary>
/// Represents an integer constant expression.
/// </summary>
public class IntegerConstantExpression : ConstantExpression<long>, IIntegerConstantExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerConstantExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="value">The constant value.</param>
    public IntegerConstantExpression(Binder binder, long value)
        : base(binder, value)
    {
        binder.Binding(Prover.Z3, (ProverContextZ3 context) => { Expression = context.Context.MkInt(value).Encapsulate(); });
    }

    internal IIntExprCapsule Expression { get; private set; } = null!;
}
