namespace CodeProverBinding;

/// <summary>
/// Represents a boolean constant expression.
/// </summary>
public class XxxArrayConstantExpression : ConstantExpression<int>, IXxxArrayConstantExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="XxxArrayConstantExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="value">The initializer.</param>
    public XxxArrayConstantExpression(Binder binder, IExpression value)
        : base(binder, 0)
    {
        Binder.Binding(Prover.Z3, (ProverContextZ3 context) => { ExpressionZ3 = (IExprCapsule)context.Context.MkConstArray(Sort.Integer.GetSortZ3(context), ((Expression)value).ExpressionZ3.Item).Encapsulate(); });
    }

    internal IBoolExprCapsule BooleanExpressionZ3 => (IBoolExprCapsule)ExpressionZ3;
}
