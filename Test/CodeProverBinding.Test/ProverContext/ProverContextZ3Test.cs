namespace ProverContext;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

public partial class ProverContextZ3Test
{
    [Test]
    public void BasicTest()
    {
        using ProverContextZ3 TestObject = new ProverContextZ3();

        Assert.True(TestObject.Context is Context);
        Assert.True(TestObject.Solver is Solver);
    }
}
