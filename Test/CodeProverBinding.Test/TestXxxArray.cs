namespace Miscellaneous;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestXxxArray
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        IExpression TestValue = Binder.Zero;
        using XxxArrayConstantExpression TestObject = new(Binder, TestValue);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Value, Is.EqualTo(0));
        Assert.True(TestObject.ExpressionZ3.Item is Expr);
        Assert.True(TestObject.ToString() is not null);

        string TestName = "x";
        XxxArraySymbol TestSymbol = new(Binder, TestName);

        Assert.That(TestSymbol.Name, Is.EqualTo(TestName));
        Assert.True(TestSymbol.Sort is IntegerSort);
        Assert.True(((ISymbol)TestSymbol).Sort is IntegerSort);
        Assert.That(TestSymbol.Sort, Is.EqualTo(CodeProverBinding.Sort.Integer));
        Assert.That(TestSymbol.ToString(), Is.EqualTo(TestName));

        using XxxArraySymbolExpression TestExpression = new(Binder, TestSymbol, CodeProverBinding.Sort.Integer);

        Assert.That(TestExpression.Binder, Is.EqualTo(Binder));
        Assert.That(TestExpression.Symbol, Is.EqualTo(TestSymbol));
        Assert.True(TestExpression.ExpressionZ3.Item is Expr);
        Assert.That(TestExpression.ToString(), Is.EqualTo($"{TestSymbol}"));

        Binder.GetXxxArrayConstantExpression(Binder.Zero);
        Binder.CreateXxxArraySymbolExpression(TestName, CodeProverBinding.Sort.Integer);
    }

    [Test]
    public void Alias()
    {
        Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        XxxArraySymbol TestObject = new(Binder, TestName);
        XxxArraySymbol TestAlias = (XxxArraySymbol)TestObject.NewAlias();

        Assert.That(TestAlias.Index, Is.EqualTo(TestObject.Index + 1));
        Assert.That(TestAlias.ToString(), Is.EqualTo(Binder.AliasNaming.GetAliasName(TestAlias)));
    }
}
