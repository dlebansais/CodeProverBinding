namespace ConstantExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestFloatingPoint
{
    [Test]
    public void BasicTest()
    {
        Binder Binder = Tools.CreateBinder();
        double TestValue = 1.1;
        FloatingPointConstantExpression TestObject = new(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.True(TestObject.ExpressionZ3.Item is ArithExpr);
        Assert.True(TestObject.ArithmeticExpressionZ3 is IArithExprCapsule);
        Assert.True(TestObject.ArithmeticExpressionZ3.Item is ArithExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestObject.Value}"));
    }

    [Test]
    public void Interface_IFloatingPointConstantExpression()
    {
        Binder Binder = Tools.CreateBinder();
        double TestValue = 1.1;
        IFloatingPointConstantExpression TestObject = new FloatingPointConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IConstantExpressionGeneric()
    {
        Binder Binder = Tools.CreateBinder();
        double TestValue = 1.1;
        IConstantExpression<double> TestObject = new FloatingPointConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IArithmeticExpression()
    {
        Binder Binder = Tools.CreateBinder();
        double TestValue = 1.1;
        IArithmeticExpression TestObject = new FloatingPointConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IConstantExpression()
    {
        Binder Binder = Tools.CreateBinder();
        double TestValue = 1.1;
        IConstantExpression TestObject = new FloatingPointConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestValue}"));
    }

    [Test]
    public void Interface_IExpression()
    {
        Binder Binder = Tools.CreateBinder();
        double TestValue = 1.1;
        IExpression TestObject = new FloatingPointConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        Binder Binder = Tools.CreateBinder();
        double TestValue = 1.1;
        FloatingPointConstantExpression TestObject = new(Binder, TestValue);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }
}
