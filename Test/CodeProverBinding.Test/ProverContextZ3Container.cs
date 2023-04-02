namespace ProverContext;

using System;

internal class ProverContextZ3Container : IDisposable
{
    public ProverContextZ3Extended TestObject { get; } = new();

    public void Dispose()
    {
        // Not disposing of TestObject is intentional, this triggers the destructor.
    }
}
