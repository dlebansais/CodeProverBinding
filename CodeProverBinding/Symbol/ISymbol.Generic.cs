namespace CodeProverBinding;

/// <summary>
/// Provides information about a symbol.
/// </summary>
/// <typeparam name="TSort">The sort.</typeparam>
public interface ISymbol<TSort>
    where TSort : ISort
{
    /// <summary>
    /// Gets the binder.
    /// </summary>
    Binder Binder { get; }

    /// <summary>
    /// Gets the symbol name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the symbol sort.
    /// </summary>
    TSort Sort { get; }
}
