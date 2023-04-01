namespace CodeProverBinding;

using System;
using Microsoft.Z3;

internal interface IExprCapsule<TExpr> : IDisposable
    where TExpr : Expr
{
    TExpr Item { get; }
}
