namespace ArithmeticExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestIntegerBinaryArithmetic
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerConstantExpressionInt TestLeftOperand = new(Binder, 1);
        BinaryArithmeticOperator TestOperator = BinaryArithmeticOperator.Add;
        string TestOperatorText = "+";
        using IntegerConstantExpressionInt TestRightOperand = new(Binder, 2);
        using IntegerBinaryArithmeticExpression TestObject = new(Binder, TestLeftOperand, TestOperator, TestRightOperand);

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
        using IBinaryArithmeticExpression TestObject = new IntegerBinaryArithmeticExpression(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.LeftOperand, Is.EqualTo(TestLeftOperand));
        Assert.That(TestObject.Operator, Is.EqualTo(TestOperator));
        Assert.That(TestObject.RightOperand, Is.EqualTo(TestRightOperand));
    }

    [Test]
    public void Interface_IArithmeticExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IArithmeticExpression TestObject = CreateTestObject(Binder, BinaryArithmeticOperator.Add);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IExpression TestObject = CreateTestObject(Binder, BinaryArithmeticOperator.Add);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerConstantExpressionInt TestLeftOperand = new(Binder, 1);
        BinaryArithmeticOperator TestOperator = BinaryArithmeticOperator.Add;
        using IntegerConstantExpressionInt TestRightOperand = new(Binder, 2);
        using IntegerBinaryArithmeticExpression TestObject = new(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }

    [Test]
    public void TestAdd()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerBinaryArithmeticExpression TestObject = CreateTestObject(Binder, BinaryArithmeticOperator.Add);

        Assert.That(TestObject.ToString(), Is.EqualTo($"(1) + (2)"));
    }

    [Test]
    public void TestSubstract()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerBinaryArithmeticExpression TestObject = CreateTestObject(Binder, BinaryArithmeticOperator.Subtract);

        Assert.That(TestObject.ToString(), Is.EqualTo($"(1) - (2)"));
    }

    [Test]
    public void TestMultiply()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerBinaryArithmeticExpression TestObject = CreateTestObject(Binder, BinaryArithmeticOperator.Multiply);

        Assert.That(TestObject.ToString(), Is.EqualTo($"(1) * (2)"));
    }

    [Test]
    public void TestDivide()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerBinaryArithmeticExpression TestObject = CreateTestObject(Binder, BinaryArithmeticOperator.Divide);

        Assert.That(TestObject.ToString(), Is.EqualTo($"(1) / (2)"));
    }

    [Test]
    public void TestModulo()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerBinaryArithmeticExpression TestObject = CreateTestObject(Binder, BinaryArithmeticOperator.Modulo);

        Assert.That(TestObject.ToString(), Is.EqualTo($"(1) % (2)"));
    }

    private IntegerBinaryArithmeticExpression CreateTestObject(Binder binder, BinaryArithmeticOperator testOperator)
    {
        using IntegerConstantExpressionInt TestLeftOperand = new(binder, 1);
        using IntegerConstantExpressionInt TestRightOperand = new(binder, 2);
        return new IntegerBinaryArithmeticExpression(binder, TestLeftOperand, testOperator, TestRightOperand);
    }
}
