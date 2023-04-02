namespace SymbolExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestInteger
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        IntegerSymbol TestSymbol = new(TestName);
        using IntegerSymbolExpression TestObject = new(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
        Assert.True(TestObject.ExpressionZ3.Item is IntExpr);
        Assert.True(TestObject.IntegerExpressionZ3 is IIntExprCapsule);
        Assert.True(TestObject.IntegerExpressionZ3.Item is IntExpr);
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestSymbol}"));
    }

    [Test]
    public void Interface_IIntegerSymbolExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        IntegerSymbol TestSymbol = new(TestName);
        using IIntegerSymbolExpression TestObject = new IntegerSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IArithmeticSymbolExpressionGeneric()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        IntegerSymbol TestSymbol = new(TestName);
        using IArithmeticSymbolExpression<IIntegerSort> TestObject = new IntegerSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
    }

    [Test]
    public void Interface_IArithmeticSymbolExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        IntegerSymbol TestSymbol = new(TestName);
        using IArithmeticSymbolExpression TestObject = new IntegerSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
    }

    [Test]
    public void Interface_ISymbolExpressionGeneric()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        IntegerSymbol TestSymbol = new(TestName);
        using ISymbolExpression<IIntegerSort> TestObject = new IntegerSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
    }

    [Test]
    public void Interface_ISymbolExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        IntegerSymbol TestSymbol = new(TestName);
        using ISymbolExpression TestObject = new IntegerSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Symbol, Is.EqualTo(TestSymbol));
    }

    [Test]
    public void Interface_IIntegerExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        IntegerSymbol TestSymbol = new(TestName);
        using IIntegerExpression TestObject = new IntegerSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void Interface_IExpression()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        IntegerSymbol TestSymbol = new(TestName);
        using IExpression TestObject = new IntegerSymbolExpression(Binder, TestSymbol);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
    }

    [Test]
    public void TestAssert()
    {
        using Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        IntegerSymbol TestSymbol = new(TestName);
        using IntegerSymbolExpression TestObject = new(Binder, TestSymbol);

        Assert.Throws<CodeProverException>(TestObject.Assert);
    }
}
