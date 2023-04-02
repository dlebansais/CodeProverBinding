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
        using Binder Binder = Tools.CreateBinder();
        double TestValue = 1.1;
        using FloatingPointConstantExpression TestObject = new(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.True(TestObject.ExpressionZ3.Item is ArithExpr);
        Assert.True(TestObject.ArithmeticExpressionZ3 is IArithExprCapsule);
        Assert.True(TestObject.ArithmeticExpressionZ3.Item is ArithExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestValue}"));
    }

    [Test]
    public void Interface_IFloatingPointConstantExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        double TestValue = 1.1;
        using IFloatingPointConstantExpression TestObject = new FloatingPointConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IConstantExpressionGeneric()
    {
        using Binder Binder = Tools.CreateBinder();
        double TestValue = 1.1;
        using IConstantExpression<double> TestObject = new FloatingPointConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IArithmeticExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        double TestValue = 1.1;
        using IArithmeticExpression TestObject = new FloatingPointConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IConstantExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        double TestValue = 1.1;
        using IConstantExpression TestObject = new FloatingPointConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestValue}"));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        double TestValue = 1.1;
        using IExpression TestObject = new FloatingPointConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        double TestValue = 1.1;
        using FloatingPointConstantExpression TestObject = new(Binder, TestValue);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }
}
