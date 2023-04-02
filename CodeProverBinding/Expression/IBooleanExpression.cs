namespace CodeProverBinding;

/// <summary>
/// Provides information about a boolean expression.
/// </summary>
public interface IBooleanExpression : IExpression
{
    /// <summary>
    /// Asserts the expression as true for the prover.
    /// </summary>
    void Assert();
}
