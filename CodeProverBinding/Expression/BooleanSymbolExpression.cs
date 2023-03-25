﻿namespace CodeProverBinding;

/// <summary>
/// Represents a boolean symbol expression.
/// </summary>
public class BooleanSymbolExpression : SymbolExpression<IBooleanSort>, IBooleanSymbolExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BooleanSymbolExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="symbol">The symbol.</param>
    public BooleanSymbolExpression(Binder binder, IBooleanSymbol symbol)
        : base(binder, symbol)
    {
    }
}