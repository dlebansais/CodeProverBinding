namespace Binder;

using System;
using CodeProverBinding;
using NUnit.Framework;

[TestFixture]
public class BinderTestExpression
{
    [Test]
    public void Predefined()
    {
        Binder Binder = Tools.CreateBinder();

        Assert.That(Binder.False.Value, Is.EqualTo(false));
        Assert.That(Binder.True.Value, Is.EqualTo(true));
        Assert.That(Binder.Zero.Value, Is.EqualTo(0));
        Assert.That(Binder.FloatingPointZero.Value, Is.EqualTo(0));
        Assert.That(Binder.Null.Value, Is.EqualTo(Reference.Null));
    }

    [Test]
    public void Constants()
    {
        Binder Binder = Tools.CreateBinder();

        IBooleanConstantExpression ConstantFalse = Binder.GetBooleanConstant(false);
        Assert.That(ConstantFalse, Is.EqualTo(Binder.False));

        IBooleanConstantExpression ConstantTrue = Binder.GetBooleanConstant(true);
        Assert.That(ConstantTrue, Is.EqualTo(Binder.True));

        IIntegerConstantExpression ConstantZero = Binder.GetIntegerConstant(0);
        Assert.That(ConstantZero, Is.EqualTo(Binder.Zero));

        IFloatingPointConstantExpression FloatingPointConstantZero = Binder.GetFloatingPointConstant(0);
        Assert.That(FloatingPointConstantZero, Is.EqualTo(Binder.FloatingPointZero));

        IReferenceConstantExpression ConstantNull = Binder.GetReferenceConstant(Reference.Null);
        Assert.That(ConstantNull, Is.EqualTo(Binder.Null));
    }

    [Test]
    public void IntegerConstants()
    {
        Binder Binder = Tools.CreateBinder();
        int IntNeg1 = -1;
        uint UInt1 = 1;
        long IntNeg2 = -2;
        ulong UInt2 = 2;

        IIntegerConstantExpression ConstantFirstNeg1 = Binder.GetIntegerConstant(IntNeg1);
        Assert.That(ConstantFirstNeg1.Value, Is.EqualTo(IntNeg1));

        IIntegerConstantExpression ConstantNextNeg1 = Binder.GetIntegerConstant(IntNeg1);
        Assert.That(ConstantNextNeg1, Is.EqualTo(ConstantFirstNeg1));

        IIntegerConstantExpression ConstantFirst1 = Binder.GetIntegerConstant(UInt1);
        Assert.That(ConstantFirst1.Value, Is.EqualTo(UInt1));

        IIntegerConstantExpression ConstantNext1 = Binder.GetIntegerConstant(UInt1);
        Assert.That(ConstantNext1, Is.EqualTo(ConstantFirst1));

        IIntegerConstantExpression ConstantFirstNeg2 = Binder.GetIntegerConstant(IntNeg2);
        Assert.That(ConstantFirstNeg2.Value, Is.EqualTo(IntNeg2));

        IIntegerConstantExpression ConstantNextNeg2 = Binder.GetIntegerConstant(IntNeg2);
        Assert.That(ConstantNextNeg2, Is.EqualTo(ConstantFirstNeg2));

        IIntegerConstantExpression ConstantFirst2 = Binder.GetIntegerConstant(UInt2);
        Assert.That(ConstantFirst2.Value, Is.EqualTo(UInt2));

        IIntegerConstantExpression ConstantNext2 = Binder.GetIntegerConstant(UInt2);
        Assert.That(ConstantNext2, Is.EqualTo(ConstantFirst2));
    }

    [Test]
    public void OtherConstants()
    {
        Binder Binder = Tools.CreateBinder();
        double Pi = 3.14;
        Reference TestIndex = Reference.New();

        IFloatingPointConstantExpression ConstantFirstPi = Binder.GetFloatingPointConstant(Pi);
        Assert.That(ConstantFirstPi.Value, Is.EqualTo(Pi));

        IFloatingPointConstantExpression ConstantNextPi = Binder.GetFloatingPointConstant(Pi);
        Assert.That(ConstantNextPi, Is.EqualTo(ConstantFirstPi));

        IReferenceConstantExpression ConstantFirstRef = Binder.GetReferenceConstant(TestIndex);
        Assert.That(ConstantFirstRef.Value, Is.EqualTo(TestIndex));

        IReferenceConstantExpression ConstantNextRef = Binder.GetReferenceConstant(TestIndex);
        Assert.That(ConstantNextRef, Is.EqualTo(ConstantFirstRef));
    }

