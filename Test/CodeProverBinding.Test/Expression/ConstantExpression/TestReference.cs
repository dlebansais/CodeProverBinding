namespace ConstantExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestReference
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        Reference TestValue = Reference.New();
        using ReferenceConstantExpression TestObject = new(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.True(TestObject.ExpressionZ3.Item is ArithExpr);
        Assert.True(TestObject.ReferenceExpressionZ3 is IRefExprCapsule);
        Assert.True(TestObject.ReferenceExpressionZ3.Item is IntExpr);
        Assert.That(TestObject.ReferenceExpressionZ3.Index, Is.EqualTo(TestValue));
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestValue}"));
    }

    [Test]
    public void Interface_IReferenceConstantExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        Reference TestValue = Reference.New();
        using IReferenceConstantExpression TestObject = new ReferenceConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IConstantExpressionGeneric()
    {
        using Binder Binder = Tools.CreateBinder();
        Reference TestValue = Reference.New();
        using IConstantExpression<Reference> TestObject = new ReferenceConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IConstantExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        Reference TestValue = Reference.New();
        using IReferenceConstantExpression TestObject = new ReferenceConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestValue}"));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        Reference TestValue = Reference.New();
        using IReferenceConstantExpression TestObject = new ReferenceConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        Reference TestValue = Reference.New();
        using ReferenceConstantExpression TestObject = new(Binder, TestValue);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }
}
