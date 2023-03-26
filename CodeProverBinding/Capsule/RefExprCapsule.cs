namespace CodeProverBinding;

using Microsoft.Z3;

internal record RefExprCapsule : IRefExprCapsule, IExprCapsule
{
    required public IntExpr Item { get; init; }
    Expr IExprCapsule.Item { get => Item; }

    required public ReferenceIndex Index { get; init; }
}
