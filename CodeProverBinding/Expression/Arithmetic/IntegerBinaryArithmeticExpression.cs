namespace CodeProverBinding;

using System;
using System.Collections.Generic;

/// <summary>
/// Represents an integer binary arithmetic expression.
/// </summary>
public class IntegerBinaryArithmeticExpression : BinaryArithmeticExpression, IIntegerExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegerBinaryArithmeticExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="leftOperand">The left operand.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="rightOperand">The right operand.</param>
    public IntegerBinaryArithmeticExpression(Binder binder, IIntegerExpression leftOperand, BinaryArithmeticOperator @operator, IIntegerExpression rightOperand)
        : base(binder, leftOperand, @operator, rightOperand)
    {
    }

    private protected override IArithExprCapsule CombineZ3Operands(ProverContextZ3 context)
    {
        Dictionary<BinaryArithmeticOperator, Func<IIntExprCapsule, IIntExprCapsule, IIntExprCapsule>> BinaryArithmetic = new()
        {
            { BinaryArithmeticOperator.Add, (IIntExprCapsule left, IIntExprCapsule right) => (IIntExprCapsule)context.Context.MkAdd(left.Item, right.Item).Encapsulate() },
            { BinaryArithmeticOperator.Subtract, (IIntExprCapsule left, IIntExprCapsule right) => (IIntExprCapsule)context.Context.MkSub(left.Item, right.Item).Encapsulate() },
            { BinaryArithmeticOperator.Multiply, (IIntExprCapsule left, IIntExprCapsule right) => (IIntExprCapsule)context.Context.MkMul(left.Item, right.Item).Encapsulate() },
            { BinaryArithmeticOperator.Divide, (IIntExprCapsule left, IIntExprCapsule right) => (IIntExprCapsule)context.Context.MkDiv(left.Item, right.Item).Encapsulate() },
            { BinaryArithmeticOperator.Modulo, (IIntExprCapsule left, IIntExprCapsule right) => (IIntExprCapsule)context.Context.MkMod(left.Item, right.Item).Encapsulate() },
        };

        return (IArithExprCapsule)BinaryArithmetic[Operator]((IIntExprCapsule)((Expression)LeftOperand).ExpressionZ3, (IIntExprCapsule)((Expression)RightOperand).ExpressionZ3);
    }

    internal IIntExprCapsule IntegerExpressionZ3 => (IIntExprCapsule)ExpressionZ3;
}
