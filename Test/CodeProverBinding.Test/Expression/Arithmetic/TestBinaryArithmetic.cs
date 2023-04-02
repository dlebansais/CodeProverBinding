namespace ArithmeticExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestBinaryArithmetic
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerConstantExpressionInt TestLeftOperand = new(Binder, 1);
        BinaryArithmeticOperator TestOperator = BinaryArithmeticOperator.Add;
        string TestOperatorText = "+";
        using IntegerConstantExpressionInt TestRightOperand = new(Binder, 2);
        using BinaryArithmeticExpression TestObject = new(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.LeftOperand, Is.EqualTo(TestLeftOperand));
        Assert.That(TestObject.Operator, Is.EqualTo(TestOperator));
        Assert.That(TestObject.RightOperand, Is.EqualTo(TestRightOperand));
        Assert.True(TestObject.ExpressionZ3.Item is ArithExpr);
        Assert.True(TestObject.ArithmeticExpressionZ3 is IArithExprCapsule);
        Assert.True(TestObject.ArithmeticExpressionZ3.Item is ArithExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"({TestLeftOperand}) {TestOperatorText} ({TestRightOperand})"));
    }

    [Test]
    public void Interface_IBinaryArithmeticExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerConstantExpressionInt TestLeftOperand = new(Binder, 1);
        BinaryArithmeticOperator TestOperator = BinaryArithmeticOperator.Add;
        using IntegerConstantExpressionInt TestRightOperand = new(Binder, 2);
        using IBinaryArithmeticExpression TestObject = new BinaryArithmeticExpression(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.LeftOperand, Is.EqualTo(TestLeftOperand));
        Assert.That(TestObject.Operator, Is.EqualTo(TestOperator));
        Assert.That(TestObject.RightOperand, Is.EqualTo(TestRightOperand));
    }

    [Test]
    public void Interface_IArithmeticExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IArithmeticExpression TestObject = CreateIntegerTestObject(Binder, BinaryArithmeticOperator.Add);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IExpression TestObject = CreateIntegerTestObject(Binder, BinaryArithmeticOperator.Add);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerConstantExpressionInt TestLeftOperand = new(Binder, 1);
        BinaryArithmeticOperator TestOperator = BinaryArithmeticOperator.Add;
        using IntegerConstantExpressionInt TestRightOperand = new(Binder, 2);
        using BinaryArithmeticExpression TestObject = new(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }

    [Test]
    public void TestAddInteger()
    {
        using Binder Binder = Tools.CreateBinder();
        using BinaryArithmeticExpression TestObject = CreateIntegerTestObject(Binder, BinaryArithmeticOperator.Add);

        Assert.True(TestObject is IIntegerExpression);
        Assert.That(TestObject.ToString(), Is.EqualTo($"(1) + (2)"));
    }

    [Test]
    public void TestSubstractInteger()
    {
        using Binder Binder = Tools.CreateBinder();
        using BinaryArithmeticExpression TestObject = CreateIntegerTestObject(Binder, BinaryArithmeticOperator.Subtract);

        Assert.True(TestObject is IIntegerExpression);
        Assert.That(TestObject.ToString(), Is.EqualTo($"(1) - (2)"));
    }

    [Test]
    public void TestMultiplyInteger()
    {
        using Binder Binder = Tools.CreateBinder();
        using BinaryArithmeticExpression TestObject = CreateIntegerTestObject(Binder, BinaryArithmeticOperator.Multiply);

        Assert.True(TestObject is IIntegerExpression);
        Assert.That(TestObject.ToString(), Is.EqualTo($"(1) * (2)"));
    }

    [Test]
    public void TestDivideInteger()
    {
        using Binder Binder = Tools.CreateBinder();
        using BinaryArithmeticExpression TestObject = CreateIntegerTestObject(Binder, BinaryArithmeticOperator.Divide);

        Assert.True(TestObject is IIntegerExpression);
        Assert.That(TestObject.ToString(), Is.EqualTo($"(1) / (2)"));
    }

    [Test]
    public void TestAddFloatingPoint()
    {
        using Binder Binder = Tools.CreateBinder();
        using BinaryArithmeticExpression TestObject = CreateFloatingPointTestObject(Binder, BinaryArithmeticOperator.Add);

        Assert.False(TestObject is IIntegerExpression);
        Assert.That(TestObject.ToString(), Is.EqualTo($"(1.1) + (2.2)"));
    }

    [Test]
    public void TestSubstractFloatingPoint()
    {
        using Binder Binder = Tools.CreateBinder();
        using BinaryArithmeticExpression TestObject = CreateFloatingPointTestObject(Binder, BinaryArithmeticOperator.Subtract);

        Assert.False(TestObject is IIntegerExpression);
        Assert.That(TestObject.ToString(), Is.EqualTo($"(1.1) - (2.2)"));
    }

    [Test]
    public void TestMultiplyFloatingPoint()
    {
        using Binder Binder = Tools.CreateBinder();
        using BinaryArithmeticExpression TestObject = CreateFloatingPointTestObject(Binder, BinaryArithmeticOperator.Multiply);

        Assert.False(TestObject is IIntegerExpression);
        Assert.That(TestObject.ToString(), Is.EqualTo($"(1.1) * (2.2)"));
    }

    [Test]
    public void TestDivideFloatingPoint()
    {
        using Binder Binder = Tools.CreateBinder();
        using BinaryArithmeticExpression TestObject = CreateFloatingPointTestObject(Binder, BinaryArithmeticOperator.Divide);

        Assert.False(TestObject is IIntegerExpression);
        Assert.That(TestObject.ToString(), Is.EqualTo($"(1.1) / (2.2)"));
    }

    private BinaryArithmeticExpression CreateIntegerTestObject(Binder binder, BinaryArithmeticOperator testOperator)
    {
        using IntegerConstantExpressionInt TestLeftOperand = new(binder, 1);
        using IntegerConstantExpressionInt TestRightOperand = new(binder, 2);
        return new IntegerBinaryArithmeticExpression(binder, TestLeftOperand, testOperator, TestRightOperand);
    }

    private BinaryArithmeticExpression CreateFloatingPointTestObject(Binder binder, BinaryArithmeticOperator testOperator)
    {
        using FloatingPointConstantExpression TestLeftOperand = new(binder, 1.1);
        using FloatingPointConstantExpression TestRightOperand = new(binder, 2.2);
        return new BinaryArithmeticExpression(binder, TestLeftOperand, testOperator, TestRightOperand);
    }
}
