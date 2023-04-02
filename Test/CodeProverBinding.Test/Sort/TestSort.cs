namespace Sort;

using CodeProverBinding;
using Microsoft.Z3;
using NUnit.Framework;

[TestFixture]
public class TestSort
{
    [Test]
    public void Boolean()
    {
        IProverContext Context = new ProverContextZ3();
        IBooleanSort TestSort = CodeProverBinding.Sort.Boolean;

        var Z3Sort = TestSort.GetSortZ3(Context);
        Assert.True(Z3Sort is BoolSort);
    }

    [Test]
    public void Boolean_ISort()
    {
        IProverContext Context = new ProverContextZ3();
        ISort TestSort = CodeProverBinding.Sort.Boolean;

        var Z3Sort = TestSort.GetSortZ3(Context);
        Assert.True(Z3Sort is BoolSort);
    }

    [Test]
    public void Integer()
    {
        IProverContext Context = new ProverContextZ3();
        IIntegerSort TestSort = CodeProverBinding.Sort.Integer;

        var Z3Sort = TestSort.GetSortZ3(Context);
        Assert.True(Z3Sort is IntSort);
    }

    [Test]
    public void Integer_ISort()
    {
        IProverContext Context = new ProverContextZ3();
        ISort TestSort = CodeProverBinding.Sort.Integer;

        var Z3Sort = TestSort.GetSortZ3(Context);
        Assert.True(Z3Sort is IntSort);
    }

    [Test]
    public void FloatingPoint()
    {
        IProverContext Context = new ProverContextZ3();
        IFloatingPointSort TestSort = CodeProverBinding.Sort.FloatingPoint;

        var Z3Sort = TestSort.GetSortZ3(Context);
        Assert.True(Z3Sort is ArithSort);
    }

    [Test]
    public void FloatingPoint_ISort()
    {
        IProverContext Context = new ProverContextZ3();
        ISort TestSort = CodeProverBinding.Sort.FloatingPoint;

        var Z3Sort = TestSort.GetSortZ3(Context);
        Assert.True(Z3Sort is ArithSort);
    }

    [Test]
    public void Reference()
    {
        IProverContext Context = new ProverContextZ3();
        IReferenceSort TestSort = CodeProverBinding.Sort.Reference;

        var Z3Sort = TestSort.GetSortZ3(Context);
        Assert.True(Z3Sort is IntSort);
    }

    [Test]
    public void Reference_ISort()
    {
        IProverContext Context = new ProverContextZ3();
        ISort TestSort = CodeProverBinding.Sort.Reference;

        var Z3Sort = TestSort.GetSortZ3(Context);
        Assert.True(Z3Sort is IntSort);
    }
}
