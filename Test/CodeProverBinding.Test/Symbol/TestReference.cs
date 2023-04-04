namespace Symbol;

using CodeProverBinding;
using NUnit.Framework;

[TestFixture]
public class TestReference
{
    [Test]
    public void BasicTest()
    {
        Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ReferenceSymbol TestObject = new(Binder, TestName);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IReferenceSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.Reference));
        Assert.That(TestObject.Index, Is.EqualTo(0));
        Assert.That(TestObject.ToString(), Is.EqualTo(TestName));
    }

    [Test]
    public void Interface_ISymbolGeneric()
    {
        Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ISymbol<IReferenceSort> TestObject = new ReferenceSymbol(Binder, TestName);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IReferenceSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.Reference));
    }

    [Test]
    public void Interface_ISymbol()
    {
        Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ISymbol TestObject = new ReferenceSymbol(Binder, TestName);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IReferenceSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.Reference));
    }

    [Test]
    public void Alias()
    {
        Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ReferenceSymbol TestObject = new(Binder, TestName);
        ReferenceSymbol TestAlias = (ReferenceSymbol)TestObject.NewAlias();

        Assert.That(TestAlias.Index, Is.EqualTo(TestObject.Index + 1));
        Assert.That(TestAlias.ToString(), Is.EqualTo(Binder.AliasNaming.GetAliasName(TestAlias)));
    }
}
