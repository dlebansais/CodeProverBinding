namespace CodeProverBinding;

using System.Threading;

/// <summary>
/// Represents an index of references.
/// </summary>
public record struct ReferenceIndex
{
    /// <summary>
    /// Gets the index of the null reference.
    /// </summary>
    public static ReferenceIndex Null { get; } = new ReferenceIndex() { Internal = 0 };

    /// <summary>
    /// Gets the internal value of the index.
    /// </summary>
    public int Internal { get; init; }

    /// <summary>
    /// Returns a new reference.
    /// </summary>
    public static ReferenceIndex New()
    {
        ReferenceIndex Result = new ReferenceIndex() { Internal = Interlocked.Increment(ref GlobalIndex) };

        return Result;
    }

    private static int GlobalIndex = 0;
}
