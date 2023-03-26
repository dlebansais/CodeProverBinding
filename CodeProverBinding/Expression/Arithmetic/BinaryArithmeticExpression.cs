namespace CodeProverBinding;

using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Represents a binary arithmetic expression.
/// </summary>
public class BinaryArithmeticExpression : Expression, IBinaryArithmeticExpression, IArithmeticExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryArithmeticExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="leftOperand">The left operand.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="rightOperand">The right operand.</param>
    public BinaryArithmeticExpression(Binder binder, IArithmeticExpression leftOperand, BinaryArithmeticOperator @operator, IArithmeticExpression rightOperand)
        : base(binder)
    {
        Debug.Assert(@operator != BinaryArithmeticOperator.Modulo || (leftOperand is IIntegerExpression && rightOperand is IIntegerExpression));

        LeftOperand = leftOperand;
        Operator = @operator;
        RightOperand = rightOperand;

        Binder.Binding(Prover.Z3, (ProverContextZ3 context) =>
        {
            if (Operator == BinaryArithmeticOperator.Modulo)
            {
                bool IsLeftInteger = GetOperandExpressionZ3AsInteger(LeftOperand, out IIntExprCapsule LeftIntegerExpressionZ3);
                bool IsRightInteger = GetOperandExpressionZ3AsInteger(RightOperand, out IIntExprCapsule RightIntegerExpressionZ3);

                Debug.Assert(IsLeftInteger);
                Debug.Assert(IsRightInteger);

                ExpressionZ3 = (IExprCapsule)context.Context.MkMod(LeftIntegerExpressionZ3.Item, RightIntegerExpressionZ3.Item).Encapsulate();
            }
            else
            {
                Dictionary<BinaryArithmeticOperator, Func<IArithExprCapsule, IArithExprCapsule, IArithExprCapsule>> BinaryArithmetic = new()
                {
                    { BinaryArithmeticOperator.Add, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkAdd(left.Item, right.Item).Encapsulate() },
                    { BinaryArithmeticOperator.Subtract, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkSub(left.Item, right.Item).Encapsulate() },
                    { BinaryArithmeticOperator.Multiply, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkMul(left.Item, right.Item).Encapsulate() },
                    { BinaryArithmeticOperator.Divide, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkDiv(left.Item, right.Item).Encapsulate() },
                };

                ExpressionZ3 = (IExprCapsule)BinaryArithmetic[Operator]((IArithExprCapsule)((Expression)LeftOperand).ExpressionZ3, (IArithExprCapsule)((Expression)RightOperand).ExpressionZ3);
            }
        });
    }

    /// <inheritdoc/>
    public IArithmeticExpression LeftOperand { get; }

    /// <inheritdoc/>
    public BinaryArithmeticOperator Operator { get; }

    /// <inheritdoc/>
    public IArithmeticExpression RightOperand { get; }

    internal IArithExprCapsule ArithmeticExpressionZ3 => (IArithExprCapsule)ExpressionZ3;

    private bool GetOperandExpressionZ3AsInteger(IArithmeticExpression operand, out IIntExprCapsule integerExpressionZ3)
    {
        if (operand is Expression AsExpression && AsExpression.ExpressionZ3 is IIntExprCapsule ExpressionZ3)
        {
            integerExpressionZ3 = ExpressionZ3;
            return true;
        }

        integerExpressionZ3 = null!;
        return false;
    }
}
