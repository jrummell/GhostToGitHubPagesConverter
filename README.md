# Ghost to GitHub Pages Converter

Converts a [Ghost](https://ghost.org/) 0.x [json export](https://help.ghost.org/article/13-import-export) into Jekyll compatible markdown files for GitHub pages.

[![Actions Status](https://github.com/jrummell/GhostToGitHubPagesConverter/workflows/CI/badge.svg)](https://github.com/jrummell/GhostToGitHubPagesConverter/actions)

## Requirements

This is a dotnet core console application, so you'll need the latest dotnet core [3.x sdk](https://www.microsoft.com/net/download).

## Build

Build with dotnet:

    dotnet build

## Run

    GhostToGitHubPagesConverter.exe path-to-your-ghost-export.json

## Download

Get the latest bits from the [Releases](https://github.com/jrummell/GhostToGitHubPagesConverter/releases) tab.
