namespace Capsule;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class Int
{
    [Test]
    public void BasicTest()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkInt(1);

        using IntExprCapsule TestObject = new() { Item = Item };

        Assert.That(TestObject.Item, Is.EqualTo(Item));
    }

    [Test]
    public void Interface_IIntExprCapsule()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkInt(1);

        using IIntExprCapsule TestObject = new IntExprCapsule() { Item = Item };

        Assert.True(TestObject.Item is IntExpr);
        Assert.That(TestObject.Item, Is.EqualTo(Item));
    }

    [Test]
    public void Interface_IExprCapsuleGeneric()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkInt(1);

        using IExprCapsule<IntExpr> TestObject = new IntExprCapsule() { Item = Item };

        Assert.True(TestObject.Item is IntExpr);
        Assert.That(TestObject.Item, Is.EqualTo(Item));
    }

    [Test]
    public void Interface_IArithExprCapsule()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkInt(1);

        using IArithExprCapsule TestObject = new IntExprCapsule() { Item = Item };

        Assert.True(TestObject.Item is ArithExpr);
        Assert.That(TestObject.Item, Is.EqualTo(Item));
    }

    [Test]
    public void Interface_IExprCapsule()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkInt(1);

        using IExprCapsule TestObject = new IntExprCapsule() { Item = Item };

        Assert.True(TestObject.Item is IntExpr);
        Assert.That(TestObject.Item, Is.EqualTo(Item));
    }
}
