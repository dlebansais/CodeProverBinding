namespace CodeProverBinding;

/// <summary>
/// Represents a reference constant expression.
/// </summary>
public class ReferenceConstantExpression : ConstantExpression<Reference>, IReferenceConstantExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReferenceConstantExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="value">The constant value.</param>
    public ReferenceConstantExpression(Binder binder, Reference value)
        : base(binder, value)
    {
        Binder.Binding(Prover.Z3, (ProverContextZ3 context) => { ExpressionZ3 = (IExprCapsule)context.Context.MkInt(value.Internal).EncapsulateAsRef(value); });
    }

    internal IIntExprCapsule ReferenceExpressionZ3 => (IIntExprCapsule)ExpressionZ3;
}
