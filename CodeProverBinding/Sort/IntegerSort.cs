namespace CodeProverBinding;

/// <summary>
/// Represents the integer sort.
/// </summary>
public class IntegerSort : Sort, IIntegerSort
{
    /// <summary>
    /// Gets the Z3 sort.
    /// </summary>
    /// <param name="context">The Z3 context.</param>
    public override Microsoft.Z3.Sort GetSortZ3(IProverContext context)
    {
        return ((ProverContextZ3)context).Context.IntSort;
    }
}
