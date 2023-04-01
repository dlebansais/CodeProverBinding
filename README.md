# CodeProverBinding

Provides bindings for code provers.

## Purpose

This library is intended for programs that want to prove correctness of C# source code (although it can be used for other imperative languages).

When trying to prove correctness, an approach is to execute the following steps:
1. Translate the source code into a giant theorem.
2. Prove that the theorem holds.

This library provides an API to translate the source code to create the theorem. It then calls a third-party theorem prover and asks it to prove it. Currently, the library uses [Microsoft Z3](https://github.com/Z3Prover/z3) but it is designed to be more flexible.

## Supported features

+ Types: `bool`, integers (`int`, `uint`, `long` and `ulong`), `double`.
+ Constants for these types (`true`, `42`, `3.14`).
+ Variables.
+ Operators `+`, `-`, `*`, `/` and the modulo operator `%` on integers. The `-` unary operator. The `||`, `&&` and `!` logical operators.
+ `if` ... `then` ... `else`.

Loops are not supported yet.

## How to use this library

Consider the following code:

```csharp
int x, y, z;

x = 1;
y = 2;
z = x + y;
```

First we need to introduce 3 symbols (`x`, `y` and `z`). This is done with calls to create symbol functions. In this case, since they are integers, 3 calls to `CreateIntegerSymbol(string)`.
This declares symbols but does not provide any information about them. If we were to check the code correctness right now, the prover would say the code is correct, because `x` = 0, `y` = 0 and `z` = 0 are valid solutions of the problem.
This example emphasizes the way the prover works: it looks for values of symbol that satisfy the constraints. Any value. Since in this case there are no constraints yet, all values are possible and in particular 0, 0, 0.

Therefore we want to also specify constraints. Let's consider the next line:

```csharp
x = 1;
```

We have two things here: the constant `1` and the equality relation `x = 1`. For the former, a call to `GetIntegerConstant(1)` gets us the needed constant. Note that this function is not a *create* function because, conceptually, all such constants are already in the system. If you call `GetIntegerConstant(int)` with the same value twice, it will return the same object. If you called `CreateIntegerSymbol("x")` twice, it would return two different objects, representing two different symbols (you can have multiple `x` in a C# program).
The equality relation is then obtained with a call to `CreateEqualityExpression`. It does not add this equality as a constraint yet, because it could just be an intermediate step in a chain of expressions, and the prover has no way to know that. So we specify that it's a constraint with a call to `Assert`.

*(For brevity, the instance of the binder object is omitted below. For instance the first line would be `var x = binder.CreateIntegerSymbol();`)*

```csharp
var x = CreateIntegerSymbol("x");
var _1 = GetIntegerConstant(1);
var equalityX = CreateEqualityExpression(x, EqualityOperator.Equal, _1);
equalityX.Assert();
```

We can do the same with `y`. The case of `z` is slightly more complicated. First we need to create the `x + y` expression (with a call to `CreateBinaryArithmeticExpression`) then the equality expression. This finally gives us the following sequence of calls:

```csharp
var x = CreateIntegerSymbol("x");
var _1 = GetIntegerConstant(1);
var equalityX = CreateEqualityExpression(x, EqualityOperator.Equal, _1);
equalityX.Assert();

var y = CreateIntegerSymbol("y");
var _2 = GetIntegerConstant(2);
var equalityY = CreateEqualityExpression(y, EqualityOperator.Equal, _2);
equalityY.Assert();

var z = CreateIntegerSymbol("z");
var sumXY = CreateBinaryArithmeticExpression(x, BinaryArithmeticOperator.Add, y);
var equalityZ = CreateEqualityExpression(z, EqualityOperator.Equal, sumXY);
equalityZ.Assert();
```

We can now check the correctness of this code:

```csharp
CheckCorrectness();
```

And the result is in the `IsCorrect` property, which in this case is `true` because `x` = 1, `y` = 2 and `z` = 3 satisfies the constraints.

## Assertions

It is typical in code verification to check that some assertion holds true. For instance, a class can have invariants, checked after a class method returns. The syntax for specifying assertions (for example [spec#](https://www.microsoft.com/en-us/research/project/spec/)) doesn't really matter. We are interested in the translation to boolean expressions that can be added as constraints.
For instance, say we have the boolean expression `var isGreater = CreateComparisonExpression(…, ComparisonOperator.Greater, …)`. We want to check that `isGreater` holds, but we don't really need to keep the expression itself afterward. Think of it as an optimization.

Another example is invariants. When checking correctness, we're not looking for values that satisfy an invariant. We want to make sure that no value can possibly satisfy the *opposite* of the invariant, which is not the same thing.

Consider:

```csharp
public int X { get; set; }
public int Y { get; set; }
public int Z { get; set; }
// Invariant: Z == X + Y;
```

The set `X` = 1, `Y` = 2, `Z` = 3 satisfies the only constraint, `Z == X + Y`. But this is wrong! Nothing in the code enforces that `Z` is the sum of `X` and `Y`! This is just a *possibility* and the prover only cares about that.
So the proper way to see that the invariant, in fact, does not hold is to look for values that let the *opposite* of the invariant to be true.
For instance `X` = 0, `Y` = 0, `Z` = 3.

Generally, we sometimes want to find values that satisfy constraints, and sometimes ensure that no value can satisfy constraints. How is this apparent conundrum resolved?

In practice, in situations we want the system to not be satisfied, the result can be discarded. It's just a "check".

So the library provides two methods to save and restore the system state. In the case of the invariant above, the code would look like this:

```csharp
// Tell the library that for the next check, correctness is non-satisfiability, and save the current state.
SaveProverState(CorrectnessCheckType.NotSatisfiable);

// Add the invariant
var sumXY = CreateBinaryArithmeticExpression(X, BinaryArithmeticOperator.Add, Y);
var equalityZ = CreateEqualityExpression(Z, EqualityOperator.Equal, sumXY);
equalityZ.Assert();

CheckCorrectness();

if (!IsCorrect)
  ...

// Restore the state as it was before the call to SaveProverState().
RestoreProverState();

// From now on, correctness means satisfiability again.
```

## Abstract references

In addition to predefined basic types such as `int`, C# manipulate objects, through references. Methods are available to create symbols that are references: `CreateReferenceSymbol(string)`, `CreateReferenceSymbolExpression(string)` and `CreateReferenceSymbolExpression(IReferenceSymbol)`.

The library also provides methods to get reference constants, though in C# only one constant exists: `null`. Other references are generally anonymous objects and a code verifier would give them generated names.

To get the `null` constant expression, get the `Binding.Null` property.

The library allows to further distinguish between references to objects or references to arrays, using `CreateObjectReferenceSymbolExpression` and `CreateArrayReferenceSymbolExpression` methods.

## Predefined constants

We have seen above that one can get the abstract reference expression representing `null`. The following predefined constants are available:

+ `False`
+ `True`
+ `Zero` (the integer 0)
+ `FloatingPointZero` (the floating point 0)
+ `Null`

