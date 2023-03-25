﻿namespace CodeProverBinding;

using System;
using System.Collections.Generic;

/// <summary>
/// Represents a comparison expression.
/// </summary>
public class ComparisonExpression : Expression, IComparisonExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ComparisonExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="leftOperand">The left operand.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="rightOperand">The right operand.</param>
    public ComparisonExpression(Binder binder, IArithmeticExpression leftOperand, ComparisonOperator @operator, IArithmeticExpression rightOperand)
        : base(binder)
    {
        LeftOperand = leftOperand;
        Operator = @operator;
        RightOperand = rightOperand;

        Binder.Binding(Prover.Z3, (ProverContextZ3 context) =>
        {
            Dictionary<ComparisonOperator, Func<IArithExprCapsule, IArithExprCapsule, IBoolExprCapsule>> ComparisonArithmetic = new()
            {
                { ComparisonOperator.LessThan, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkLt(left.Item, right.Item).Encapsulate() },
                { ComparisonOperator.LessThanOrEqual, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkLe(left.Item, right.Item).Encapsulate() },
                { ComparisonOperator.GreaterThan, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkGt(left.Item, right.Item).Encapsulate() },
                { ComparisonOperator.GreaterThanOrEqual, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkGe(left.Item, right.Item).Encapsulate() },
            };

            ExpressionZ3 = ComparisonArithmetic[Operator]((IArithExprCapsule)((Expression)LeftOperand).ExpressionZ3, (IArithExprCapsule)((Expression)RightOperand).ExpressionZ3);
        });
    }

    /// <inheritdoc/>
    public IArithmeticExpression LeftOperand { get; }

    /// <inheritdoc/>
    public ComparisonOperator Operator { get; }

    /// <inheritdoc/>
    public IArithmeticExpression RightOperand { get; }

    internal IBoolExprCapsule BooleanExpressionZ3 => (IBoolExprCapsule)ExpressionZ3;
}
