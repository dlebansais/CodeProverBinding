namespace Symbol;

using CodeProverBinding;
using NUnit.Framework;

[TestFixture]
public class TestBoolean
{
    [Test]
    public void BasicTest()
    {
        string TestName = "x";
        BooleanSymbol TestObject = new(TestName);

        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IBooleanSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.Boolean));
        Assert.That(TestObject.ToString(), Is.EqualTo($"{TestName}"));
    }

    [Test]
    public void Interface_ISymbolGeneric()
    {
        string TestName = "x";
        ISymbol<IBooleanSort> TestObject = new BooleanSymbol(TestName);

        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IBooleanSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.Boolean));
    }

    [Test]
    public void Interface_ISymbol()
    {
        string TestName = "x";
        ISymbol TestObject = new BooleanSymbol(TestName);

        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IBooleanSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.Boolean));
    }
}
