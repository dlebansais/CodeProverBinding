namespace EqualityExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestEquality
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerConstantExpressionInt TestLeftOperand = new(Binder, 1);
        EqualityOperator TestOperator = EqualityOperator.Equal;
        string TestOperatorText = "==";
        using IntegerConstantExpressionInt TestRightOperand = new(Binder, 2);
        using EqualityExpression TestObject = new(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.LeftOperand, Is.EqualTo(TestLeftOperand));
        Assert.That(TestObject.Operator, Is.EqualTo(TestOperator));
        Assert.That(TestObject.RightOperand, Is.EqualTo(TestRightOperand));
        Assert.True(TestObject.ExpressionZ3.Item is BoolExpr);
        Assert.True(TestObject.BooleanExpressionZ3 is IBoolExprCapsule);
        Assert.True(TestObject.BooleanExpressionZ3.Item is BoolExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"({TestLeftOperand}) {TestOperatorText} ({TestRightOperand})"));
    }

    [Test]
    public void Interface_IEqualityExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerConstantExpressionInt TestLeftOperand = new(Binder, 1);
        EqualityOperator TestOperator = EqualityOperator.Equal;
        using IntegerConstantExpressionInt TestRightOperand = new(Binder, 2);
        using IEqualityExpression TestObject = new EqualityExpression(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.LeftOperand, Is.EqualTo(TestLeftOperand));
        Assert.That(TestObject.Operator, Is.EqualTo(TestOperator));
        Assert.That(TestObject.RightOperand, Is.EqualTo(TestRightOperand));
    }

    [Test]
    public void Interface_IBooleanExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerConstantExpressionInt TestLeftOperand = new(Binder, 1);
        EqualityOperator TestOperator = EqualityOperator.Equal;
        using IntegerConstantExpressionInt TestRightOperand = new(Binder, 2);
        using IBooleanExpression TestObject = new EqualityExpression(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerConstantExpressionInt TestLeftOperand = new(Binder, 1);
        EqualityOperator TestOperator = EqualityOperator.Equal;
        using IntegerConstantExpressionInt TestRightOperand = new(Binder, 2);
        using IExpression TestObject = new EqualityExpression(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerConstantExpressionInt TestLeftOperand = new(Binder, 1);
        EqualityOperator TestOperator = EqualityOperator.NotEqual;
        using IntegerConstantExpressionInt TestRightOperand = new(Binder, 2);
        using EqualityExpression TestObject = new(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        TestObject.Assert();

        Binder.CheckCorrectness();
        Assert.True(Binder.IsCorrect);
    }

    [Test]
    public void TestEqual()
    {
        using Binder Binder = Tools.CreateBinder();
        using EqualityExpression TestObject = CreateTestObject(Binder, EqualityOperator.Equal);

        Assert.That(TestObject.ToString(), Is.EqualTo($"(1) == (2)"));
    }

    [Test]
    public void TestNotEqual()
    {
        using Binder Binder = Tools.CreateBinder();
        using EqualityExpression TestObject = CreateTestObject(Binder, EqualityOperator.NotEqual);

        Assert.That(TestObject.ToString(), Is.EqualTo($"(1) != (2)"));
    }

    private EqualityExpression CreateTestObject(Binder binder, EqualityOperator testOperator)
    {
        using IntegerConstantExpressionInt TestLeftOperand = new(binder, 1);
        using IntegerConstantExpressionInt TestRightOperand = new(binder, 2);
        return new EqualityExpression(binder, TestLeftOperand, testOperator, TestRightOperand);
    }
}
