namespace CodeProverBinding;

/// <summary>
/// Represents an arithmetic symbol expression.
/// </summary>
/// <typeparam name="TSort">The symbol sort.</typeparam>
public interface IArithmeticSymbolExpression<TSort> : ISymbolExpression<TSort>
    where TSort : IArithmeticSort
{
}
