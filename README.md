# Pure.Primitives.Char.Operations

Character classification and comparison operations for **Pure** `IChar` primitives.

[![.NET build & test](https://github.com/kudima03/Pure.Primitives.Char.Operations/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.Char.Operations/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Primitives.Char.Operations/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.Char.Operations/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Primitives.Char.Operations)](https://www.nuget.org/packages/Pure.Primitives.Char.Operations)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Primitives.Char.Operations` provides sealed record types that perform classification and comparison operations on `IChar` values, returning results as `IBool`. Each type is a composable value object — lazy, side-effect-free, and fully AOT-compatible.

## Types

### Classification (implement `IBool`)

| Type | True when |
|------|-----------|
| `IsDigitCondition` | The character is a decimal digit |
| `IsLetterOrDigitCondition` | The character is a letter or decimal digit |
| `IsUpperCondition` | The character is an uppercase letter |
| `IsLowerCondition` | The character is a lowercase letter |
| `IsWhitespaceCondition` | The character is whitespace |
| `IsSeparatorCondition` | The character is a separator |
| `IsControlCondition` | The character is a control character |
| `IsSymbolCondition` | The character is a symbol |

### Comparison (implement `IBool`)

| Type | True when |
|------|-----------|
| `EqualCondition` | All supplied `IChar` values are equal |
| `NotEqualCondition` | Not all supplied `IChar` values are equal |

## Dependencies

- [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions) — `IChar` and `IBool` interfaces
