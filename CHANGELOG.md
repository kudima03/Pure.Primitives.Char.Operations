# Changelog

All notable changes to Pure.Primitives.Char.Operations are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.4.0] — 2025-11-22

### Changed

- The package now multi-targets `net7.0`, `net8.0`, `net9.0`, and `net10.0`
  (previously `net9.0` only).

## [0.3.0] — 2025-11-01

### Added

- **`BoolValue`** on `EqualCondition`, `NotEqualCondition`, `IsControlCondition`,
  `IsDigitCondition`, `IsLetterCondition`, `IsLetterOrDigitCondition`,
  `IsLowerCondition`, `IsPunctuationCondition`, `IsSeparatorCondition`,
  `IsSymbolCondition`, `IsUpperCondition`, and `IsWhitespaceCondition` is now a
  public property (previously accessible only through the explicit `IBool`
  interface implementation).

## [0.2.0] — 2025-11-01

### Changed

- **Breaking:** `EqualCondition`, `NotEqualCondition`, `IsControlCondition`,
  `IsDigitCondition`, `IsLetterCondition`, `IsLetterOrDigitCondition`,
  `IsLowerCondition`, `IsPunctuationCondition`, `IsSeparatorCondition`,
  `IsSymbolCondition`, `IsUpperCondition`, and `IsWhitespaceCondition` each had
  their two constructors (`params IChar[]` and `IEnumerable<IChar>`)
  consolidated into a single `params IEnumerable<IChar>` constructor.
- The package is now marked AOT- and trim-compatible (`IsAotCompatible`).

## [0.1.0] — 2025-06-13

### Added

- **`EqualCondition`** — `IBool` that is `true` when all supplied `IChar`
  values are equal.
- **`NotEqualCondition`** — `IBool` that is `true` when the supplied `IChar`
  values are not all equal.
- **`IsControlCondition`**, **`IsDigitCondition`**, **`IsLetterCondition`**,
  **`IsLetterOrDigitCondition`**, **`IsLowerCondition`**,
  **`IsPunctuationCondition`**, **`IsSeparatorCondition`**,
  **`IsSymbolCondition`**, **`IsUpperCondition`**, **`IsWhitespaceCondition`**
  — `IBool` implementations that are `true` when every supplied `IChar` value
  satisfies the corresponding `char.Is*` classification.
- Each condition throws `ArgumentException` when constructed with no values.
