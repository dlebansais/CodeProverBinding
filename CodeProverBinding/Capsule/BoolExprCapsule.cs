namespace CodeProverBinding;

using Microsoft.Z3;

internal record BoolExprCapsule : IBoolExprCapsule, IExprCapsule
{
    required public BoolExpr Item { get; init; }
    Expr IExprCapsule.Item { get => Item; }
}
