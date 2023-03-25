namespace ModelAnalyzer;

using Microsoft.Z3;

internal static class Encapsulation
{
    public static IBoolExprCapsule Encapsulate(this BoolExpr expr)
    {
        return new BoolExprCapsule() { Item = expr };
    }

    public static IIntExprCapsule Encapsulate(this IntExpr expr)
    {
        return new IntExprCapsule() { Item = expr };
    }

    public static IArithExprCapsule Encapsulate(this ArithExpr expr)
    {
        switch (expr)
        {
            case IntExpr Int:
                return new IntExprCapsule() { Item = Int };
            default:
                return new ArithExprCapsule() { Item = expr };
        }
    }
}
