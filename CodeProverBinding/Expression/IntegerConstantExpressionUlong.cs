namespace CodeProverBinding;

/// <summary>
/// Represents a 64-bits signed integer constant expression.
/// </summary>
public class IntegerConstantExpressionUlong : IntegerConstantExpression<ulong>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerConstantExpressionUlong"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="value">The constant value.</param>
    public IntegerConstantExpressionUlong(Binder binder, ulong value)
        : base(binder, value)
    {
        Binder.Binding(Prover.Z3, (ProverContextZ3 context) => { ExpressionZ3 = context.Context.MkInt(value).Encapsulate(); });
    }
}
