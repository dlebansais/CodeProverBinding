namespace CodeProverBinding;

/// <summary>
/// Represents an expression.
/// </summary>
public abstract class Expression : IExpression
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Expression"/> class.
    /// </summary>
    /// <param name="binder">The binder.</param>
    public Expression(Binder binder)
    {
        Binder = binder;
    }

    /// <inheritdoc/>
    public Binder Binder { get; }

    /// <inheritdoc/>
    public void Assert()
    {
        if (ExpressionZ3.Item is Microsoft.Z3.BoolExpr BooleanExpression)
            Binder.Binding(Prover.Z3, (ProverContextZ3 context) => { context.Solver.Assert(BooleanExpression); });
        else
            throw new CodeProverException("Only boolean expressions can be asserted.");
    }

    internal IExprCapsule ExpressionZ3 { get; private protected set; } = null!;
}
