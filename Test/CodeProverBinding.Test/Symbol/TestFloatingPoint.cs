namespace Symbol;

using CodeProverBinding;
using NUnit.Framework;

[TestFixture]
public class TestFloatingPoint
{
    [Test]
    public void BasicTest()
    {
        Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        FloatingPointSymbol TestObject = new(Binder, TestName);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IFloatingPointSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.FloatingPoint));
        Assert.That(TestObject.Index, Is.EqualTo(0));
        Assert.That(TestObject.ToString(), Is.EqualTo(TestName));
    }

    [Test]
    public void Interface_ISymbolGeneric()
    {
        Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ISymbol<IFloatingPointSort> TestObject = new FloatingPointSymbol(Binder, TestName);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IFloatingPointSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.FloatingPoint));
    }

    [Test]
    public void Interface_ISymbol()
    {
        Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        ISymbol TestObject = new FloatingPointSymbol(Binder, TestName);

        Assert.That(TestObject.Binder, Is.EqualTo(Binder));
        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IFloatingPointSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.FloatingPoint));
    }

    [Test]
    public void Alias()
    {
        Binder Binder = Tools.CreateBinder();
        string TestName = "x";
        FloatingPointSymbol TestObject = new(Binder, TestName);
        FloatingPointSymbol TestAlias = (FloatingPointSymbol)TestObject.NewAlias();

        Assert.That(TestAlias.ToString(), Is.EqualTo(Binder.AliasNaming.GetAliasName(TestObject)));
    }
}
