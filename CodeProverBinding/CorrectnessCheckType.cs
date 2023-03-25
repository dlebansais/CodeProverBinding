namespace CodeProverBinding;

/// <summary>
/// Type of check to prove correctness.
/// </summary>
public enum CorrectnessCheckType
{
    /// <summary>
    /// Correct if satisfiable.
    /// </summary>
    Satisfiable,

    /// <summary>
    /// Correct if not satisfiable.
    /// </summary>
    NotSatisfiable,
}
