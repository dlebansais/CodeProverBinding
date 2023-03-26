namespace CodeProverBinding;

/// <summary>
/// Represents an integer constant expression.
/// </summary>
/// <typeparam name="TInteger">The integer type.</typeparam>
public interface IIntegerConstantExpression<TInteger> : IConstantExpression<TInteger>, IIntegerExpression
    where TInteger : struct
{
}
