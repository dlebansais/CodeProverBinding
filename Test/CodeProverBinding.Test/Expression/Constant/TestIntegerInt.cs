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
        Binder Binder = Tools.CreateBinder();
        int TestValue = -2;
        IntegerConstantExpressionInt TestObject = new(Binder, TestValue);

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
        int TestValue = -2;
        IIntegerConstantExpression TestObject = new IntegerConstantExpressionInt(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IConstantExpressionGeneric()
    {
        Binder Binder = Tools.CreateBinder();
        int TestValue = -2;
        IConstantExpression<int> TestObject = new IntegerConstantExpressionInt(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IIntegerExpression()
    {
        Binder Binder = Tools.CreateBinder();
        int TestValue = -2;
        IIntegerExpression TestObject = new IntegerConstantExpressionInt(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IConstantExpression()
    {
        Binder Binder = Tools.CreateBinder();
        int TestValue = -2;
        IConstantExpression TestObject = new IntegerConstantExpressionInt(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestValue}"));
    }

    [Test]
    public void Interface_IExpression()
    {
        Binder Binder = Tools.CreateBinder();
        int TestValue = -2;
        IExpression TestObject = new IntegerConstantExpressionInt(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        Binder Binder = Tools.CreateBinder();
        int TestValue = -2;
        IntegerConstantExpressionInt TestObject = new(Binder, TestValue);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }
}
