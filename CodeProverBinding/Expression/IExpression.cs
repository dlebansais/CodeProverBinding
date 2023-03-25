namespace CodeProverBinding;

/// <summary>
/// Provides information about an expression.
/// </summary>
public interface IExpression
{
    /// <summary>
    /// Gets the binder.
    /// </summary>
    Binder Binder { get; }
}
