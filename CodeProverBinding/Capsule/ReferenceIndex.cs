namespace CodeProverBinding;

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
    /// Gets or sets the internal value of the index.
    /// </summary>
    public int Internal { get; set; }

    /// <summary>
    /// Return the index with an incremented internale value.
    /// </summary>
    public ReferenceIndex Increment()
    {
        ReferenceIndex Result = new ReferenceIndex() { Internal = Internal };

        Internal++;

        return Result;
    }
}
