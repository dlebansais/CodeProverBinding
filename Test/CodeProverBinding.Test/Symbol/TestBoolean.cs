namespace Symbol;

using CodeProverBinding;
using NUnit.Framework;

[TestFixture]
public class TestBoolean
{
    [Test]
    public void BasicTest()
    {
        Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        BooleanSymbol TestObject = new(Binder, TestName);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IBooleanSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.Boolean));
        Assert.That(TestObject.Index, Is.EqualTo(0));
        Assert.That(TestObject.ToString(), Is.EqualTo(TestName));
    }

    [Test]
    public void Interface_ISymbolGeneric()
    {
        Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ISymbol<IBooleanSort> TestObject = new BooleanSymbol(Binder, TestName);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IBooleanSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.Boolean));
    }

    [Test]
    public void Interface_ISymbol()
    {
        Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ISymbol TestObject = new BooleanSymbol(Binder, TestName);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IBooleanSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.Boolean));
    }

    [Test]
    public void Alias()
    {
        Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        BooleanSymbol TestObject = new(Binder, TestName);
        BooleanSymbol TestAlias = (BooleanSymbol)TestObject.NewAlias();

        Assert.That(TestAlias.Index, Is.EqualTo(TestObject.Index + 1));
        Assert.That(TestAlias.ToString(), Is.EqualTo(Binder.AliasNaming.GetAliasName(TestAlias)));
    }
}
