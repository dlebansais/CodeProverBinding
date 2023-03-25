namespace CodeProverBinding;

using System;

/// <summary>
/// Represents a code prover exception.
/// </summary>
public class CodeProverException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CodeProverException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    internal CodeProverException(string message)
        : base(message)
    {
    }
}
