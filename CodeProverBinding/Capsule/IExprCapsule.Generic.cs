namespace CodeProverBinding;

using Microsoft.Z3;

internal interface IExprCapsule<TExpr>
    where TExpr : Expr
{
    TExpr Item { get; }
}
