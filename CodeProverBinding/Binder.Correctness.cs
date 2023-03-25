namespace CodeProverBinding;

/// <summary>
/// Provides bindings for code provers.
/// </summary>
public partial class Binder
{
    /// <summary>
    /// Checks correctness of the system.
    /// </summary>
    public void CheckCorrectness()
    {
        IsCorrect = false;
    }

    /// <summary>
    /// Gets a value indicating whether the system is correct.
    /// </summary>
    public bool IsCorrect { get; private set; }
}
