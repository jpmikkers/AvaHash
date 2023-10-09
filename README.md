# AvaHash

AvaHash is a small and portable desktop app to calculate file hashes. It was created using [AvaloniaUI](https://www.avaloniaui.net/) and [communitytoolkit.MVVM](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/).

AvaHash was tested on Windows 11 and Linux, but should also work on MacOS.

## Screenshot

![image](https://github.com/jpmikkers/AvaHash/assets/10578746/0723dfa2-f92c-42b1-9b4e-21bde38e7d53)

## Build & run Instructions (Windows)

First make sure to install the dotnet 7 sdk as per these instructions: [https://learn.microsoft.com/en-us/dotnet/core/install/windows?tabs=net70](https://learn.microsoft.com/en-us/dotnet/core/install/windows?tabs=net70)

To build, go to the AvaHash subdirectory that contains `AvaHash.csproj`. Then run the following commands:

    dotnet restore
    dotnet run --configuration Release

## Build & run Instructions (Linux)

First make sure to install the dotnet 7 sdk as per these instructions: [https://learn.microsoft.com/en-us/dotnet/core/install/linux](https://learn.microsoft.com/en-us/dotnet/core/install/linux)

You can double check which .net sdk you have installed via the following command:

    user@Ubuntu:~/.local/share$ dotnet --list-sdks
    7.0.101 [/usr/share/dotnet/sdk]
    
    user@Ubuntu:~/.local/share$ dotnet --list-runtimes
    Microsoft.AspNetCore.App 7.0.1 [/usr/share/dotnet/shared/Microsoft.AspNetCore.App]
    Microsoft.NETCore.App 7.0.1 [/usr/share/dotnet/shared/Microsoft.NETCore.App]

To build and run, cd to the AvaHash subdirectory that contains `AvaHash.csproj`. Then run the following commands:

    dotnet restore
    dotnet run --configuration Release
