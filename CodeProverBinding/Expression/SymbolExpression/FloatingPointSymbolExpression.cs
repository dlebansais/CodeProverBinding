﻿namespace CodeProverBinding;

/// <summary>
/// Represents an floating point symbol expression.
/// </summary>
public class FloatingPointSymbolExpression : ArithmeticSymbolExpression<IFloatingPointSort>, IFloatingPointSymbolExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FloatingPointSymbolExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="symbol">The symbol.</param>
    public FloatingPointSymbolExpression(Binder binder, IFloatingPointSymbol symbol)
        : base(binder, symbol)
    {
        Binder.Binding(Prover.Z3, (ProverContextZ3 context) => { ExpressionZ3 = (IExprCapsule)context.Context.MkRealConst(((ISymbol)symbol).Name).Encapsulate(); });
    }
}
