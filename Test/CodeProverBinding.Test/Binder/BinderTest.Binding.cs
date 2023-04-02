namespace Binder;

using System.Collections.Generic;
using CodeProverBinding;
using NUnit.Framework;

[TestFixture]
public partial class BinderTest
{
    [Test]
    public void BindingDefault()
    {
        Binder DefaultBinder = new Binder(Prover.Default);

        Assert.That(DefaultBinder.Provers.Count, Is.EqualTo(1));
        Assert.That(DefaultBinder.Provers[0], Is.EqualTo(Prover.Z3));
    }

    [Test]
    public void BindingZ3()
    {
        Binder Z3Binder = new Binder(Prover.Z3);

        Assert.That(Z3Binder.Provers.Count, Is.EqualTo(1));
        Assert.That(Z3Binder.Provers[0], Is.EqualTo(Prover.Z3));
    }

    [Test]
    public void BindingEmptyList()
    {
        Binder Z3Binder = new Binder(new List<Prover>());

        Assert.That(Z3Binder.Provers.Count, Is.EqualTo(1));
        Assert.That(Z3Binder.Provers[0], Is.EqualTo(Prover.Z3));
    }

    [Test]
    public void BindingDefaultList()
    {
        Binder DefaultBinder = new Binder(new List<Prover>() { Prover.Default });

        Assert.That(DefaultBinder.Provers.Count, Is.EqualTo(1));
        Assert.That(DefaultBinder.Provers[0], Is.EqualTo(Prover.Z3));
    }

    [Test]
    public void BindingZ3List()
    {
        Binder Z3Binder = new Binder(new List<Prover>() { Prover.Z3 });

        Assert.That(Z3Binder.Provers.Count, Is.EqualTo(1));
        Assert.That(Z3Binder.Provers[0], Is.EqualTo(Prover.Z3));
    }

    [Test]
    public void BindingListMultiple()
    {
        Binder Z3Binder = new Binder(new List<Prover>() { Prover.Default, Prover.Z3 });

        Assert.That(Z3Binder.Provers.Count, Is.EqualTo(1));
        Assert.That(Z3Binder.Provers[0], Is.EqualTo(Prover.Z3));
    }
}
