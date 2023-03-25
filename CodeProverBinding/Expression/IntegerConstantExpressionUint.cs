namespace CodeProverBinding;

/// <summary>
/// Represents a 32-bits unsigned integer constant expression.
/// </summary>
public class IntegerConstantExpressionUint : IntegerConstantExpression<uint>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerConstantExpressionUint"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="value">The constant value.</param>
    public IntegerConstantExpressionUint(Binder binder, uint value)
        : base(binder, value)
    {
        Binder.Binding(Prover.Z3, (ProverContextZ3 context) => { ExpressionZ3 = context.Context.MkInt(value).Encapsulate(); });
    }
}
