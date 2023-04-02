namespace CodeProverBinding;

using System.Collections.Generic;
using Microsoft.Z3;

public static class Tools
{
    public static Binder CreateBinder()
    {
         return new Binder(Prover.Default);
    }

    public static Context CreateZ3Context()
    {
        return new Context(new Dictionary<string, string>() { { "model", "true" } });
    }
}
