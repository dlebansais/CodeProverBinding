namespace Binder;

using System.Collections.Generic;
using CodeProverBinding;
using NUnit.Framework;

[TestFixture]
public class BinderTestAlias
{
    [Test]
    public void BasicTest()
    {
        Binder TestBinder = new Binder(Prover.Default);
        AliasTable AliasTable = TestBinder.AliasTable;

        Assert.True(AliasTable.IsEmpty);

        ISymbol TestSymbol = TestBinder.CreateBooleanSymbol("x");
        Assert.False(TestSymbol.IsAlias);

        Assert.True(AliasTable.IsEmpty);

        ISymbol TestAlias0 = TestSymbol.NewAlias();

        Assert.True(TestAlias0.IsAlias);
        Assert.False(AliasTable.IsEmpty);
        Assert.That(AliasTable.GetAlias(TestSymbol), Is.EqualTo(TestAlias0));

        ISymbol TestAlias1 = TestAlias0.NewAlias();

        Assert.True(TestAlias1.IsAlias);
        Assert.False(AliasTable.IsEmpty);
        Assert.That(AliasTable.SymbolCount, Is.EqualTo(1));
        Assert.That(AliasTable.GetAlias(TestSymbol), Is.EqualTo(TestAlias1));
    }

    [Test]
    public void TableClone()
    {
        Binder TestBinder = new Binder(Prover.Default);
        AliasTable AliasTable = TestBinder.AliasTable;

        Assert.True(AliasTable.IsEmpty);

        ISymbol TestSymbol = TestBinder.CreateBooleanSymbol("x");
        ISymbol TestAlias0 = TestSymbol.NewAlias();
        ISymbol TestAlias1 = TestAlias0.NewAlias();

        AliasTable CloneTable = AliasTable.Clone();

        Assert.That(!CloneTable.IsEmpty);
        Assert.That(CloneTable.SymbolCount, Is.EqualTo(1));
        Assert.That(CloneTable.ContainsSymbol(TestSymbol));
        Assert.That(CloneTable.ContainsAlias(TestAlias0));
        Assert.That(CloneTable.ContainsAlias(TestAlias1));
        Assert.That(CloneTable.GetAlias(TestSymbol), Is.EqualTo(TestAlias1));

        List<ISymbol> Difference = CloneTable.GetDifference(AliasTable);
        Assert.That(Difference.Count, Is.EqualTo(0));
    }

    [Test]
    public void TableDifference()
    {
        Binder TestBinder = new Binder(Prover.Default);
        AliasTable AliasTable = TestBinder.AliasTable;

        Assert.True(AliasTable.IsEmpty);

        ISymbol TestSymbol = TestBinder.CreateBooleanSymbol("x");
        ISymbol TestAlias0 = TestSymbol.NewAlias();

        AliasTable CloneTable = AliasTable.Clone();

        Assert.That(!CloneTable.IsEmpty);
        Assert.That(CloneTable.ContainsSymbol(TestSymbol));
        Assert.That(CloneTable.ContainsAlias(TestAlias0));
        Assert.That(CloneTable.GetAlias(TestSymbol), Is.EqualTo(TestAlias0));

        ISymbol TestAlias1 = TestAlias0.NewAlias();

        List<ISymbol> DifferenceCloneToOriginal = CloneTable.GetDifference(AliasTable);
        Assert.That(DifferenceCloneToOriginal.Count, Is.EqualTo(0));

        List<ISymbol> DifferenceOriginalToClone = AliasTable.GetDifference(CloneTable);
        Assert.That(DifferenceOriginalToClone.Count, Is.EqualTo(1));
        Assert.That(DifferenceOriginalToClone[0], Is.EqualTo(TestAlias1));
    }

