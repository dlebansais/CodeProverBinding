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
}
