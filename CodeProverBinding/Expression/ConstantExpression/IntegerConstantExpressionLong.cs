namespace CodeProverBinding;

/// <summary>
/// Represents a 64-bits signed integer constant expression.
/// </summary>
public class IntegerConstantExpressionLong : IntegerConstantExpression<long>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerConstantExpressionLong"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="value">The constant value.</param>
    public IntegerConstantExpressionLong(Binder binder, long value)
        : base(binder, value)
    {
        Binder.Binding(Prover.Z3, (ProverContextZ3 context) => { ExpressionZ3 = (IExprCapsule)context.Context.MkInt(value).Encapsulate(); });
    }
}
