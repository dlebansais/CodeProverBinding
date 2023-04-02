namespace Symbol;

using CodeProverBinding;
using NUnit.Framework;

[TestFixture]
public class TestReference
{
    [Test]
    public void BasicTest()
    {
        string TestName = "x";
        ReferenceSymbol TestObject = new(TestName);

        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IReferenceSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.Reference));
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestName}"));
    }

    [Test]
    public void Interface_ISymbolGeneric()
    {
        string TestName = "x";
        ISymbol<IReferenceSort> TestObject = new ReferenceSymbol(TestName);

        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IReferenceSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.Reference));
    }

    [Test]
    public void Interface_ISymbol()
    {
        string TestName = "x";
        ISymbol TestObject = new ReferenceSymbol(TestName);

        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IReferenceSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.Reference));
    }
}
