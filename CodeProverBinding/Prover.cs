namespace CodeProverBinding;

/// <summary>
/// Supported third-party provers.
/// </summary>
public enum Prover
{
    /// <summary>
    /// The default prover.
    /// </summary>
    Default,

    /// <summary>
    /// The Microsoft Z3 prover (https://github.com/Z3Prover/z3).
    /// </summary>
    Z3,
}
