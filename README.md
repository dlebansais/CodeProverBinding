# CodeProverBinding

Provides bindings for code provers.

## Purpose

This library is intended for programs that want to prove correctness of C# source code (though it can be used for other imperative languages).

When trying to prove correctness, an approach is to execute the following steps:
1. Translate the source code into a giant theorem.
2. Prove that the theorem holds.

This library provides an API to translate the source code to create the theorem. It then calls a third-party theorem prover and asks it to prove it. Currently, the library uses [Microsoft Z3](https://github.com/Z3Prover/z3) but it is designed to be more flexible.

## Supported features

+ Types: `bool`, integers (`int`, `uint`, `long` and `ulong`), `double`.
+ Variables.
+ Operators `+`, `-`, `*`, `/` and the modulo opetator `%` on integers.
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
This declares symbols but does not provide any information about them. If we were to check the code correctness right now, the prover would say the code is correct, because `x`=`0`, `y`=`0` and `z`=`0` are valid solutions of the problem.
This example emphasizes the way the prover works: it looks for values of symbol that satisfy the constraints. Any value. Since in this case there are no constraints yet, any value is possible and in particular `0`, `0`, `0`.

Therefore we want to also specify the constraints. Let's consider the next line:

```csharp
x = 1;
```

We have two things here: the constant `1` and the equality relation `x = 1`. For the former, a call to `GetIntegerConstant(1)` gets us the needed constant. Note that this function is not a *create* function because, conceptually, all such constants are already in the system. If you call `GetIntegerConstant(int)` with the same value twice, it will return the same object. If you called `CreateIntegerSymbol("x")` twice, it would return two different objects, representing two different symbols (you can have multiple `x` in a C# program).
