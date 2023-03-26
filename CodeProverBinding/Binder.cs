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
    private Binder()
    {
        Provers = new List<Prover>();
        False = GetBooleanConstant(false);
        True = GetBooleanConstant(true);
        Zero = GetIntegerConstant(0);
        Null = GetReferenceConstant(Reference.Null);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Binder"/> class.
    /// </summary>
    /// <param name="prover">The selected prover.</param>
    public Binder(Prover prover)
        : this()
    {
        if (prover == Prover.Default)
            Provers.Add(Prover.Z3);
        else
            Provers.Add(prover);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Binder"/> class.
    /// </summary>
    /// <param name="provers">The selected provers.</param>
    public Binder(IEnumerable<Prover> provers)
        : this()
    {
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
