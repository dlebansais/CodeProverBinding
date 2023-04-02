namespace ComparisonExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestComparison
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerConstantExpressionInt TestLeftOperand = new(Binder, 1);
        ComparisonOperator TestOperator = ComparisonOperator.LesserThan;
        string TestOperatorText = "<";
        using IntegerConstantExpressionInt TestRightOperand = new(Binder, 2);
        using ComparisonExpression TestObject = new(Binder, TestLeftOperand, TestOperator, TestRightOperand);

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
    public void Interface_IComparisonExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerConstantExpressionInt TestLeftOperand = new(Binder, 1);
        ComparisonOperator TestOperator = ComparisonOperator.LesserThan;
        using IntegerConstantExpressionInt TestRightOperand = new(Binder, 2);
        using IComparisonExpression TestObject = new ComparisonExpression(Binder, TestLeftOperand, TestOperator, TestRightOperand);

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
        ComparisonOperator TestOperator = ComparisonOperator.LesserThan;
        using IntegerConstantExpressionInt TestRightOperand = new(Binder, 2);
        using IBooleanExpression TestObject = new ComparisonExpression(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerConstantExpressionInt TestLeftOperand = new(Binder, 1);
        ComparisonOperator TestOperator = ComparisonOperator.LesserThan;
        using IntegerConstantExpressionInt TestRightOperand = new(Binder, 2);
        using IExpression TestObject = new ComparisonExpression(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        using IntegerConstantExpressionInt TestLeftOperand = new(Binder, 1);
        ComparisonOperator TestOperator = ComparisonOperator.LesserThan;
        using IntegerConstantExpressionInt TestRightOperand = new(Binder, 2);
        using ComparisonExpression TestObject = new(Binder, TestLeftOperand, TestOperator, TestRightOperand);

        TestObject.Assert();

        Binder.CheckCorrectness();
        Assert.True(Binder.IsCorrect);
    }

    [Test]
    public void TestLesserThan()
    {
        using Binder Binder = Tools.CreateBinder();
        using ComparisonExpression TestObject = CreateTestObject(Binder, ComparisonOperator.LesserThan);

        Assert.That(TestObject.ToString(), Is.EqualTo($"(1) < (2)"));
    }

    [Test]
    public void TestLesserThanEqualTo()
    {
        using Binder Binder = Tools.CreateBinder();
        using ComparisonExpression TestObject = CreateTestObject(Binder, ComparisonOperator.LesserThanEqualTo);

        Assert.That(TestObject.ToString(), Is.EqualTo($"(1) <= (2)"));
    }

    [Test]
    public void TestGreaterThan()
    {
        using Binder Binder = Tools.CreateBinder();
        using ComparisonExpression TestObject = CreateTestObject(Binder, ComparisonOperator.GreaterThan);

        Assert.That(TestObject.ToString(), Is.EqualTo($"(1) > (2)"));
    }

    [Test]
    public void TestGreaterThanEqualTo()
    {
        using Binder Binder = Tools.CreateBinder();
        using ComparisonExpression TestObject = CreateTestObject(Binder, ComparisonOperator.GreaterThanEqualTo);

        Assert.That(TestObject.ToString(), Is.EqualTo($"(1) >= (2)"));
    }

    private ComparisonExpression CreateTestObject(Binder binder, ComparisonOperator testOperator)
    {
        using IntegerConstantExpressionInt TestLeftOperand = new(binder, 1);
        using IntegerConstantExpressionInt TestRightOperand = new(binder, 2);
        return new ComparisonExpression(binder, TestLeftOperand, testOperator, TestRightOperand);
    }
}
