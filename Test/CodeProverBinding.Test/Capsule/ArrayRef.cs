namespace Capsule;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class ArrayRef
{
    [Test]
    public void BasicTest()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkInt(1);
        Reference Index = Reference.New();

        using ArrayRefExprCapsule TestArray = new() { Item = Item, Index = Index };

        Assert.That(TestArray.Item, Is.EqualTo(Item));
        Assert.That(TestArray.Index, Is.EqualTo(Index));
    }

    [Test]
    public void Interface_IArrayRefExprCapsule()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkInt(1);
        Reference Index = Reference.New();

        using IArrayRefExprCapsule TestArray = new ArrayRefExprCapsule() { Item = Item, Index = Index };

        Assert.True(TestArray.Item is IntExpr);
        Assert.That(TestArray.Index, Is.EqualTo(Index));
        Assert.That(TestArray.Item, Is.EqualTo(Item));
    }

    [Test]
    public void Interface_IRefExprCapsule()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkInt(1);
        Reference Index = Reference.New();

        using IRefExprCapsule TestArray = new ArrayRefExprCapsule() { Item = Item, Index = Index };

        Assert.True(TestArray.Item is IntExpr);
        Assert.That(TestArray.Item, Is.EqualTo(Item));
    }

    [Test]
    public void Interface_IExprCapsuleGeneric()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkInt(1);
        Reference Index = Reference.New();

        using IExprCapsule<IntExpr> TestArray = new ArrayRefExprCapsule() { Item = Item, Index = Index };

        Assert.True(TestArray.Item is IntExpr);
        Assert.That(TestArray.Item, Is.EqualTo(Item));
    }

    [Test]
    public void Interface_IExprCapsule()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkInt(1);
        Reference Index = Reference.New();

        using IExprCapsule TestArray = new ArrayRefExprCapsule() { Item = Item, Index = Index };

        Assert.True(TestArray.Item is IntExpr);
        Assert.That(TestArray.Item, Is.EqualTo(Item));
    }
}
