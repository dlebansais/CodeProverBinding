namespace CodeProverBinding;

/// <summary>
/// Represents an integer symbol expression.
/// </summary>
public class XxxArraySymbolExpression : SymbolExpression<IIntegerSort>, IXxxArraySymbolExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="XxxArraySymbolExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="symbol">The symbol.</param>
    /// <param name="elementSort">The element sort.</param>
    public XxxArraySymbolExpression(Binder binder, IXxxArraySymbol symbol, ISort elementSort)
        : base(binder, symbol)
    {
        Binder.Binding(Prover.Z3, (ProverContextZ3 context) => { ExpressionZ3 = (IExprCapsule)context.Context.MkArrayConst(((ISymbol)symbol).Name, Sort.Integer.GetSortZ3(context), elementSort.GetSortZ3(context)).Encapsulate(); });
    }
}
