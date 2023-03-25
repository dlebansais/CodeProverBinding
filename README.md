# CodeProverBinding

Provides bindings for code provers.

## Purpose

This library is intended for programs that want to prove correctness of C# source code (though it can be used for other imperative languages).

When trying to prove correctness, an approach is to execute the following steps:
1. Translate the source code into a giant theorem.
2. Prove that the theorem holds.

This library provides an API to translate the source code to create the theorem. It then calls a third-party theorem prover and asks it to prove it. Currently, the library uses [Microsoft Z3](https://github.com/Z3Prover/z3) but it is designed to be more flexible.

## Supported features

+ Types: `bool`, integers (various incarnations of `int`), `double`.
+ Variables.
+ Operators `+`, `-`, `*`, `/` and the modulo opetator `%` on integers.
+ `if` ... `then` ... `else`.

Loops are not supported yet.

## The API

