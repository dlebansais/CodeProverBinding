namespace CodeProverBinding;

using System.Threading;

/// <summary>
/// Represents an index of references.
/// </summary>
public record struct Reference
{
    /// <summary>
    /// Gets the index of the null reference.
    /// </summary>
    public static Reference Null { get; } = new Reference() { Internal = 0 };

    /// <summary>
    /// Gets the internal value of the index.
    /// </summary>
    public int Internal { get; init; }

    /// <summary>
    /// Returns a new reference.
    /// </summary>
    public static Reference New()
    {
        Reference Result = new Reference() { Internal = Interlocked.Increment(ref GlobalIndex) };

        return Result;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return Internal == 0 ? "Null" : $"&{Internal,8:X}";
    }

    private static int GlobalIndex = 0;
}
