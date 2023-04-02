namespace Capsule;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class Ref
{
    [Test]
    public void BasicTest()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkInt(1);
        Reference Index = Reference.New();

        using RefExprCapsule TestObject = new() { Item = Item, Index = Index };

        Assert.That(TestObject.Item, Is.EqualTo(Item));
        Assert.That(TestObject.Index, Is.EqualTo(Index));
    }

    [Test]
    public void Interface_IRefExprCapsule()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkInt(1);
        Reference Index = Reference.New();

        using IRefExprCapsule TestObject = new RefExprCapsule() { Item = Item, Index = Index };

        Assert.True(TestObject.Item is IntExpr);
        Assert.That(TestObject.Index, Is.EqualTo(Index));
        Assert.That(TestObject.Item, Is.EqualTo(Item));
    }

    [Test]
    public void Interface_IExprCapsuleGeneric()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkInt(1);
        Reference Index = Reference.New();

        using IExprCapsule<IntExpr> TestObject = new RefExprCapsule() { Item = Item, Index = Index };

        Assert.True(TestObject.Item is IntExpr);
        Assert.That(TestObject.Item, Is.EqualTo(Item));
    }

    [Test]
    public void Interface_IExprCapsule()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkInt(1);
        Reference Index = Reference.New();

        using IExprCapsule TestObject = new RefExprCapsule() { Item = Item, Index = Index };

        Assert.True(TestObject.Item is IntExpr);
        Assert.That(TestObject.Item, Is.EqualTo(Item));
    }
}
