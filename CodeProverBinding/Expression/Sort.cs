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
}
