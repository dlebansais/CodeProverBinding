namespace CodeProverBinding;

/// <summary>
/// Represents the reference sort.
/// </summary>
public class ReferenceSort : Sort, IReferenceSort
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
