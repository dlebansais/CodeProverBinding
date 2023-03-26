namespace CodeProverBinding;

/// <summary>
/// Represents an arithmetic symbol expression.
/// </summary>
/// <typeparam name="TSort">The symbol sort.</typeparam>
public class ArithmeticSymbolExpression<TSort> : SymbolExpression<TSort>, IArithmeticSymbolExpression<TSort>
    where TSort : IArithmeticSort
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ArithmeticSymbolExpression{TSort}"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="symbol">The symbol.</param>
    public ArithmeticSymbolExpression(Binder binder, ISymbol<TSort> symbol)
        : base(binder, symbol)
    {
    }

    internal IArithExprCapsule ArithmeticExpressionZ3 => (IArithExprCapsule)ExpressionZ3;
}
