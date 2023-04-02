namespace LogicalExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestBinaryLogical
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        using BooleanConstantExpression TestLeftOperand = new(Binder, true);
        BinaryLogicalOperator TestOperator = BinaryLogicalOperator.Or;
        string TestOperatorText = "||";
        using BooleanConstantExpression TestRightOperand = new(Binder, false);
        using BinaryLogicalExpression TestObject = new(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.LeftOperand, Is.EqualTo(TestLeftOperand));
        Assert.That(TestObject.Operator, Is.EqualTo(TestOperator));
        Assert.That(TestObject.RightOperand, Is.EqualTo(TestRightOperand));
        Assert.True(TestObject.ExpressionZ3.Item is BoolExpr);
        Assert.True(TestObject.LogicalExpressionZ3 is IBoolExprCapsule);
        Assert.True(TestObject.LogicalExpressionZ3.Item is BoolExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"({TestLeftOperand}) {TestOperatorText} ({TestRightOperand})"));
    }

    [Test]
    public void Interface_IBinaryLogicalExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using BooleanConstantExpression TestLeftOperand = new(Binder, true);
        BinaryLogicalOperator TestOperator = BinaryLogicalOperator.Or;
        using BooleanConstantExpression TestRightOperand = new(Binder, false);
        using IBinaryLogicalExpression TestObject = new BinaryLogicalExpression(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.LeftOperand, Is.EqualTo(TestLeftOperand));
        Assert.That(TestObject.Operator, Is.EqualTo(TestOperator));
        Assert.That(TestObject.RightOperand, Is.EqualTo(TestRightOperand));
    }

    [Test]
    public void Interface_ILogicalExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using ILogicalExpression TestObject = CreateTestObject(Binder, BinaryLogicalOperator.Or);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IExpression TestObject = CreateTestObject(Binder, BinaryLogicalOperator.Or);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        using BooleanConstantExpression TestLeftOperand = new(Binder, true);
        BinaryLogicalOperator TestOperator = BinaryLogicalOperator.Or;
        using BooleanConstantExpression TestRightOperand = new(Binder, false);
        using BinaryLogicalExpression TestObject = new(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        TestObject.Assert();

        Binder.CheckCorrectness();
        Assert.True(Binder.IsCorrect);
    }

    [Test]
    public void TestOr()
    {
        using Binder Binder = Tools.CreateBinder();
        using BinaryLogicalExpression TestObject = CreateTestObject(Binder, BinaryLogicalOperator.Or);

        Assert.That(TestObject.ToString(), Is.EqualTo($"(True) || (False)"));
    }

    [Test]
    public void TestAnd()
    {
        using Binder Binder = Tools.CreateBinder();
        using BinaryLogicalExpression TestObject = CreateTestObject(Binder, BinaryLogicalOperator.And);

        Assert.That(TestObject.ToString(), Is.EqualTo($"(True) && (False)"));
    }

    [Test]
    public void TestImplies()
    {
        using Binder Binder = Tools.CreateBinder();
        using BinaryLogicalExpression TestObject = CreateTestObject(Binder, BinaryLogicalOperator.Implies);

        Assert.That(TestObject.ToString(), Is.EqualTo($"(True) => (False)"));
    }

    private BinaryLogicalExpression CreateTestObject(Binder binder, BinaryLogicalOperator testOperator)
    {
        using BooleanConstantExpression TestLeftOperand = new(binder, true);
        using BooleanConstantExpression TestRightOperand = new(binder, false);
        return new BinaryLogicalExpression(binder, TestLeftOperand, testOperator, TestRightOperand);
    }
}
