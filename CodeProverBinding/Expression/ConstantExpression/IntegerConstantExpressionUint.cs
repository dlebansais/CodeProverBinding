namespace CodeProverBinding;

/// <summary>
/// Represents a 32-bits unsigned integer constant expression.
/// </summary>
public class IntegerConstantExpressionUInt : IntegerConstantExpression<uint>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerConstantExpressionUInt"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="value">The constant value.</param>
    public IntegerConstantExpressionUInt(Binder binder, uint value)
        : base(binder, value)
    {
        Binder.Binding(Prover.Z3, (ProverContextZ3 context) => { ExpressionZ3 = (IExprCapsule)context.Context.MkInt(value).Encapsulate(); });
    }
}
