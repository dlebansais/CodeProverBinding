namespace CodeProverBinding;

using Microsoft.Z3;

internal interface IRefExprCapsule : IExprCapsule<IntExpr>
{
    ReferenceIndex Index { get; }
}
