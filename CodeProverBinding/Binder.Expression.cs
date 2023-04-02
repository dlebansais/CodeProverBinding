namespace CodeProverBinding;

using System;
using System.Collections.Generic;

/// <summary>
/// Provides bindings for code provers.
/// </summary>
public partial class Binder
{
    /// <summary>
    /// Gets the constant representing the boolean false.
    /// </summary>
    public IBooleanConstantExpression False { get; private set; } = null!;

    /// <summary>
    /// Gets the constant representing the boolean true.
    /// </summary>
    public IBooleanConstantExpression True { get; private set; } = null!;

    /// <summary>
    /// Gets the constant representing the integer 0.
    /// </summary>
    public IIntegerConstantExpression Zero { get; private set; } = null!;

    /// <summary>
    /// Gets the constant representing the integer 0.
    /// </summary>
    public IFloatingPointConstantExpression FloatingPointZero { get; private set; } = null!;

    /// <summary>
    /// Gets the constant representing the null reference.
    /// </summary>
    public IReferenceConstantExpression Null { get; private set; } = null!;

    /// <summary>
    /// Gets the boolean constant expression corresponding to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The constant value.</param>
    public IBooleanConstantExpression GetBooleanConstant(bool value)
    {
        if (!ConstantTable.ContainsKey(value))
            ConstantTable[value] = new BooleanConstantExpression(this, value);

        return (IBooleanConstantExpression)ConstantTable[value];
    }

    /// <summary>
    /// Gets the integer constant expression corresponding to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The constant value.</param>
    public IIntegerConstantExpression GetIntegerConstant(int value)
    {
        if (!ConstantTable.ContainsKey(value))
            ConstantTable[value] = new IntegerConstantExpressionInt(this, value);

        return (IIntegerConstantExpression)ConstantTable[value];
    }

    /// <summary>
    /// Gets the integer constant expression corresponding to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The constant value.</param>
    public IIntegerConstantExpression GetIntegerConstant(long value)
    {
        if (!ConstantTable.ContainsKey(value))
            ConstantTable[value] = new IntegerConstantExpressionLong(this, value);

        return (IIntegerConstantExpression)ConstantTable[value];
    }

    /// <summary>
    /// Gets the integer constant expression corresponding to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The constant value.</param>
    public IIntegerConstantExpression GetIntegerConstant(uint value)
    {
        if (!ConstantTable.ContainsKey(value))
            ConstantTable[value] = new IntegerConstantExpressionUInt(this, value);

        return (IIntegerConstantExpression)ConstantTable[value];
    }

    /// <summary>
    /// Gets the integer constant expression corresponding to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The constant value.</param>
    public IIntegerConstantExpression GetIntegerConstant(ulong value)
    {
        if (!ConstantTable.ContainsKey(value))
            ConstantTable[value] = new IntegerConstantExpressionULong(this, value);

        return (IIntegerConstantExpression)ConstantTable[value];
    }

    /// <summary>
    /// Gets the floating point constant expression corresponding to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The constant value.</param>
    public IFloatingPointConstantExpression GetFloatingPointConstant(double value)
    {
        if (!ConstantTable.ContainsKey(value))
            ConstantTable[value] = new FloatingPointConstantExpression(this, value);

        return (IFloatingPointConstantExpression)ConstantTable[value];
    }

    /// <summary>
    /// Gets the reference constant expression corresponding to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The constant value.</param>
    public IReferenceConstantExpression GetReferenceConstant(Reference value)
    {
        if (!ConstantTable.ContainsKey(value))
            ConstantTable[value] = new ReferenceConstantExpression(this, value);

        return (IReferenceConstantExpression)ConstantTable[value];
    }

    /// <summary>
    /// Creates an array constant expression.
    /// </summary>
    /// <param name="value">The initializer.</param>
    public IXxxArrayConstantExpression GetXxxArrayConstantExpression(IExpression value)
    {
        return new XxxArrayConstantExpression(this, value);
    }

    /// <summary>
    /// Creates a boolean symbol with name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public IBooleanSymbol CreateBooleanSymbol(string name)
    {
        return new BooleanSymbol(name);
    }

