namespace ConstantExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestIntegerULong
{
    [Test]
    public void BasicTest()
    {
        Binder Binder = Tools.CreateBinder();
        ulong TestValue = 68719476735;
        IntegerConstantExpressionULong TestObject = new(Binder, TestValue);

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
        ulong TestValue = 68719476735;
        IIntegerConstantExpression TestObject = new IntegerConstantExpressionULong(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IConstantExpressionGeneric()
    {
        Binder Binder = Tools.CreateBinder();
        ulong TestValue = 68719476735;
        IConstantExpression<ulong> TestObject = new IntegerConstantExpressionULong(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IIntegerExpression()
    {
        Binder Binder = Tools.CreateBinder();
        ulong TestValue = 68719476735;
        IIntegerExpression TestObject = new IntegerConstantExpressionULong(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IConstantExpression()
    {
        Binder Binder = Tools.CreateBinder();
        ulong TestValue = 68719476735;
        IConstantExpression TestObject = new IntegerConstantExpressionULong(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestValue}"));
    }

    [Test]
    public void Interface_IExpression()
    {
        Binder Binder = Tools.CreateBinder();
        ulong TestValue = 68719476735;
        IExpression TestObject = new IntegerConstantExpressionULong(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        Binder Binder = Tools.CreateBinder();
        ulong TestValue = 68719476735;
        IntegerConstantExpressionULong TestObject = new(Binder, TestValue);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }
}
