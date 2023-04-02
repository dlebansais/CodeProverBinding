namespace CodeProverBinding;

/// <summary>
/// Represents the floating point sort.
/// </summary>
public class FloatingPointSort : Sort, IFloatingPointSort
{
    /// <summary>
    /// Gets the Z3 sort.
    /// </summary>
    /// <param name="context">The Z3 context.</param>
    public override Microsoft.Z3.Sort GetSortZ3(IProverContext context)
    {
        return ((ProverContextZ3)context).Context.RealSort;
    }
}
