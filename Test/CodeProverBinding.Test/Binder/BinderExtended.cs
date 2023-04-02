namespace Binder;

using System;
using CodeProverBinding;

internal class BinderExtended : Binder, IDisposable
{
    public BinderExtended(Prover prover)
        : base(prover)
    {
    }

    public void FakeFinalize()
    {
        Dispose(false);
    }
}
