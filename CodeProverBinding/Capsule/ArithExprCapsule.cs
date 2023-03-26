namespace CodeProverBinding;

using Microsoft.Z3;

internal record ArithExprCapsule : IArithExprCapsule<ArithExpr>, IArithExprCapsule, IExprCapsule
{
    required public ArithExpr Item { get; init; }
    Expr IExprCapsule.Item { get => Item; }
}
