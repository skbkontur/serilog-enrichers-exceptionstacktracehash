#!/bin/bash
dotnet restore
for path in src/*/*.csproj; do
    dirname="$(dirname "${path}")"
    dotnet build ${dirname} -c Release
done 
 
dotnet restore
for path in test/*/*.csproj; do
    dirname="$(dirname "${path}")"
    dotnet build ${dirname} -c Release
done 