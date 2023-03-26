namespace CodeProverBinding;

using Microsoft.Z3;

internal interface IArithExprCapsule<TExpr> : IExprCapsule<TExpr>
    where TExpr : ArithExpr
{
}
