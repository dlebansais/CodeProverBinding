namespace ArithmeticExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestIntegerUnaryArithmetic
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        UnaryArithmeticOperator TestOperator = UnaryArithmeticOperator.Minus;
        string TestOperatorText = "-";
        using IntegerConstantExpressionInt TestOperand = new(Binder, 2);
        using IntegerUnaryArithmeticExpression TestObject = new(Binder, TestOperator, TestOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Operator, Is.EqualTo(TestOperator));
        Assert.That(TestObject.Operand, Is.EqualTo(TestOperand));
        Assert.True(TestObject.ExpressionZ3.Item is ArithExpr);
        Assert.True(TestObject.ArithmeticExpressionZ3 is IArithExprCapsule);
        Assert.True(TestObject.ArithmeticExpressionZ3.Item is ArithExpr);
        Assert.True(TestObject.IntegerExpressionZ3 is IIntExprCapsule);
        Assert.True(TestObject.IntegerExpressionZ3.Item is IntExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestOperatorText}({TestOperand})"));
    }

    [Test]
    public void Interface_IUnaryArithmeticExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        UnaryArithmeticOperator TestOperator = UnaryArithmeticOperator.Minus;
        using IntegerConstantExpressionInt TestOperand = new(Binder, 2);
        using IUnaryArithmeticExpression TestObject = new IntegerUnaryArithmeticExpression(Binder, TestOperator, TestOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Operator, Is.EqualTo(TestOperator));
        Assert.That(TestObject.Operand, Is.EqualTo(TestOperand));
    }

    [Test]
    public void Interface_IArithmeticExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IArithmeticExpression TestObject = CreateTestObject(Binder, UnaryArithmeticOperator.Minus);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IExpression TestObject = CreateTestObject(Binder, UnaryArithmeticOperator.Minus);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        UnaryArithmeticOperator TestOperator = UnaryArithmeticOperator.Minus;
        using IntegerConstantExpressionInt TestOperand = new(Binder, 2);
        using IntegerUnaryArithmeticExpression TestObject = new(Binder, TestOperator, TestOperand);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }

    private IntegerUnaryArithmeticExpression CreateTestObject(Binder binder, UnaryArithmeticOperator testOperator)
    {
        using IntegerConstantExpressionInt TestOperand = new(binder, 2);
        return new IntegerUnaryArithmeticExpression(binder, testOperator, TestOperand);
    }
}
