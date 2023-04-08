namespace CodeProverBinding;

using System;

/// <summary>
/// Provides bindings for code provers.
/// </summary>
public partial class Binder : IDisposable
{
    /// <summary>
    /// Gets the alias table.
    /// </summary>
    internal AliasTable AliasTable { get; } = new AliasTable();
}
