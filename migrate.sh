#!/bin/sh

PROJECT_PATH="../BEER/BEER.csproj"

cd ./DataAccessLibrary
dotnet ef database update 0 -s $PROJECT_PATH
dotnet ef migrations remove -s $PROJECT_PATH
dotnet ef migrations add Initial -s $PROJECT_PATH
dotnet ef database update -s $PROJECT_PATH
cd ..