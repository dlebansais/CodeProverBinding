namespace CodeProverBinding;

using Microsoft.Z3;

internal interface IExprCapsule
{
    Expr Item { get; }
}
