namespace SymbolExpression;

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
        string TestName = "x";
        FloatingPointSymbol TestSymbol = new(Binder, TestName);
        using FloatingPointSymbolExpression TestObject = new(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
        Assert.True(TestObject.ExpressionZ3.Item is ArithExpr);
        Assert.True(TestObject.ArithmeticExpressionZ3 is IArithExprCapsule);
        Assert.True(TestObject.ArithmeticExpressionZ3.Item is ArithExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestSymbol}"));
    }

    [Test]
    public void Interface_IFloatingPointSymbolExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        FloatingPointSymbol TestSymbol = new(Binder, TestName);
        using IFloatingPointSymbolExpression TestObject = new FloatingPointSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IArithmeticSymbolExpressionGeneric()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        FloatingPointSymbol TestSymbol = new(Binder, TestName);
        using IArithmeticSymbolExpression<IFloatingPointSort> TestObject = new FloatingPointSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
    }

    [Test]
    public void Interface_IArithmeticSymbolExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        FloatingPointSymbol TestSymbol = new(Binder, TestName);
        using IArithmeticSymbolExpression TestObject = new FloatingPointSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
    }

    [Test]
    public void Interface_ISymbolExpressionGeneric()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        FloatingPointSymbol TestSymbol = new(Binder, TestName);
        using ISymbolExpression<IFloatingPointSort> TestObject = new FloatingPointSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
    }

    [Test]
    public void Interface_ISymbolExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        FloatingPointSymbol TestSymbol = new(Binder, TestName);
        using ISymbolExpression TestObject = new FloatingPointSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
    }

    [Test]
    public void Interface_IArithmeticExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        FloatingPointSymbol TestSymbol = new(Binder, TestName);
        using IArithmeticExpression TestObject = new FloatingPointSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        FloatingPointSymbol TestSymbol = new(Binder, TestName);
        using IExpression TestObject = new FloatingPointSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        FloatingPointSymbol TestSymbol = new(Binder, TestName);
        using FloatingPointSymbolExpression TestObject = new(Binder, TestSymbol);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }
}
