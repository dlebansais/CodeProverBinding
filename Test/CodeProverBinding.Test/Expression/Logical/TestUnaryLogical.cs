namespace LogicalExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestUnaryLogical
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        UnaryLogicalOperator TestOperator = UnaryLogicalOperator.Not;
        string TestOperatorText = "!";
        using BooleanConstantExpression TestOperand = new(Binder, true);
        using UnaryLogicalExpression TestObject = new(Binder, TestOperator, TestOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Operator, Is.EqualTo(TestOperator));
        Assert.That(TestObject.Operand, Is.EqualTo(TestOperand));
        Assert.True(TestObject.ExpressionZ3.Item is BoolExpr);
        Assert.True(TestObject.LogicalExpressionZ3 is IBoolExprCapsule);
        Assert.True(TestObject.LogicalExpressionZ3.Item is BoolExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestOperatorText}({TestOperand})"));
    }

    [Test]
    public void Interface_IUnaryLogicalExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        UnaryLogicalOperator TestOperator = UnaryLogicalOperator.Not;
        using BooleanConstantExpression TestOperand = new(Binder, true);
        using IUnaryLogicalExpression TestObject = new UnaryLogicalExpression(Binder, TestOperator, TestOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Operator, Is.EqualTo(TestOperator));
        Assert.That(TestObject.Operand, Is.EqualTo(TestOperand));
    }

    [Test]
    public void Interface_ILogicalExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using ILogicalExpression TestObject = CreateIntegerTestObject(Binder, UnaryLogicalOperator.Not);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IExpression TestObject = CreateIntegerTestObject(Binder, UnaryLogicalOperator.Not);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        UnaryLogicalOperator TestOperator = UnaryLogicalOperator.Not;
        using BooleanConstantExpression TestOperand = new(Binder, false);
        using UnaryLogicalExpression TestObject = new(Binder, TestOperator, TestOperand);

        TestObject.Assert();

        Binder.CheckCorrectness();
        Assert.True(Binder.IsCorrect);
    }

    private UnaryLogicalExpression CreateIntegerTestObject(Binder binder, UnaryLogicalOperator testOperator)
    {
        using BooleanConstantExpression TestOperand = new(binder, true);
        return new UnaryLogicalExpression(binder, testOperator, TestOperand);
    }
}
