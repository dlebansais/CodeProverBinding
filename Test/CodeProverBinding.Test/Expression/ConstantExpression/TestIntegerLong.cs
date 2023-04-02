namespace ConstantExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestIntegerLong
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        long TestValue = -68719476735;
        using IntegerConstantExpressionLong TestObject = new(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.True(TestObject.ExpressionZ3.Item is IntExpr);
        Assert.True(TestObject.IntegerExpressionZ3 is IIntExprCapsule);
        Assert.True(TestObject.IntegerExpressionZ3.Item is IntExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestValue}"));
    }

    [Test]
    public void Interface_IIntegerConstantExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        long TestValue = -68719476735;
        using IIntegerConstantExpression TestObject = new IntegerConstantExpressionLong(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IConstantExpressionGeneric()
    {
        using Binder Binder = Tools.CreateBinder();
        long TestValue = -68719476735;
        using IConstantExpression<long> TestObject = new IntegerConstantExpressionLong(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IIntegerExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        long TestValue = -68719476735;
        using IIntegerExpression TestObject = new IntegerConstantExpressionLong(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IConstantExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        long TestValue = -68719476735;
        using IConstantExpression TestObject = new IntegerConstantExpressionLong(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestValue}"));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        long TestValue = -68719476735;
        using IExpression TestObject = new IntegerConstantExpressionLong(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        long TestValue = -68719476735;
        using IntegerConstantExpressionLong TestObject = new(Binder, TestValue);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }
}
