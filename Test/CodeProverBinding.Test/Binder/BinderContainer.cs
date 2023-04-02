namespace Binder;

using System;
using CodeProverBinding;

internal class BinderContainer : IDisposable
{
    public BinderExtended TestObject { get; } = new(Prover.Default);

    public void Dispose()
    {
        // Not disposing of TestObject is intentional, this triggers the destructor.
    }
}
