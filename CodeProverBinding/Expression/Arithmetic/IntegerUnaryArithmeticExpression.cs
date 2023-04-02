namespace CodeProverBinding;

using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Represents a unary arithmetic expression.
/// </summary>
public class IntegerUnaryArithmeticExpression : UnaryArithmeticExpression, IIntegerExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerUnaryArithmeticExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="operand">The operand.</param>
    public IntegerUnaryArithmeticExpression(Binder binder, UnaryArithmeticOperator @operator, IIntegerExpression operand)
        : base(binder, @operator, operand)
    {
    }

    private protected override IArithExprCapsule CombineZ3Operands(ProverContextZ3 context)
    {
        Dictionary<UnaryArithmeticOperator, Func<IIntExprCapsule, IIntExprCapsule>> UnaryArithmetic = new()
        {
            { UnaryArithmeticOperator.Minus, (IIntExprCapsule operand) => (IIntExprCapsule)context.Context.MkUnaryMinus(operand.Item).Encapsulate() },
        };

        return (IArithExprCapsule)UnaryArithmetic[Operator]((IIntExprCapsule)((Expression)Operand).ExpressionZ3);
    }

    internal IIntExprCapsule IntegerExpressionZ3 => (IIntExprCapsule)ExpressionZ3;
}
