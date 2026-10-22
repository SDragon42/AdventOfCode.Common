# AdventOfCode.Common

Common services and extensions for use with the Advent of Code challenges.

The library targets .NET Standard 2.0. The test project targets .NET 8.0; use the .NET 8 SDK to run the repository checks.

## Development setup (dev container)

The repository includes a [dev container](.devcontainer/devcontainer.json) with the .NET 8 SDK, so no local SDK install is needed.

Prerequisites:

- [Docker](https://www.docker.com/products/docker-desktop/) (or a compatible container runtime)
- [Visual Studio Code](https://code.visualstudio.com/) with the [Dev Containers extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers)

Steps:

1. Clone the repository and open the folder in VS Code.
2. Run **Dev Containers: Reopen in Container** from the Command Palette (`F1`).
3. Wait for the container to build. `dotnet restore` runs automatically after creation, and the C#, C# Dev Kit and GitHub Actions extensions are installed.
4. Use the integrated terminal to run the commands below.

Alternatively, open the repository in a GitHub Codespace, which uses the same configuration.

## Build and test

Run these commands from the repository root:

```sh
dotnet restore
dotnet test --verbosity normal
dotnet build --no-restore --configuration Release
dotnet pack --no-restore --configuration Release --output .
```
