namespace CodeProverBinding;

/// <summary>
/// Represents a reference symbol expression.
/// </summary>
public class ReferenceSymbolExpression : SymbolExpression<IReferenceSort>, IReferenceSymbolExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReferenceSymbolExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="symbol">The symbol.</param>
    public ReferenceSymbolExpression(Binder binder, IReferenceSymbol symbol)
        : base(binder, symbol)
    {
        Binder.Binding(Prover.Z3, (ProverContextZ3 context) => { ExpressionZ3 = (IExprCapsule)context.Context.MkIntConst(((ISymbol)symbol).Name).Encapsulate(); });
    }

    internal IIntExprCapsule ReferenceExpressionZ3 => (IIntExprCapsule)ExpressionZ3;
}
