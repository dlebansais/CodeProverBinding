namespace ConstantExpression;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestAliasNaming
{
    [Test]
    public void BasicTest()
    {
        using Binder Binder = Tools.CreateBinder();
        IAliasNaming TestAliasNaming = Binder.AliasNaming;

        ISymbol TestSymbol = Binder.CreateBooleanSymbol("x");
        string AliasName = TestAliasNaming.GetAliasName(TestSymbol);

        Assert.That(AliasName, Is.EqualTo(TestSymbol.ToString()));
    }
}
