namespace CodeProverBinding;

/// <summary>
/// Represents an boolean constant expression.
/// </summary>
public class BooleanConstantExpression : ConstantExpression<bool>, IBooleanConstantExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BooleanConstantExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="value">The constant value.</param>
    public BooleanConstantExpression(Binder binder, bool value)
        : base(binder, value)
    {
        binder.Binding(Prover.Z3, (ProverContextZ3 context) => { ExpressionZ3 = context.Context.MkBool(value).Encapsulate(); });
    }

    internal IBoolExprCapsule BooleanExpressionZ3 => (IBoolExprCapsule)ExpressionZ3;
}
