namespace CodeProverBinding;

using System;
using System.Collections.Generic;

/// <summary>
/// Represents an equality expression.
/// </summary>
public class EqualityExpression : Expression, IEqualityExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EqualityExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="leftOperand">The left operand.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="rightOperand">The right operand.</param>
    public EqualityExpression(Binder binder, IExpression leftOperand, EqualityOperator @operator, IExpression rightOperand)
        : base(binder)
    {
        LeftOperand = leftOperand;
        Operator = @operator;
        RightOperand = rightOperand;

        Binder.Binding(Prover.Z3, (ProverContextZ3 context) =>
        {
            Dictionary<EqualityOperator, Func<IExprCapsule, IExprCapsule, IBoolExprCapsule>> EqualityArithmetic = new()
            {
                { EqualityOperator.Equal, (IExprCapsule left, IExprCapsule right) => context.Context.MkEq(left.Item, right.Item).Encapsulate() },
                { EqualityOperator.NotEqual, (IExprCapsule left, IExprCapsule right) => context.Context.MkNot(context.Context.MkEq(left.Item, right.Item)).Encapsulate() },
            };

            ExpressionZ3 = EqualityArithmetic[Operator](((Expression)LeftOperand).ExpressionZ3, ((Expression)RightOperand).ExpressionZ3);
        });
    }

    /// <inheritdoc/>
    public IExpression LeftOperand { get; }

    /// <inheritdoc/>
    public EqualityOperator Operator { get; }

    /// <inheritdoc/>
    public IExpression RightOperand { get; }

    internal IBoolExprCapsule BooleanExpressionZ3 => (IBoolExprCapsule)ExpressionZ3;
}
