namespace CodeProverBinding;

using System;

/// <summary>
/// Provides information about an expression.
/// </summary>
public interface IExpression : IDisposable
{
    /// <summary>
    /// Gets the binder.
    /// </summary>
    Binder Binder { get; }

    /// <summary>
    /// Asserts the expression as true for the prover.
    /// </summary>
    /// <exception cref="CodeProverException">Only boolean expressions can be asserted.</exception>
    void Assert();
}
