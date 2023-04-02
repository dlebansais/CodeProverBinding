namespace ConstantExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestBoolean
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        bool TestValue = false;
        using BooleanConstantExpression TestObject = new(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.True(TestObject.ExpressionZ3.Item is BoolExpr);
        Assert.True(TestObject.BooleanExpressionZ3 is IBoolExprCapsule);
        Assert.True(TestObject.BooleanExpressionZ3.Item is BoolExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestValue}"));
    }

    [Test]
    public void Interface_IBooleanConstantExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        bool TestValue = false;
        using IBooleanConstantExpression TestObject = new BooleanConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IConstantExpressionGeneric()
    {
        using Binder Binder = Tools.CreateBinder();
        bool TestValue = false;
        using IConstantExpression<bool> TestObject = new BooleanConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IBooleanExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        bool TestValue = false;
        using IBooleanExpression TestObject = new BooleanConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IConstantExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        bool TestValue = false;
        using IConstantExpression TestObject = new BooleanConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestValue}"));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        bool TestValue = false;
        using IExpression TestObject = new BooleanConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        bool TestValue = true;
        using BooleanConstantExpression TestObject = new(Binder, TestValue);

        TestObject.Assert();

        Binder.CheckCorrectness();
        Assert.True(Binder.IsCorrect);
    }
}
