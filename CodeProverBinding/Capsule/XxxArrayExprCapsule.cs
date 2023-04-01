namespace CodeProverBinding;

using Microsoft.Z3;

internal record XxxArrayExprCapsule : IXxxArrayExprCapsule, IExprCapsule
{
    required public Expr Item { get; init; }
    Expr IExprCapsule.Item { get => Item; }

    public void Dispose()
    {
        Item.Dispose();
    }
}