    [Test]
    public void BooleanSymbols()
    {
        Binder Binder = Tools.CreateBinder();
        string BooleanName = "b";

        IBooleanSymbol BooleanSymbol = Binder.CreateBooleanSymbol(BooleanName);
        Assert.That(((ISymbol)BooleanSymbol).Name, Is.EqualTo(BooleanName));

        IBooleanSymbolExpression BooleanNameExpression = Binder.CreateBooleanSymbolExpression(BooleanName);
        Assert.That(((ISymbolExpression)BooleanNameExpression).Symbol.Name, Is.EqualTo(BooleanName));

        IBooleanSymbolExpression BooleanSymbolExpression = Binder.CreateBooleanSymbolExpression(BooleanSymbol);
        Assert.That(((ISymbolExpression)BooleanSymbolExpression).Symbol.Name, Is.EqualTo(BooleanName));
        Assert.That(BooleanSymbolExpression, Is.Not.EqualTo(BooleanNameExpression));
    }

    [Test]
    public void IntegerSymbols()
    {
        Binder Binder = Tools.CreateBinder();
        string IntegerName = "n";

        IIntegerSymbol IntegerSymbol = Binder.CreateIntegerSymbol(IntegerName);
        Assert.That(((ISymbol)IntegerSymbol).Name, Is.EqualTo(IntegerName));

        IIntegerSymbolExpression IntegerNameExpression = Binder.CreateIntegerSymbolExpression(IntegerName);
        Assert.That(((ISymbolExpression)IntegerNameExpression).Symbol.Name, Is.EqualTo(IntegerName));

        IIntegerSymbolExpression IntegerSymbolExpression = Binder.CreateIntegerSymbolExpression(IntegerSymbol);
        Assert.That(((ISymbolExpression)IntegerSymbolExpression).Symbol.Name, Is.EqualTo(IntegerName));
        Assert.That(IntegerSymbolExpression, Is.Not.EqualTo(IntegerNameExpression));
    }

    [Test]
    public void FloatingPointSymbols()
    {
        Binder Binder = Tools.CreateBinder();
        string FloatingPointName = "f";

        IFloatingPointSymbol FloatingPointSymbol = Binder.CreateFloatingPointSymbol(FloatingPointName);
        Assert.That(((ISymbol)FloatingPointSymbol).Name, Is.EqualTo(FloatingPointName));

        IFloatingPointSymbolExpression FloatingPointNameExpression = Binder.CreateFloatingPointSymbolExpression(FloatingPointName);
        Assert.That(((ISymbolExpression)FloatingPointNameExpression).Symbol.Name, Is.EqualTo(FloatingPointName));

        IFloatingPointSymbolExpression FloatingPointSymbolExpression = Binder.CreateFloatingPointSymbolExpression(FloatingPointSymbol);
        Assert.That(((ISymbolExpression)FloatingPointSymbolExpression).Symbol.Name, Is.EqualTo(FloatingPointName));
        Assert.That(FloatingPointSymbolExpression, Is.Not.EqualTo(FloatingPointNameExpression));
    }

    [Test]
    public void ReferenceSymbols()
    {
        Binder Binder = Tools.CreateBinder();
        string ReferenceName = "p";

        IReferenceSymbol ReferenceSymbol = Binder.CreateReferenceSymbol(ReferenceName);
        Assert.That(((ISymbol)ReferenceSymbol).Name, Is.EqualTo(ReferenceName));

        IReferenceSymbolExpression ReferenceNameExpression = Binder.CreateReferenceSymbolExpression(ReferenceName);
        Assert.That(((ISymbolExpression)ReferenceNameExpression).Symbol.Name, Is.EqualTo(ReferenceName));

        IReferenceSymbolExpression ReferenceSymbolExpression = Binder.CreateReferenceSymbolExpression(ReferenceSymbol);
        Assert.That(((ISymbolExpression)ReferenceSymbolExpression).Symbol.Name, Is.EqualTo(ReferenceName));
        Assert.That(ReferenceSymbolExpression, Is.Not.EqualTo(ReferenceNameExpression));
    }

