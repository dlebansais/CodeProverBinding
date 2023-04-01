namespace CodeProverBinding;

/// <summary>
/// Represents a sort.
/// </summary>
public abstract class Sort : ISort
{
    /// <summary>
    /// Gets the boolean sort.
    /// </summary>
    public static IBooleanSort Boolean { get; } = new BooleanSort();

    /// <summary>
    /// Gets the integer sort.
    /// </summary>
    public static IIntegerSort Integer { get; } = new IntegerSort();

    /// <summary>
    /// Gets the floating point sort.
    /// </summary>
    public static IFloatingPointSort FloatingPoint { get; } = new FloatingPointSort();

    /// <summary>
    /// Gets the reference sort.
    /// </summary>
    public static IReferenceSort Reference { get; } = new ReferenceSort();

    /// <summary>
    /// Gets the Z3 sort.
    /// </summary>
    /// <param name="context">The Z3 context.</param>
    public abstract Microsoft.Z3.Sort GetSortZ3(IProverContext context);
}
