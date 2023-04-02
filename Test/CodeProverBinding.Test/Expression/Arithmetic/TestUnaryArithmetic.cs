namespace ArithmeticExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestUnaryArithmetic
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        UnaryArithmeticOperator TestOperator = UnaryArithmeticOperator.Minus;
        string TestOperatorText = "-";
        using IntegerConstantExpressionInt TestOperand = new(Binder, 2);
        using UnaryArithmeticExpression TestObject = new(Binder, TestOperator, TestOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Operator, Is.EqualTo(TestOperator));
        Assert.That(TestObject.Operand, Is.EqualTo(TestOperand));
        Assert.True(TestObject.ExpressionZ3.Item is ArithExpr);
        Assert.True(TestObject.ArithmeticExpressionZ3 is IArithExprCapsule);
        Assert.True(TestObject.ArithmeticExpressionZ3.Item is ArithExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestOperatorText}({TestOperand})"));
    }

    [Test]
    public void Interface_IUnaryArithmeticExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        UnaryArithmeticOperator TestOperator = UnaryArithmeticOperator.Minus;
        using IntegerConstantExpressionInt TestOperand = new(Binder, 2);
        using IUnaryArithmeticExpression TestObject = new UnaryArithmeticExpression(Binder, TestOperator, TestOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Operator, Is.EqualTo(TestOperator));
        Assert.That(TestObject.Operand, Is.EqualTo(TestOperand));
    }

    [Test]
    public void Interface_IArithmeticExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IArithmeticExpression TestObject = CreateIntegerTestObject(Binder, UnaryArithmeticOperator.Minus);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IExpression TestObject = CreateIntegerTestObject(Binder, UnaryArithmeticOperator.Minus);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        UnaryArithmeticOperator TestOperator = UnaryArithmeticOperator.Minus;
        using IntegerConstantExpressionInt TestOperand = new(Binder, 2);
        using UnaryArithmeticExpression TestObject = new(Binder, TestOperator, TestOperand);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }

    [Test]
    public void TestMinusInteger()
    {
        using Binder Binder = Tools.CreateBinder();
        using UnaryArithmeticExpression TestObject = CreateIntegerTestObject(Binder, UnaryArithmeticOperator.Minus);

        Assert.True(TestObject is IIntegerExpression);
        Assert.That(TestObject.ToString(), Is.EqualTo($"-(2)"));
    }

    [Test]
    public void TestMinusFloatingPoint()
    {
        using Binder Binder = Tools.CreateBinder();
        using UnaryArithmeticExpression TestObject = CreateFloatingPointTestObject(Binder, UnaryArithmeticOperator.Minus);

        Assert.False(TestObject is IIntegerExpression);
        Assert.That(TestObject.ToString(), Is.EqualTo($"-(2.2)"));
    }

    private UnaryArithmeticExpression CreateIntegerTestObject(Binder binder, UnaryArithmeticOperator testOperator)
    {
        using IntegerConstantExpressionInt TestOperand = new(binder, 2);
        return new IntegerUnaryArithmeticExpression(binder, testOperator, TestOperand);
    }

    private UnaryArithmeticExpression CreateFloatingPointTestObject(Binder binder, UnaryArithmeticOperator testOperator)
    {
        using FloatingPointConstantExpression TestOperand = new(binder, 2.2);
        return new UnaryArithmeticExpression(binder, testOperator, TestOperand);
    }
}
