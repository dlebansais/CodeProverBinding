namespace CodeProverBinding;

using System;
using System.Diagnostics;

/// <summary>
/// Provides bindings for code provers.
/// </summary>
public partial class Binder : IDisposable
{
    /// <summary>
    /// Performs an action for the provided prover.
    /// </summary>
    /// <typeparam name="TProverContext">The prover context matching <paramref name="prover"/>.</typeparam>
    /// <param name="prover">The prover.</param>
    /// <param name="action">The action to execute.</param>
    internal void Binding<TProverContext>(Prover prover, Action<TProverContext> action)
        where TProverContext : class, IProverContext
    {
        if (!Provers.Contains(prover))
            return;

        Debug.Assert(prover == Prover.Z3);

        BindingZ3(action);
    }

    private void BindingZ3<TProverContext>(Action<TProverContext> action)
        where TProverContext : class, IProverContext
    {
        if (ContextZ3 is null)
            ContextZ3 = new();

        Debug.Assert(ContextZ3 is TProverContext);

        action((TProverContext)(IProverContext)ContextZ3);
    }

    private ProverContextZ3? ContextZ3 = null;
}
