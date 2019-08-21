# Ghost to GitHub Pages Converter

Converts a [Ghost](https://ghost.org/) 0.x [json export](https://help.ghost.org/article/13-import-export) into Jekyll compatible markdown files for GitHub pages.

[![Build status](https://ci.appveyor.com/api/projects/status/8p2a63ux1w9iyb2u?svg=true)](https://ci.appveyor.com/project/jrummell/ghosttogithubpagesconverter)

## Requirements

This is a dotnet core console application, so you'll need the latest dotnet core [2.1.x sdk](https://www.microsoft.com/net/download).

## Build

Build with dotnet:

    dotnet build

Use dotnet publish to create an executable:

    dotnet publish -r win10-x64

## Run

    GhostToGitHubPagesConverter.exe path-to-your-ghost-export.json
    
## Download

Get the latest bits from the [Releases](https://github.com/jrummell/GhostToGitHubPagesConverter/releases) tab.
