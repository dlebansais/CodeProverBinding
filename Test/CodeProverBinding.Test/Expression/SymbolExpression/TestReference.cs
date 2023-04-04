namespace SymbolExpression;

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
        string TestName = "x";
        ReferenceSymbol TestSymbol = new(Binder, TestName);
        using ReferenceSymbolExpression TestObject = new(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
        Assert.True(TestObject.ExpressionZ3.Item is IntExpr);
        Assert.True(TestObject.ReferenceExpressionZ3 is IIntExprCapsule);
        Assert.True(TestObject.ReferenceExpressionZ3.Item is IntExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestSymbol}"));
    }

    [Test]
    public void Interface_IReferenceSymbolExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ReferenceSymbol TestSymbol = new(Binder, TestName);
        using IReferenceSymbolExpression TestObject = new ReferenceSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_ISymbolExpressionGeneric()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ReferenceSymbol TestSymbol = new(Binder, TestName);
        using ISymbolExpression<IReferenceSort> TestObject = new ReferenceSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
    }

    [Test]
    public void Interface_ISymbolExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ReferenceSymbol TestSymbol = new(Binder, TestName);
        using ISymbolExpression TestObject = new ReferenceSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
    }

    [Test]
    public void Interface_IReferenceExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ReferenceSymbol TestSymbol = new(Binder, TestName);
        using IReferenceExpression TestObject = new ReferenceSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ReferenceSymbol TestSymbol = new(Binder, TestName);
        using IExpression TestObject = new ReferenceSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ReferenceSymbol TestSymbol = new(Binder, TestName);
        using ReferenceSymbolExpression TestObject = new(Binder, TestSymbol);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }
}
