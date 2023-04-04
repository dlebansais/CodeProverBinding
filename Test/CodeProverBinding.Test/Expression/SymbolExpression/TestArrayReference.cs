namespace SymbolExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestArrayReference
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ReferenceSymbol TestSymbol = new(Binder, TestName);
        using ArrayReferenceSymbolExpression TestArray = new(Binder, TestSymbol);

        Assert.That(TestArray.Binder, Is.EqualTo(Binder));
        Assert.That(TestArray.Symbol, Is.EqualTo(TestSymbol));
        Assert.True(TestArray.ExpressionZ3.Item is IntExpr);
        Assert.True(TestArray.ReferenceExpressionZ3 is IIntExprCapsule);
        Assert.True(TestArray.ReferenceExpressionZ3.Item is IntExpr);
        Assert.That(TestArray.ToString(), Is.EqualTo($"{TestSymbol}"));
    }

    [Test]
    public void Interface_IArrayReferenceSymbolExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ReferenceSymbol TestSymbol = new(Binder, TestName);
        using IArrayReferenceSymbolExpression TestArray = new ArrayReferenceSymbolExpression(Binder, TestSymbol);

        Assert.That(TestArray.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_ISymbolExpressionGeneric()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ReferenceSymbol TestSymbol = new(Binder, TestName);
        using ISymbolExpression<IReferenceSort> TestArray = new ArrayReferenceSymbolExpression(Binder, TestSymbol);

        Assert.That(TestArray.Binder, Is.EqualTo(Binder));
        Assert.That(TestArray.Symbol, Is.EqualTo(TestSymbol));
    }

    [Test]
    public void Interface_ISymbolExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ReferenceSymbol TestSymbol = new(Binder, TestName);
        using ISymbolExpression TestArray = new ArrayReferenceSymbolExpression(Binder, TestSymbol);

        Assert.That(TestArray.Symbol, Is.EqualTo(TestSymbol));
    }

    [Test]
    public void Interface_IReferenceExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ReferenceSymbol TestSymbol = new(Binder, TestName);
        using IReferenceExpression TestArray = new ArrayReferenceSymbolExpression(Binder, TestSymbol);

        Assert.That(TestArray.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ReferenceSymbol TestSymbol = new(Binder, TestName);
        using IExpression TestArray = new ArrayReferenceSymbolExpression(Binder, TestSymbol);

        Assert.That(TestArray.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ReferenceSymbol TestSymbol = new(Binder, TestName);
        using ArrayReferenceSymbolExpression TestArray = new(Binder, TestSymbol);

        Assert.Throws<CodeProverException>(TestArray.Assert);
    }
}
