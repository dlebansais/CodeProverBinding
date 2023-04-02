namespace Capsule;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class Arith
{
    [Test]
    public void BasicTest()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkReal("1.1");

        using ArithExprCapsule TestObject = new() { Item = Item };

        Assert.That(TestObject.Item, Is.EqualTo(Item));
    }

    [Test]
    public void Interface_IArithExprCapsuleGeneric()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkReal("1.1");

        using IArithExprCapsule<ArithExpr> TestObject = new ArithExprCapsule() { Item = Item };

        Assert.True(TestObject.Item is ArithExpr);
        Assert.That(TestObject.Item, Is.EqualTo(Item));
    }

    [Test]
    public void Interface_IArithExprCapsule()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkReal("1.1");

        using IArithExprCapsule TestObject = new ArithExprCapsule() { Item = Item };

        Assert.True(TestObject.Item is ArithExpr);
        Assert.That(TestObject.Item, Is.EqualTo(Item));
    }

    [Test]
    public void Interface_IExprCapsule()
    {
        Context Context = Tools.CreateZ3Context();
        var Item = Context.MkReal("1.1");

        using IExprCapsule TestObject = new ArithExprCapsule() { Item = Item };

        Assert.True(TestObject.Item is ArithExpr);
        Assert.That(TestObject.Item, Is.EqualTo(Item));
    }
}