    /// <summary>
    /// Creates an integer symbol with name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public IIntegerSymbol CreateIntegerSymbol(string name)
    {
        return new IntegerSymbol(name);
    }

    /// <summary>
    /// Creates a floating point symbol with name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public IFloatingPointSymbol CreateFloatingPointSymbol(string name)
    {
        return new FloatingPointSymbol(name);
    }

    /// <summary>
    /// Creates a reference symbol with name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public IReferenceSymbol CreateReferenceSymbol(string name)
    {
        return new ReferenceSymbol(name);
    }

    /// <summary>
    /// Creates a boolean symbol expression with name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public IBooleanSymbolExpression CreateBooleanSymbolExpression(string name)
    {
        return new BooleanSymbolExpression(this, new BooleanSymbol(name));
    }

    /// <summary>
    /// Creates an integer symbol expression with name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public IIntegerSymbolExpression CreateIntegerSymbolExpression(string name)
    {
        return new IntegerSymbolExpression(this, new IntegerSymbol(name));
    }

    /// <summary>
    /// Creates a floating point symbol expression with name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public IFloatingPointSymbolExpression CreateFloatingPointSymbolExpression(string name)
    {
        return new FloatingPointSymbolExpression(this, new FloatingPointSymbol(name));
    }

    /// <summary>
    /// Creates a reference symbol expression with name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public IReferenceSymbolExpression CreateReferenceSymbolExpression(string name)
    {
        return new ReferenceSymbolExpression(this, new ReferenceSymbol(name));
    }

    /// <summary>
    /// Creates an object reference symbol expression with name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public IObjectReferenceSymbolExpression CreateObjectReferenceSymbolExpression(string name)
    {
        return new ObjectReferenceSymbolExpression(this, new ReferenceSymbol(name));
    }

    /// <summary>
    /// Creates an array reference symbol expression with name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public IArrayReferenceSymbolExpression CreateArrayReferenceSymbolExpression(string name)
    {
        return new ArrayReferenceSymbolExpression(this, new ReferenceSymbol(name));
    }

    /// <summary>
    /// Creates an array reference symbol expression with name <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    /// <param name="elementSort">The element sort.</param>
    public IXxxArraySymbolExpression CreateXxxArraySymbolExpression(string name, ISort elementSort)
    {
        return new XxxArraySymbolExpression(this, new XxxArraySymbol(name), elementSort);
    }

    /// <summary>
    /// Creates a boolean symbol expression with symbol <paramref name="symbol"/>.
    /// </summary>
    /// <param name="symbol">The symbol.</param>
    public IBooleanSymbolExpression CreateBooleanSymbolExpression(IBooleanSymbol symbol)
    {
        return new BooleanSymbolExpression(this, symbol);
    }

    /// <summary>
    /// Creates an integer symbol expression with symbol <paramref name="symbol"/>.
    /// </summary>
    /// <param name="symbol">The symbol.</param>
    public IIntegerSymbolExpression CreateIntegerSymbolExpression(IIntegerSymbol symbol)
    {
        return new IntegerSymbolExpression(this, symbol);
    }

    /// <summary>
    /// Creates a floating point symbol expression with symbol <paramref name="symbol"/>.
    /// </summary>
    /// <param name="symbol">The symbol.</param>
    public IFloatingPointSymbolExpression CreateFloatingPointSymbolExpression(IFloatingPointSymbol symbol)
    {
        return new FloatingPointSymbolExpression(this, symbol);
    }

    /// <summary>
    /// Creates a reference symbol expression with symbol <paramref name="symbol"/>.
    /// </summary>
    /// <param name="symbol">The symbol.</param>
    public IReferenceSymbolExpression CreateReferenceSymbolExpression(IReferenceSymbol symbol)
    {
        return new ReferenceSymbolExpression(this, symbol);
    }

    /// <summary>
    /// Creates an object reference symbol expression with symbol <paramref name="symbol"/>.
    /// </summary>
    /// <param name="symbol">The symbol.</param>
    public IObjectReferenceSymbolExpression CreateObjectReferenceSymbolExpression(IReferenceSymbol symbol)
    {
        return new ObjectReferenceSymbolExpression(this, symbol);
    }

