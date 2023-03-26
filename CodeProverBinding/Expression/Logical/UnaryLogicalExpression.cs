namespace CodeProverBinding;

using System;
using System.Collections.Generic;

/// <summary>
/// Represents a unary logical expression.
/// </summary>
public class UnaryLogicalExpression : Expression, IUnaryLogicalExpression, ILogicalExpression, IBooleanExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnaryLogicalExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="operand">The operand.</param>
    public UnaryLogicalExpression(Binder binder, UnaryLogicalOperator @operator, IBooleanExpression operand)
        : base(binder)
    {
        Operator = @operator;
        Operand = operand;

        Binder.Binding(Prover.Z3, (ProverContextZ3 context) =>
        {
            Dictionary<UnaryLogicalOperator, Func<IBoolExprCapsule, IBoolExprCapsule>> UnaryLogical = new()
            {
                { UnaryLogicalOperator.Not, (IBoolExprCapsule operand) => context.Context.MkNot(operand.Item).Encapsulate() },
            };

            ExpressionZ3 = (IExprCapsule)UnaryLogical[Operator]((IBoolExprCapsule)((Expression)Operand).ExpressionZ3);
        });
    }

    /// <inheritdoc/>
    public UnaryLogicalOperator Operator { get; }

    /// <inheritdoc/>
    public IBooleanExpression Operand { get; }

    internal IBoolExprCapsule LogicalExpressionZ3 => (IBoolExprCapsule)ExpressionZ3;
}
