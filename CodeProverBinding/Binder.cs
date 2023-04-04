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
            Provers.Add(Prover.Z3);
        else
            Provers.Add(prover);

        SetConstants();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Binder"/> class.
    /// </summary>
    /// <param name="provers">The selected provers.</param>
    public Binder(IEnumerable<Prover> provers)
    {
        foreach (Prover Prover in provers)
            if (Prover != Prover.Default)
                Provers.Add(Prover);

        if (Provers.Count == 0)
            Provers.Add(Prover.Z3);

        SetConstants();
    }

    /// <summary>
    /// Sets the binder standard constants.
    /// </summary>
    private void SetConstants()
    {
        False = GetBooleanConstant(false);
        True = GetBooleanConstant(true);
        Zero = GetIntegerConstant(0);
        FloatingPointZero = GetFloatingPointConstant(0);
        Null = GetReferenceConstant(Reference.Null);
    }

    /// <summary>
    /// Gets the provers.
    /// </summary>
    public List<Prover> Provers { get; } = new List<Prover>();

    /// <summary>
    /// Gets or sets the alias naming scheme.
    /// </summary>
    public IAliasNaming AliasNaming { get; set; } = new AliasNaming();
}
