namespace Symbol;

using CodeProverBinding;
using NUnit.Framework;

[TestFixture]
public class TestInteger
{
    [Test]
    public void BasicTest()
    {
        string TestName = "x";
        IntegerSymbol TestObject = new(TestName);

        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IIntegerSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.Integer));
        Assert.That(TestObject.ToString(), Is.EqualTo(TestName));
    }

    [Test]
    public void Interface_ISymbolGeneric()
    {
        string TestName = "x";
        ISymbol<IIntegerSort> TestObject = new IntegerSymbol(TestName);

        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IIntegerSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.Integer));
    }

    [Test]
    public void Interface_ISymbol()
    {
        string TestName = "x";
        ISymbol TestObject = new IntegerSymbol(TestName);

        Assert.That(TestObject.Name, Is.EqualTo(TestName));
        Assert.True(TestObject.Sort is IIntegerSort);
        Assert.That(TestObject.Sort, Is.EqualTo(Sort.Integer));
    }
}
