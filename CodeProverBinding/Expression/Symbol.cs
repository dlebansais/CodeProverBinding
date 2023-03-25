namespace CodeProverBinding;

using System.Diagnostics;

/// <summary>
/// Represents a symbol.
/// </summary>
/// <typeparam name="TSort">The sort.</typeparam>
public abstract class Symbol<TSort> : ISymbol<TSort>
    where TSort : ISort
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Symbol{TSort}"/> class.
    /// </summary>
    /// <param name="name">The symbol name.</param>
    public Symbol(string name)
    {
        Debug.Assert(name != string.Empty);

        Name = name;
    }

    /// <summary>
    /// Gets the symbol name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the symbol sort.
    /// </summary>
    public abstract TSort Sort { get; }
}
