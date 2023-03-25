namespace CodeProverBinding;

using Microsoft.Z3;

internal interface IArithExprCapsule : IExprCapsule
{
    new ArithExpr Item { get; }
}
