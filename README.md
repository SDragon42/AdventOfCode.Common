# AdventOfCode.Common

Common services and extensions for use with the Advent of Code challenges.

The library targets .NET Standard 2.0. The test project targets .NET 8.0; use the .NET 8 SDK to run the repository checks.

## Build and test

Run these commands from the repository root:

```sh
dotnet restore
dotnet test --verbosity normal
dotnet build --no-restore --configuration Release
dotnet pack --no-restore --configuration Release --output .
```
