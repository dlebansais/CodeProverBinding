namespace Binder;

using CodeProverBinding;
using NUnit.Framework;

public partial class BinderTest
{
    [Test]
    public void ClassModelManager_Dispose()
    {
        using (BinderExtended TestObject = new BinderExtended(Prover.Default))
        {
        }
    }

    [Test]
    public void ClassModelManager_DoubleDispose()
    {
        using (BinderExtended TestObject = new BinderExtended(Prover.Default))
        {
            TestObject.Dispose();
        }
    }

    [Test]
    public void ClassModelManager_FakeFinalize()
    {
        using (BinderExtended TestObject = new BinderExtended(Prover.Default))
        {
            TestObject.FakeFinalize();
        }
    }

    [Test]
    public void ClassModelManager_Destructor()
    {
        using BinderContainer Container = new();
    }
}
