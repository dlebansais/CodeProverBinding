namespace CodeProverBinding;

using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Represents a unary arithmetic expression.
/// </summary>
public class UnaryArithmeticExpression : Expression, IUnaryArithmeticExpression, IArithmeticExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnaryArithmeticExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="operand">The operand.</param>
    public UnaryArithmeticExpression(Binder binder, UnaryArithmeticOperator @operator, IArithmeticExpression operand)
        : base(binder)
    {
        Operator = @operator;
        Operand = operand;

        Binder.Binding(Prover.Z3, (ProverContextZ3 context) =>
        {
            Dictionary<UnaryArithmeticOperator, Func<IArithExprCapsule, IArithExprCapsule>> UnaryArithmetic = new()
            {
                { UnaryArithmeticOperator.Minus, (IArithExprCapsule operand) => context.Context.MkUnaryMinus(operand.Item).Encapsulate() },
            };

            ExpressionZ3 = UnaryArithmetic[Operator]((IArithExprCapsule)((Expression)Operand).ExpressionZ3);
        });
    }

    /// <inheritdoc/>
    public UnaryArithmeticOperator Operator { get; }

    /// <inheritdoc/>
    public IArithmeticExpression Operand { get; }

    internal IArithExprCapsule ArithmeticExpressionZ3 => (IArithExprCapsule)ExpressionZ3;
}
