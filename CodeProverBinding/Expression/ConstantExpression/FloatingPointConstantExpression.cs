namespace CodeProverBinding;

using System.Globalization;
using Microsoft.Z3;

/// <summary>
/// Represents an floating point constant expression.
/// </summary>
public class FloatingPointConstantExpression : ConstantExpression<double>, IFloatingPointConstantExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FloatingPointConstantExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="value">The constant value.</param>
    public FloatingPointConstantExpression(Binder binder, double value)
        : base(binder, value)
    {
        Binder.Binding(Prover.Z3, (ProverContextZ3 context) => { ExpressionZ3 = (IExprCapsule)((ArithExpr)context.Context.MkNumeral(value.ToString(CultureInfo.InvariantCulture), context.Context.MkRealSort())).Encapsulate(); });
    }

    internal IArithExprCapsule ArithmeticExpressionZ3 => (IArithExprCapsule)ExpressionZ3;
}
