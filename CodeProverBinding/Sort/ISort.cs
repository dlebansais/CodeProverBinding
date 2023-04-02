namespace CodeProverBinding;

/// <summary>
/// Provides information about a sort.
/// </summary>
public interface ISort
{
    /// <summary>
    /// Gets the Z3 sort.
    /// </summary>
    /// <param name="context">The Z3 context.</param>
    Microsoft.Z3.Sort GetSortZ3(IProverContext context);
}
