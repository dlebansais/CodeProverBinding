namespace Symbol;

using CodeProverBinding;
using NUnit.Framework;

[TestFixture]
public class TestFloatingPoint
{
    [Test]
    public void BasicTest()
    {
        string TestName = "x";
        FloatingPointSymbol TestObject = new(TestName);

        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IFloatingPointSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.FloatingPoint));
        Assert.That(TestObject.ToString(), Is.EqualTo(TestName));
    }

    [Test]
    public void Interface_ISymbolGeneric()
    {
        string TestName = "x";
        ISymbol<IFloatingPointSort> TestObject = new FloatingPointSymbol(TestName);

        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IFloatingPointSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.FloatingPoint));
    }

    [Test]
    public void Interface_ISymbol()
    {
        string TestName = "x";
        ISymbol TestObject = new FloatingPointSymbol(TestName);

        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IFloatingPointSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.FloatingPoint));
    }
}
