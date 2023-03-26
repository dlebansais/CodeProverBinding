namespace CodeProverBinding;

/// <summary>
/// Represents a 32-bits signed integer constant expression.
/// </summary>
public class IntegerConstantExpressionInt : IntegerConstantExpression<int>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerConstantExpressionInt"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="value">The constant value.</param>
    public IntegerConstantExpressionInt(Binder binder, int value)
        : base(binder, value)
    {
        Binder.Binding(Prover.Z3, (ProverContextZ3 context) => { ExpressionZ3 = (IExprCapsule)context.Context.MkInt(value).Encapsulate(); });
    }
}