    /// <summary>
    /// Creates an array reference symbol expression with symbol <paramref name="symbol"/>.
    /// </summary>
    /// <param name="symbol">The symbol.</param>
    public IArrayReferenceSymbolExpression CreateArrayReferenceSymbolExpression(IReferenceSymbol symbol)
    {
        return new ArrayReferenceSymbolExpression(this, symbol);
    }

    /// <summary>
    /// Creates a binary arithmetic expression.
    /// </summary>
    /// <param name="leftOperand">The left operand.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="rightOperand">The right operand.</param>
    /// <exception cref="ArgumentException">The modulo operator is only supported with integer operands.</exception>
    public IBinaryArithmeticExpression CreateBinaryArithmeticExpression(IArithmeticExpression leftOperand, BinaryArithmeticOperator @operator, IArithmeticExpression rightOperand)
    {
        bool IsLeftInteger = GetOperandExpressionAsInteger(leftOperand, out IIntegerExpression LeftIntegerOperand);
        bool IsRightInteger = GetOperandExpressionAsInteger(rightOperand, out IIntegerExpression RightIntegerOperand);

        if (IsLeftInteger && IsRightInteger)
            return new IntegerBinaryArithmeticExpression(this, LeftIntegerOperand, @operator, RightIntegerOperand);
        else
        {
            if (@operator == BinaryArithmeticOperator.Modulo)
                throw new ArgumentException("The modulo operator is only supported with integer operands.");

            return new BinaryArithmeticExpression(this, leftOperand, @operator, rightOperand);
        }
    }

    /// <summary>
    /// Creates a unary arithmetic expression.
    /// </summary>
    /// <param name="operator">The operator.</param>
    /// <param name="operand">The operand.</param>
    public IUnaryArithmeticExpression CreateUnaryArithmeticExpression(UnaryArithmeticOperator @operator, IArithmeticExpression operand)
    {
        bool IsInteger = GetOperandExpressionAsInteger(operand, out IIntegerExpression IntegerOperand);

        if (IsInteger)
            return new IntegerUnaryArithmeticExpression(this, @operator, IntegerOperand);
        else
            return new UnaryArithmeticExpression(this, @operator, operand);
    }

    /// <summary>
    /// Creates a binary logical expression.
    /// </summary>
    /// <param name="leftOperand">The left operand.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="rightOperand">The right operand.</param>
    public IBinaryLogicalExpression CreateBinaryLogicalExpression(IBooleanExpression leftOperand, BinaryLogicalOperator @operator, IBooleanExpression rightOperand)
    {
        return new BinaryLogicalExpression(this, leftOperand, @operator, rightOperand);
    }

    /// <summary>
    /// Creates a unary logical expression.
    /// </summary>
    /// <param name="operator">The operator.</param>
    /// <param name="operand">The right operand.</param>
    public IUnaryLogicalExpression CreateUnaryLogicalExpression(UnaryLogicalOperator @operator, IBooleanExpression operand)
    {
        return new UnaryLogicalExpression(this, @operator, operand);
    }

    /// <summary>
    /// Creates a comparison expression.
    /// </summary>
    /// <param name="leftOperand">The left operand.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="rightOperand">The right operand.</param>
    public IComparisonExpression CreateComparisonExpression(IArithmeticExpression leftOperand, ComparisonOperator @operator, IArithmeticExpression rightOperand)
    {
        return new ComparisonExpression(this, leftOperand, @operator, rightOperand);
    }

    /// <summary>
    /// Creates an equality expression.
    /// </summary>
    /// <param name="leftOperand">The left operand.</param>
    /// <param name="operator">The operator.</param>
    /// <param name="rightOperand">The right operand.</param>
    public IEqualityExpression CreateEqualityExpression(IExpression leftOperand, EqualityOperator @operator, IExpression rightOperand)
    {
        return new EqualityExpression(this, leftOperand, @operator, rightOperand);
    }

    private bool GetOperandExpressionAsInteger(IArithmeticExpression operand, out IIntegerExpression integerOperand)
    {
        if (operand is IIntegerExpression AsIntegerOperand)
        {
            integerOperand = AsIntegerOperand;
            return true;
        }

        integerOperand = null!;
        return false;
    }

    private Dictionary<object, IConstantExpression> ConstantTable = new();
}
