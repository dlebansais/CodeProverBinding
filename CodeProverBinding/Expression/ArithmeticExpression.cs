namespace CodeProverBinding;

using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Represents an arithmetic expression.
/// </summary>
public class ArithmeticExpression : Expression, IArithmeticExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ArithmeticExpression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    /// <param name="leftOperand">The left operand.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="rightOperand">The right operand.</param>
    public ArithmeticExpression(Binder binder, IArithmeticExpression leftOperand, ArithmeticOperator @operator, IArithmeticExpression rightOperand)
        : base(binder)
    {
        Debug.Assert(@operator != ArithmeticOperator.Modulo || (leftOperand is IIntegerExpression && rightOperand is IIntegerExpression));

        LeftOperand = leftOperand;
        Operator = @operator;
        RightOperand = rightOperand;

        Binder.Binding(Prover.Z3, (ProverContextZ3 context) =>
        {
            if (Operator == ArithmeticOperator.Modulo)
            {
                bool IsLeftInteger = GetOperandExpressionZ3AsInteger(LeftOperand, out IIntExprCapsule LeftIntegerExpressionZ3);
                bool IsRightInteger = GetOperandExpressionZ3AsInteger(RightOperand, out IIntExprCapsule RightIntegerExpressionZ3);

                Debug.Assert(IsLeftInteger);
                Debug.Assert(IsRightInteger);

                ExpressionZ3 = context.Context.MkMod(LeftIntegerExpressionZ3.Item, RightIntegerExpressionZ3.Item).Encapsulate();
            }
            else
            {
                Dictionary<ArithmeticOperator, Func<IArithExprCapsule, IArithExprCapsule, IArithExprCapsule>> BinaryArithmetic = new()
                {
                    { ArithmeticOperator.Add, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkAdd(left.Item, right.Item).Encapsulate() },
                    { ArithmeticOperator.Subtract, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkSub(left.Item, right.Item).Encapsulate() },
                    { ArithmeticOperator.Multiply, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkMul(left.Item, right.Item).Encapsulate() },
                    { ArithmeticOperator.Divide, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkDiv(left.Item, right.Item).Encapsulate() },
                };

                ExpressionZ3 = BinaryArithmetic[Operator]((IArithExprCapsule)((Expression)LeftOperand).ExpressionZ3, (IArithExprCapsule)((Expression)RightOperand).ExpressionZ3);
            }
        });
    }

    /// <inheritdoc/>
    public IArithmeticExpression LeftOperand { get; }

    /// <inheritdoc/>
    public ArithmeticOperator Operator { get; }

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