    [Test]
    public void ObjectReferenceSymbols()
    {
        Binder Binder = Tools.CreateBinder();
        string ObjectReferenceName = "o";

        IReferenceSymbol ObjectReferenceSymbol = Binder.CreateReferenceSymbol(ObjectReferenceName);
        Assert.That(((ISymbol)ObjectReferenceSymbol).Name, Is.EqualTo(ObjectReferenceName));

        IObjectReferenceSymbolExpression ObjectReferenceNameExpression = Binder.CreateObjectReferenceSymbolExpression(ObjectReferenceName);
        Assert.That(((ISymbolExpression)ObjectReferenceNameExpression).Symbol.Name, Is.EqualTo(ObjectReferenceName));

        IObjectReferenceSymbolExpression ObjectReferenceSymbolExpression = Binder.CreateObjectReferenceSymbolExpression(ObjectReferenceSymbol);
        Assert.That(((ISymbolExpression)ObjectReferenceSymbolExpression).Symbol.Name, Is.EqualTo(ObjectReferenceName));
        Assert.That(ObjectReferenceSymbolExpression, Is.Not.EqualTo(ObjectReferenceNameExpression));
    }

    [Test]
    public void ArrayReferenceSymbols()
    {
        Binder Binder = Tools.CreateBinder();
        string ArrayReferenceName = "a";

        IReferenceSymbol ArrayReferenceSymbol = Binder.CreateReferenceSymbol(ArrayReferenceName);
        Assert.That(((ISymbol)ArrayReferenceSymbol).Name, Is.EqualTo(ArrayReferenceName));

        IArrayReferenceSymbolExpression ArrayReferenceNameExpression = Binder.CreateArrayReferenceSymbolExpression(ArrayReferenceName);
        Assert.That(((ISymbolExpression)ArrayReferenceNameExpression).Symbol.Name, Is.EqualTo(ArrayReferenceName));

        IArrayReferenceSymbolExpression ArrayReferenceSymbolExpression = Binder.CreateArrayReferenceSymbolExpression(ArrayReferenceSymbol);
        Assert.That(((ISymbolExpression)ArrayReferenceSymbolExpression).Symbol.Name, Is.EqualTo(ArrayReferenceName));
        Assert.That(ArrayReferenceSymbolExpression, Is.Not.EqualTo(ArrayReferenceNameExpression));
    }

    [Test]
    public void BinaryArithmetic()
    {
        Binder Binder = Tools.CreateBinder();

        using IFloatingPointConstantExpression LeftOperand = Binder.GetFloatingPointConstant(1.1);
        using IFloatingPointConstantExpression RightOperand = Binder.GetFloatingPointConstant(2.2);
        using IBinaryArithmeticExpression BinaryArithmeticExpression = Binder.CreateBinaryArithmeticExpression(LeftOperand, BinaryArithmeticOperator.Add, RightOperand);

        Assert.That(BinaryArithmeticExpression.LeftOperand, Is.EqualTo(LeftOperand));
        Assert.That(BinaryArithmeticExpression.RightOperand, Is.EqualTo(RightOperand));
    }

    [Test]
    public void IntegerBinaryArithmetic()
    {
        Binder Binder = Tools.CreateBinder();

        using IIntegerConstantExpression LeftOperand = Binder.GetIntegerConstant(1);
        using IIntegerConstantExpression RightOperand = Binder.GetIntegerConstant(2);
        using IBinaryArithmeticExpression BinaryArithmeticExpression = Binder.CreateBinaryArithmeticExpression(LeftOperand, BinaryArithmeticOperator.Add, RightOperand);

        Assert.True(BinaryArithmeticExpression is IntegerBinaryArithmeticExpression);
        Assert.That(BinaryArithmeticExpression.LeftOperand, Is.EqualTo(LeftOperand));
        Assert.That(BinaryArithmeticExpression.RightOperand, Is.EqualTo(RightOperand));
    }

