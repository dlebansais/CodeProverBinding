namespace CodeProverBinding;

using Microsoft.Z3;

internal record IntExprCapsule : IIntExprCapsule, IExprCapsule<IntExpr>, IArithExprCapsule, IExprCapsule
{
    required public IntExpr Item { get; init; }
    ArithExpr IExprCapsule<ArithExpr>.Item { get => Item; }
    Expr IExprCapsule.Item { get => Item; }

    public void Dispose()
    {
        Item.Dispose();
    }
}
