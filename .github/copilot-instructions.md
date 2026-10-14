# Repository guidance

## Build and test

The library targets .NET Standard 2.0 and the xUnit test project targets .NET 8. Use the .NET 8 SDK. Run these commands from the repository root:

```sh
dotnet restore
dotnet test --verbosity normal
dotnet test tests/AdventOfCode.Common.Tests.csproj --filter "FullyQualifiedName~HighestCommonFactorTests"
dotnet test tests/AdventOfCode.Common.Tests.csproj --filter "FullyQualifiedName~HighestCommonFactor_twoValues"
dotnet build --no-restore --configuration Release
dotnet pack --no-restore --configuration Release --output .
```

The first filtered command runs one test class; the second runs one test method. Replace the filter value with a class or method name to narrow the run. CI runs restore, tests, a Release build, packaging, and publishing on pushes to `main`. There is no separate lint command; `.editorconfig` defines C# formatting and naming preferences.

## Architecture

`src/AdventOfCode.Common.csproj` is a dependency-light reusable library, while `tests/AdventOfCode.Common.Tests.csproj` references it and contains xUnit tests. The library targets .NET Standard 2.0, so keep public APIs compatible with that target.

- `Services` contains service interfaces and implementations. `InputReaderService` resolves puzzle data as `Day{day:00}/{name}.txt` under the configured input folder; `NumbersService` provides highest-common-factor and lowest-common-multiple operations.
- `Models/ArrayGrid<TCell>` implements `IGrid<TCell>` with a flat, row-major backing array. `GridHelper` handles point/index conversion and renders point- or list-based grids. Grid coordinates use `System.Drawing.Point`.
- `Extensions` provides parsing for numeric strings, digit access for `int` and `long`, and `IEnumerable<T>` helpers including `ForEach`, sliding `Windowed`, permutations, and cartesian products.
- `src` generates XML documentation and packages the root `README.md`; update documentation when changing public APIs.

## Code and test conventions

- Public library types and members use XML documentation. Service implementations implement interfaces under `Services/Interfaces`; keep changes to a service's contract and implementation aligned.
- Keep additions in the existing functional area (`Services`, `Models`, `Helpers`, or `Extensions`) and use the existing public static extension-class pattern for extension methods.
- Tests use xUnit `[Fact]` and `[Theory]`, with `[InlineData]` or `[MemberData]` for cases. Shared setup is kept in test base classes; test names follow `Method_scenario_expected`-style naming.
- Test files use global usings declared in `tests/Usings.cs`. Follow the surrounding files' namespace and formatting style, with four-space indentation as set by `.editorconfig`.
