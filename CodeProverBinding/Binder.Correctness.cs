namespace CodeProverBinding;

using System;

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

        Binding(Prover.Z3, (ProverContextZ3 context) => context.Solver.Push());

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

        Binding(Prover.Z3, (ProverContextZ3 context) => context.Solver.Pop());

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
            bool IsSatisfied = context.Solver.Check() == Microsoft.Z3.Status.SATISFIABLE;

            if (IsSatisfied)
            {
                string ModelString = context.Solver.Model.ToString();
                ModelString = ModelString.Replace("\r\n", "\n");
                ModelString = ModelString.Replace("\r", "\n");
                ModelString = ModelString.Replace("\n", Environment.NewLine);

                SatisfiedModel = ModelString;
            }
            else
                SatisfiedModel = string.Empty;

            if (CorrectnessCheckType == CorrectnessCheckType.Satisfiable)
                IsCorrect = IsSatisfied;
            else
                IsCorrect = !IsSatisfied;
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

    /// <summary>
    /// Gets the model that satisfies constraints.
    /// </summary>
    public string SatisfiedModel { get; private set; } = string.Empty;
}
