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
        Binder Binder = Tools.CreateBinder();
        Reference TestValue = Reference.New();
        ReferenceConstantExpression TestObject = new(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.True(TestObject.ExpressionZ3.Item is ArithExpr);
        Assert.True(TestObject.ReferenceExpressionZ3 is IRefExprCapsule);
        Assert.True(TestObject.ReferenceExpressionZ3.Item is IntExpr);
        Assert.That(TestObject.ReferenceExpressionZ3.Index, Is.EqualTo(TestValue));
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestObject.Value}"));
    }

    [Test]
    public void Interface_IReferenceConstantExpression()
    {
        Binder Binder = Tools.CreateBinder();
        Reference TestValue = Reference.New();
        IReferenceConstantExpression TestObject = new ReferenceConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IConstantExpressionGeneric()
    {
        Binder Binder = Tools.CreateBinder();
        Reference TestValue = Reference.New();
        IConstantExpression<Reference> TestObject = new ReferenceConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
    }

    [Test]
    public void Interface_IConstantExpression()
    {
        Binder Binder = Tools.CreateBinder();
        Reference TestValue = Reference.New();
        IReferenceConstantExpression TestObject = new ReferenceConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(TestValue));
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestValue}"));
    }

    [Test]
    public void Interface_IExpression()
    {
        Binder Binder = Tools.CreateBinder();
        Reference TestValue = Reference.New();
        IReferenceConstantExpression TestObject = new ReferenceConstantExpression(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        Binder Binder = Tools.CreateBinder();
        Reference TestValue = Reference.New();
        ReferenceConstantExpression TestObject = new(Binder, TestValue);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }
}
