namespace ConstantExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestIntegerInt
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        int TestValue = -2;
        using IntegerConstantExpressionInt TestObject = new(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.True(TestObject.ExpressionZ3.Item is IntExpr);
        Assert.True(TestObject.IntegerExpressionZ3 is IIntExprCapsule);
        Assert.True(TestObject.IntegerExpressionZ3.Item is IntExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestValue}"));
    }

    [Test]
    public void Zero()
    {
        using Binder Binder = Tools.CreateBinder();
        IntegerConstantExpressionInt Zero = (IntegerConstantExpressionInt)Binder.Zero;

        Assert.That(Zero.Binder, Is.EqualTo(Binder));
        Assert.That(Zero.Value, Is.EqualTo(0));
        Assert.True(Zero.ExpressionZ3.Item is IntExpr);
        Assert.True(Zero.IntegerExpressionZ3 is IIntExprCapsule);
        Assert.True(Zero.IntegerExpressionZ3.Item is IntExpr);
        Assert.That(Zero.ToString(), Is.EqualTo("0"));
    }

    [Test]
    public void Interface_IIntegerConstantExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        int TestValue = -2;
        using IIntegerConstantExpression TestObject = new IntegerConstantExpressionInt(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IConstantExpressionGeneric()
    {
        using Binder Binder = Tools.CreateBinder();
        int TestValue = -2;
        using IConstantExpression<int> TestObject = new IntegerConstantExpressionInt(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IIntegerExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        int TestValue = -2;
        using IIntegerExpression TestObject = new IntegerConstantExpressionInt(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IConstantExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        int TestValue = -2;
        using IConstantExpression TestObject = new IntegerConstantExpressionInt(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestValue}"));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        int TestValue = -2;
        using IExpression TestObject = new IntegerConstantExpressionInt(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        int TestValue = -2;
        using IntegerConstantExpressionInt TestObject = new(Binder, TestValue);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }
}
