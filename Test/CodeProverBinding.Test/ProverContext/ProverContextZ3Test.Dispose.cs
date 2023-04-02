namespace ProverContext;

using NUnit.Framework;

public partial class ProverContextZ3Test
{
    [Test]
    public void ClassModelManager_Dispose()
    {
        using (ProverContextZ3Extended TestObject = new ProverContextZ3Extended())
        {
        }
    }

    [Test]
    public void ClassModelManager_DoubleDispose()
    {
        using (ProverContextZ3Extended TestObject = new ProverContextZ3Extended())
        {
            TestObject.Dispose();
        }
    }

    [Test]
    public void ClassModelManager_FakeFinalize()
    {
        using (ProverContextZ3Extended TestObject = new ProverContextZ3Extended())
        {
            TestObject.FakeFinalize();
        }
    }

    [Test]
    public void ClassModelManager_Destructor()
    {
        using ProverContextZ3Container Container = new();
    }
}
