namespace CodeProverBinding;

using System;
using System.Collections.Generic;
using Microsoft.Z3;

/// <summary>
/// Represents a context for the Z3 prover.
/// </summary>
internal partial class ProverContextZ3 : IProverContext, IDisposable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProverContextZ3"/> class.
    /// </summary>
    public ProverContextZ3()
    {
        // Need model generation turned on.
        Context = new Context(new Dictionary<string, string>() { { "model", "true" } });
        Solver = Context.MkSolver();
    }

    /// <summary>
    /// Gets the Z3 context.
    /// </summary>
    public Context Context { get; }

    /// <summary>
    /// Gets the Z3 solver.
    /// </summary>
    public Solver Solver { get; }
}
