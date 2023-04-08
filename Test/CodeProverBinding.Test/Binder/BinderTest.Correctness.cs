namespace Binder;

using CodeProverBinding;
using NUnit.Framework;

[TestFixture]
public class BinderTestCorrectness
{
    [Test]
    public void SaveRestore()
    {
        Binder TestBinder = Tools.CreateBinder();

        Assert.False(TestBinder.IsStateSaved);
        Assert.False(TestBinder.IsCorrect);
        Assert.That(TestBinder.CorrectnessCheckType, Is.EqualTo(CorrectnessCheckType.Satisfiable));

        TestBinder.SaveProverState(CorrectnessCheckType.Satisfiable);

        Assert.True(TestBinder.IsStateSaved);
        Assert.False(TestBinder.IsCorrect);
        Assert.That(TestBinder.CorrectnessCheckType, Is.EqualTo(CorrectnessCheckType.Satisfiable));

        TestBinder.RestoreProverState();

        Assert.False(TestBinder.IsStateSaved);
        Assert.False(TestBinder.IsCorrect);
        Assert.That(TestBinder.CorrectnessCheckType, Is.EqualTo(CorrectnessCheckType.Satisfiable));

        TestBinder.SaveProverState(CorrectnessCheckType.NotSatisfiable);

        Assert.True(TestBinder.IsStateSaved);
        Assert.False(TestBinder.IsCorrect);
        Assert.That(TestBinder.CorrectnessCheckType, Is.EqualTo(CorrectnessCheckType.NotSatisfiable));

        TestBinder.RestoreProverState();

        Assert.False(TestBinder.IsStateSaved);
        Assert.False(TestBinder.IsCorrect);
        Assert.That(TestBinder.CorrectnessCheckType, Is.EqualTo(CorrectnessCheckType.Satisfiable));

        TestBinder.CheckCorrectness();

        Assert.True(TestBinder.IsCorrect);

        TestBinder.SaveProverState(CorrectnessCheckType.NotSatisfiable);

        Assert.True(TestBinder.IsStateSaved);
        Assert.True(TestBinder.IsCorrect);
        Assert.That(TestBinder.CorrectnessCheckType, Is.EqualTo(CorrectnessCheckType.NotSatisfiable));

        TestBinder.CheckCorrectness();

        Assert.False(TestBinder.IsCorrect);

        TestBinder.RestoreProverState();

        Assert.False(TestBinder.IsStateSaved);
        Assert.False(TestBinder.IsCorrect);
        Assert.That(TestBinder.CorrectnessCheckType, Is.EqualTo(CorrectnessCheckType.Satisfiable));

        TestBinder.SaveProverState(CorrectnessCheckType.Satisfiable);
        Assert.Throws<CodeProverException>(() => TestBinder.SaveProverState(CorrectnessCheckType.Satisfiable));

        TestBinder.RestoreProverState();
        Assert.Throws<CodeProverException>(() => TestBinder.RestoreProverState());
    }

    [Test]
    public void Model()
    {
        Binder TestBinder = Tools.CreateBinder();
        string SatisfiedModel;

        TestBinder.CheckCorrectness();
        Assert.True(TestBinder.IsCorrect);

        SatisfiedModel = TestBinder.SatisfiedModel;
        Assert.That(SatisfiedModel, Is.EqualTo(string.Empty));

        TestBinder.SaveProverState(CorrectnessCheckType.Satisfiable);

        BooleanConstantExpression False = new BooleanConstantExpression(TestBinder, false);
        False.Assert();

        TestBinder.CheckCorrectness();
        Assert.False(TestBinder.IsCorrect);

        SatisfiedModel = TestBinder.SatisfiedModel;
        Assert.That(SatisfiedModel, Is.EqualTo(string.Empty));

        TestBinder.RestoreProverState();

        TestBinder.SaveProverState(CorrectnessCheckType.Satisfiable);

        BooleanSymbolExpression X = new BooleanSymbolExpression(TestBinder, new BooleanSymbol(TestBinder, "x"));
        X.Assert();

        TestBinder.CheckCorrectness();
        Assert.True(TestBinder.IsCorrect);

        SatisfiedModel = TestBinder.SatisfiedModel;
        Assert.That(SatisfiedModel, Is.Not.EqualTo(string.Empty));

        TestBinder.RestoreProverState();
    }
}
