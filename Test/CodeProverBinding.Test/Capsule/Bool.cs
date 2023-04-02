namespace Capsule;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class Bool
{
    [Test]
    public void BasicTest()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkBool(false);

        using BoolExprCapsule TestObject = new() { Item = Item };

        Assert.That(TestObject.Item, Is.EqualTo(Item));
    }

    [Test]
    public void Interface_IBoolExprCapsule()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkBool(false);

        using IBoolExprCapsule TestObject = new BoolExprCapsule() { Item = Item };

        Assert.True(TestObject.Item is BoolExpr);
        Assert.That(TestObject.Item, Is.EqualTo(Item));
    }

    [Test]
    public void Interface_IExprCapsule()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkBool(false);

        using IExprCapsule TestObject = new BoolExprCapsule() { Item = Item };

        Assert.True(TestObject.Item is BoolExpr);
        Assert.That(TestObject.Item, Is.EqualTo(Item));
    }
}
