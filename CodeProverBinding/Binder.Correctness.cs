namespace CodeProverBinding;

/// <summary>
/// Provides bindings for code provers.
/// </summary>
public partial class Binder
{
    /// <summary>
    /// Saves the current prover state, indicating whether the next check should be for or against satifiability.
    /// </summary>
    /// <param name="correctnessCheckType">The check to make for correctness.</param>
    /// <exception cref="CodeProverException">Prover state already saved.</exception>
    public void SaveProverState(CorrectnessCheckType correctnessCheckType)
    {
        if (IsStateSaved)
            throw new CodeProverException("Prover state already saved.");

        CorrectnessCheckType = correctnessCheckType;
        IsStateSaved = true;
    }

    /// <summary>
    /// Restores the prover state.
    /// </summary>
    /// <exception cref="CodeProverException">Prover state not saved.</exception>
    public void RestoreProverState()
    {
        if (!IsStateSaved)
            throw new CodeProverException("Prover state not saved.");

        CorrectnessCheckType = CorrectnessCheckType.Satisfiable;
        IsStateSaved = false;
    }

    /// <summary>
    /// Checks correctness of the system.
    /// </summary>
    public void CheckCorrectness()
    {
        IsCorrect = false;

        Binding(Prover.Z3, (ProverContextZ3 context) =>
        {
            if (CorrectnessCheckType == CorrectnessCheckType.Satisfiable)
                IsCorrect = context.Solver.Check() == Microsoft.Z3.Status.SATISFIABLE;
            else
                IsCorrect = context.Solver.Check() != Microsoft.Z3.Status.SATISFIABLE;
        });
    }

    /// <summary>
    /// Gets a value indicating whether the current prover state has been saved.
    /// </summary>
    public bool IsStateSaved { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the system is correct.
    /// </summary>
    public CorrectnessCheckType CorrectnessCheckType { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the system is correct.
    /// </summary>
    public bool IsCorrect { get; private set; }
}