    [Test]
    public void InvalidModuloExpression()
    {
        Binder Binder = Tools.CreateBinder();

        using IFloatingPointConstantExpression LeftOperand = Binder.GetFloatingPointConstant(1.1);
        using IFloatingPointConstantExpression RightOperand = Binder.GetFloatingPointConstant(2.2);

        Assert.Throws<ArgumentException>(() => Binder.CreateBinaryArithmeticExpression(LeftOperand, BinaryArithmeticOperator.Modulo, RightOperand));
    }

    [Test]
    public void UnaryArithmetic()
    {
        Binder Binder = Tools.CreateBinder();

        using IFloatingPointConstantExpression Operand = Binder.GetFloatingPointConstant(2.2);
        using IUnaryArithmeticExpression UnaryArithmeticExpression = Binder.CreateUnaryArithmeticExpression(UnaryArithmeticOperator.Minus, Operand);

        Assert.That(UnaryArithmeticExpression.Operand, Is.EqualTo(Operand));
    }

    [Test]
    public void IntegerUnaryArithmetic()
    {
        Binder Binder = Tools.CreateBinder();

        using IIntegerConstantExpression Operand = Binder.GetIntegerConstant(2);
        using IUnaryArithmeticExpression UnaryArithmeticExpression = Binder.CreateUnaryArithmeticExpression(UnaryArithmeticOperator.Minus, Operand);

        Assert.True(UnaryArithmeticExpression is IntegerUnaryArithmeticExpression);
        Assert.That(UnaryArithmeticExpression.Operand, Is.EqualTo(Operand));
    }

    [Test]
    public void BinaryLogical()
    {
        Binder Binder = Tools.CreateBinder();

        using IBooleanConstantExpression LeftOperand = Binder.GetBooleanConstant(false);
        using IBooleanConstantExpression RightOperand = Binder.GetBooleanConstant(true);
        using IBinaryLogicalExpression BinaryLogicalExpression = Binder.CreateBinaryLogicalExpression(LeftOperand, BinaryLogicalOperator.Or, RightOperand);

        Assert.That(BinaryLogicalExpression.LeftOperand, Is.EqualTo(LeftOperand));
        Assert.That(BinaryLogicalExpression.RightOperand, Is.EqualTo(RightOperand));
    }

    [Test]
    public void UnaryLogical()
    {
        Binder Binder = Tools.CreateBinder();

        using IBooleanConstantExpression Operand = Binder.GetBooleanConstant(false);
        using IUnaryLogicalExpression UnaryLogicalExpression = Binder.CreateUnaryLogicalExpression(UnaryLogicalOperator.Not, Operand);

        Assert.That(UnaryLogicalExpression.Operand, Is.EqualTo(Operand));
    }

    [Test]
    public void Comparison()
    {
        Binder Binder = Tools.CreateBinder();

        using IFloatingPointConstantExpression LeftOperand = Binder.GetFloatingPointConstant(1.1);
        using IFloatingPointConstantExpression RightOperand = Binder.GetFloatingPointConstant(2.2);
        using IComparisonExpression ComparisonExpression = Binder.CreateComparisonExpression(LeftOperand, ComparisonOperator.LesserThan, RightOperand);

        Assert.That(ComparisonExpression.LeftOperand, Is.EqualTo(LeftOperand));
        Assert.That(ComparisonExpression.RightOperand, Is.EqualTo(RightOperand));
    }

    [Test]
    public void Equality()
    {
        Binder Binder = Tools.CreateBinder();

        using IFloatingPointConstantExpression LeftOperand = Binder.GetFloatingPointConstant(1.1);
        using IFloatingPointConstantExpression RightOperand = Binder.GetFloatingPointConstant(2.2);
        using IEqualityExpression EqualityExpression = Binder.CreateEqualityExpression(LeftOperand, EqualityOperator.Equal, RightOperand);

        Assert.That(EqualityExpression.LeftOperand, Is.EqualTo(LeftOperand));
        Assert.That(EqualityExpression.RightOperand, Is.EqualTo(RightOperand));
    }
}
