namespace ProverContext;

using System;
using CodeProverBinding;

internal class ProverContextZ3Extended : ProverContextZ3, IDisposable
{
    public ProverContextZ3Extended()
        : base()
    {
    }

    public void FakeFinalize()
    {
        Dispose(false);
    }
}
