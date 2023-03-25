﻿namespace CodeProverBinding;

using System.Globalization;

/// <summary>
/// Represents an floating point constant expression.
/// </summary>
public class FloatingPointConstantExpression : ConstantExpression<double>, IFloatingPointConstantExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FloatingPointConstantExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="value">The constant value.</param>
    public FloatingPointConstantExpression(Binder binder, double value)
        : base(binder, value)
    {
        binder.Binding(Prover.Z3, (ProverContextZ3 context) => { Expression = ((Microsoft.Z3.ArithExpr)context.Context.MkNumeral(value.ToString(CultureInfo.InvariantCulture), context.Context.MkRealSort())).Encapsulate(); });
    }

    internal IArithExprCapsule Expression { get; private set; } = null!;
}