    [Test]
    public void TableMergeNoChange()
    {
        Binder TestBinder = new Binder(Prover.Default);
        AliasTable AliasTable = TestBinder.AliasTable;

        Assert.True(AliasTable.IsEmpty);

        ISymbol TestSymbolX = TestBinder.CreateBooleanSymbol("x");
        ISymbol TestAliasX = TestSymbolX.NewAlias();
        ISymbol TestSymbolY = TestBinder.CreateBooleanSymbol("y");
        ISymbol TestAliasY = TestSymbolY.NewAlias();

        AliasTable CloneTable = AliasTable.Clone();

        List<ISymbol> UpdatedAliasList = AliasTable.Merge(CloneTable);

        Assert.That(UpdatedAliasList.Count, Is.EqualTo(0));
        Assert.That(AliasTable.SymbolCount, Is.EqualTo(2));
        Assert.That(AliasTable.GetAlias(TestSymbolX), Is.EqualTo(TestAliasX));
        Assert.That(AliasTable.GetAlias(TestSymbolY), Is.EqualTo(TestAliasY));
    }

    [Test]
    public void TableMergeNoChangeBeforeClone()
    {
        Binder TestBinder = new Binder(Prover.Default);
        AliasTable AliasTable = TestBinder.AliasTable;

        Assert.True(AliasTable.IsEmpty);

        ISymbol TestSymbolX = TestBinder.CreateBooleanSymbol("x");
        ISymbol TestAliasX = TestSymbolX.NewAlias();
        ISymbol TestSymbolY = TestBinder.CreateBooleanSymbol("y");
        ISymbol TestAliasY = TestSymbolY.NewAlias();

        AliasTable CloneTable = AliasTable.Clone();

        ISymbol TestSymbolZ = TestBinder.CreateBooleanSymbol("z");
        ISymbol TestAliasZ = TestSymbolZ.NewAlias();

        List<ISymbol> UpdatedAliasList = AliasTable.Merge(CloneTable);

        Assert.That(UpdatedAliasList.Count, Is.EqualTo(0));
        Assert.That(AliasTable.SymbolCount, Is.EqualTo(3));
        Assert.That(AliasTable.GetAlias(TestSymbolX), Is.EqualTo(TestAliasX));
        Assert.That(AliasTable.GetAlias(TestSymbolY), Is.EqualTo(TestAliasY));
        Assert.That(AliasTable.GetAlias(TestSymbolZ), Is.EqualTo(TestAliasZ));
    }

    [Test]
    public void TableMergeChangeAfterClone()
    {
        Binder TestBinder = new Binder(Prover.Default);
        AliasTable AliasTable = TestBinder.AliasTable;

        Assert.True(AliasTable.IsEmpty);

        ISymbol TestSymbolX = TestBinder.CreateBooleanSymbol("x");
        ISymbol TestAliasX0 = TestSymbolX.NewAlias();
        ISymbol TestSymbolY = TestBinder.CreateBooleanSymbol("y");
        ISymbol TestAliasY0 = TestSymbolY.NewAlias();

        AliasTable CloneTable = AliasTable.Clone();

        ISymbol TestAliasX1 = TestAliasX0.NewAlias();
        ISymbol TestAliasY1 = TestAliasY0.NewAlias();

        List<ISymbol> UpdatedAliasList = AliasTable.Merge(CloneTable);

        Assert.That(UpdatedAliasList.Count, Is.EqualTo(2));

        ISymbol TestAliasX2 = AliasTable.GetAlias(TestSymbolX);
        ISymbol TestAliasY2 = AliasTable.GetAlias(TestSymbolY);

        Assert.True(UpdatedAliasList.Contains(TestAliasX2));
        Assert.True(UpdatedAliasList.Contains(TestAliasY2));
        Assert.That(AliasTable.SymbolCount, Is.EqualTo(2));
        Assert.That(TestAliasX2, Is.Not.EqualTo(TestAliasX0));
        Assert.That(TestAliasX2, Is.Not.EqualTo(TestAliasX1));
        Assert.That(TestAliasY2, Is.Not.EqualTo(TestAliasY0));
        Assert.That(TestAliasY2, Is.Not.EqualTo(TestAliasY1));
    }
}
