namespace CodeProverBinding;

using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Represents a binary logical expression.
/// </summary>
public class BinaryLogicalExpression : Expression, IBinaryLogicalExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryLogicalExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="leftOperand">The left operand.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="rightOperand">The right operand.</param>
    public BinaryLogicalExpression(Binder binder, IBooleanExpression leftOperand, BinaryLogicalOperator @operator, IBooleanExpression rightOperand)
        : base(binder)
    {
        LeftOperand = leftOperand;
        Operator = @operator;
        RightOperand = rightOperand;

        Binder.Binding(Prover.Z3, (ProverContextZ3 context) =>
        {
            Dictionary<BinaryLogicalOperator, Func<IBoolExprCapsule, IBoolExprCapsule, IBoolExprCapsule>> BinaryLogical = new()
            {
                { BinaryLogicalOperator.And, (IBoolExprCapsule left, IBoolExprCapsule right) => context.Context.MkAnd(left.Item, right.Item).Encapsulate() },
                { BinaryLogicalOperator.Or, (IBoolExprCapsule left, IBoolExprCapsule right) => context.Context.MkOr(left.Item, right.Item).Encapsulate() },
                { BinaryLogicalOperator.Implies, (IBoolExprCapsule left, IBoolExprCapsule right) => context.Context.MkImplies(left.Item, right.Item).Encapsulate() },
            };

            ExpressionZ3 = (IExprCapsule)BinaryLogical[Operator]((IBoolExprCapsule)((Expression)LeftOperand).ExpressionZ3, (IBoolExprCapsule)((Expression)RightOperand).ExpressionZ3);
        });
    }

    /// <inheritdoc/>
    public IBooleanExpression LeftOperand { get; }

    /// <inheritdoc/>
    public BinaryLogicalOperator Operator { get; }

    /// <inheritdoc/>
    public IBooleanExpression RightOperand { get; }

    internal IBoolExprCapsule LogicalExpressionZ3 => (IBoolExprCapsule)ExpressionZ3;

    /// <inheritdoc/>
    public override string ToString()
    {
        Dictionary<BinaryLogicalOperator, string> OperatorTextTable = new()
        {
            { BinaryLogicalOperator.Or, "||" },
            { BinaryLogicalOperator.And, "&&" },
            { BinaryLogicalOperator.Implies, "=>" },
        };

        Debug.Assert(OperatorTextTable.ContainsKey(Operator));
        return $"({LeftOperand}) {OperatorTextTable[Operator]} ({RightOperand})";
    }
}
