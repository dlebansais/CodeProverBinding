namespace CodeProverBinding;

using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Represents a binary arithmetic expression.
/// </summary>
public class BinaryArithmeticExpression : Expression, IBinaryArithmeticExpression
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
            ExpressionZ3 = (IExprCapsule)CombineZ3Operands(context);
        });
    }

    /// <inheritdoc/>
    public IArithmeticExpression LeftOperand { get; }

    /// <inheritdoc/>
    public BinaryArithmeticOperator Operator { get; }

    /// <inheritdoc/>
    public IArithmeticExpression RightOperand { get; }

    internal IArithExprCapsule ArithmeticExpressionZ3 => (IArithExprCapsule)ExpressionZ3;

    private protected virtual IArithExprCapsule CombineZ3Operands(ProverContextZ3 context)
    {
        Debug.Assert(Operator != BinaryArithmeticOperator.Modulo);

        Dictionary<BinaryArithmeticOperator, Func<IArithExprCapsule, IArithExprCapsule, IArithExprCapsule>> BinaryArithmetic = new()
        {
            { BinaryArithmeticOperator.Add, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkAdd(left.Item, right.Item).Encapsulate() },
            { BinaryArithmeticOperator.Subtract, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkSub(left.Item, right.Item).Encapsulate() },
            { BinaryArithmeticOperator.Multiply, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkMul(left.Item, right.Item).Encapsulate() },
            { BinaryArithmeticOperator.Divide, (IArithExprCapsule left, IArithExprCapsule right) => context.Context.MkDiv(left.Item, right.Item).Encapsulate() },
        };

        return BinaryArithmetic[Operator]((IArithExprCapsule)((Expression)LeftOperand).ExpressionZ3, (IArithExprCapsule)((Expression)RightOperand).ExpressionZ3);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        Dictionary<BinaryArithmeticOperator, string> OperatorTextTable = new()
        {
            { BinaryArithmeticOperator.Add, "+" },
            { BinaryArithmeticOperator.Subtract, "-" },
            { BinaryArithmeticOperator.Multiply, "*" },
            { BinaryArithmeticOperator.Divide, "/" },
            { BinaryArithmeticOperator.Modulo, "%" },
        };

        Debug.Assert(OperatorTextTable.ContainsKey(Operator));
        return $"({LeftOperand}) {OperatorTextTable[Operator]} ({RightOperand})";
    }
}
