namespace CodeProverBinding;

using System;
using System.Collections.Generic;

/// <summary>
/// Provides bindings for code provers.
/// </summary>
public partial class Binder : IDisposable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Binder"/> class.
    /// </summary>
    /// <param name="prover">The selected prover.</param>
    public Binder(Prover prover)
    {
        if (prover == Prover.Default)
            Provers = new List<Prover>() { Prover.Z3 };
        else
            Provers = new List<Prover>() { prover };
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Binder"/> class.
    /// </summary>
    /// <param name="provers">The selected provers.</param>
    public Binder(IEnumerable<Prover> provers)
    {
        Provers = new List<Prover>();

        foreach (Prover Prover in provers)
            if (Prover != Prover.Default)
                Provers.Add(Prover);

        if (Provers.Count == 0)
            Provers.Add(Prover.Z3);
    }

    /// <summary>
    /// Gets the provers.
    /// </summary>
    public List<Prover> Provers { get; }
}
