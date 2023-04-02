namespace SymbolExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestBoolean
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        BooleanSymbol TestSymbol = new(TestName);
        using BooleanSymbolExpression TestObject = new(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
        Assert.True(TestObject.ExpressionZ3.Item is BoolExpr);
        Assert.True(TestObject.BooleanExpressionZ3 is IBoolExprCapsule);
        Assert.True(TestObject.BooleanExpressionZ3.Item is BoolExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestSymbol}"));
    }

    [Test]
    public void Interface_IBooleanSymbolExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        BooleanSymbol TestSymbol = new(TestName);
        using IBooleanSymbolExpression TestObject = new BooleanSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(((ISymbolExpression)TestObject).Symbol, Is.EqualTo(TestSymbol));
        Assert.That(((ISymbolExpression<IBooleanSort>)TestObject).Symbol, Is.EqualTo(TestSymbol));
    }

    [Test]
    public void Interface_ISymbolExpressionGeneric()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        BooleanSymbol TestSymbol = new(TestName);
        using ISymbolExpression<IBooleanSort> TestObject = new BooleanSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
    }

    [Test]
    public void Interface_ISymbolExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        BooleanSymbol TestSymbol = new(TestName);
        using ISymbolExpression TestObject = new BooleanSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
    }

    [Test]
    public void Interface_IBooleanExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        BooleanSymbol TestSymbol = new(TestName);
        using IBooleanExpression TestObject = new BooleanSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        BooleanSymbol TestSymbol = new(TestName);
        using IExpression TestObject = new BooleanSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        BooleanSymbol TestSymbol = new(TestName);
        using BooleanSymbolExpression TestObject = new(Binder, TestSymbol);

        TestObject.Assert();

        Binder.CheckCorrectness();
        Assert.True(Binder.IsCorrect);
    }
}
