namespace CodeProverBinding;

using System;
using Microsoft.Z3;

internal interface IExprCapsule : IDisposable
{
    Expr Item { get; }
}
