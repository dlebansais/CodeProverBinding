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
        Binder Binder = Tools.CreateBinder();
        long TestValue = -68719476735;
        IntegerConstantExpressionLong TestObject = new(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.True(TestObject.ExpressionZ3.Item is IntExpr);
        Assert.True(TestObject.IntegerExpressionZ3 is IIntExprCapsule);
        Assert.True(TestObject.IntegerExpressionZ3.Item is IntExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestObject.Value}"));
    }

    [Test]
    public void Interface_IIntegerConstantExpression()
    {
        Binder Binder = Tools.CreateBinder();
        long TestValue = -68719476735;
        IIntegerConstantExpression TestObject = new IntegerConstantExpressionLong(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IConstantExpressionGeneric()
    {
        Binder Binder = Tools.CreateBinder();
        long TestValue = -68719476735;
        IConstantExpression<long> TestObject = new IntegerConstantExpressionLong(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IIntegerExpression()
    {
        Binder Binder = Tools.CreateBinder();
        long TestValue = -68719476735;
        IIntegerExpression TestObject = new IntegerConstantExpressionLong(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IConstantExpression()
    {
        Binder Binder = Tools.CreateBinder();
        long TestValue = -68719476735;
        IConstantExpression TestObject = new IntegerConstantExpressionLong(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestValue}"));
    }

    [Test]
    public void Interface_IExpression()
    {
        Binder Binder = Tools.CreateBinder();
        long TestValue = -68719476735;
        IExpression TestObject = new IntegerConstantExpressionLong(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        Binder Binder = Tools.CreateBinder();
        long TestValue = -68719476735;
        IntegerConstantExpressionLong TestObject = new(Binder, TestValue);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }
}
