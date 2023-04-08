namespace Binder;

using System.Collections.Generic;
using CodeProverBinding;
using NUnit.Framework;

[TestFixture]
public partial class BinderTest
{
    [Test]
    public void BasicAliasTest()
    {
        Binder TestBinder = new Binder(Prover.Default);

        Assert.True(TestBinder.AliasTable.IsEmpty);

        ISymbol TestSymbol = TestBinder.CreateBooleanSymbol("x");
        Assert.False(TestSymbol.IsAlias);

        Assert.True(TestBinder.AliasTable.IsEmpty);

        ISymbol TestAlias0 = TestSymbol.NewAlias();

        Assert.True(TestAlias0.IsAlias);
        Assert.False(TestBinder.AliasTable.IsEmpty);
        Assert.That(TestBinder.AliasTable.GetAlias((SymbolBase)TestSymbol), Is.EqualTo(TestAlias0));

        ISymbol TestAlias1 = TestAlias0.NewAlias();

        Assert.True(TestAlias1.IsAlias);
        Assert.False(TestBinder.AliasTable.IsEmpty);
        Assert.That(TestBinder.AliasTable.GetAlias((SymbolBase)TestSymbol), Is.EqualTo(TestAlias1));
    }
}
