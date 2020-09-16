Source
    - https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test

1. From inside the reate a solution to hold your projects
    - dotnet new sln -o [nameOfSolution]


2. Create a console project
    - dotnet new console -o [nameOfProject]

4. Add the project to the solution with 
    - dotnet sln add ./[ProjectFolderName]/[nameOfProject]].csproj

5. Create a test project.
    - dotnet new xunit -o [nameOfProject].Tests

6. Add the test project to the solution
    - dotnet sln add ./[TestProjectFolderName]/[nameOfTestProject]].csproj

7. Add the Project as a dependency to the Test project:
    - dotnet add ./[TestProjectFolderName]/[nameOfTestProject]].csproj reference ./[ProjectFolderName]/[nameOfProject]].csproj

8. Add the Xunit NuGet Package 
    - dotnet add package dotnet-xunit --version 2.3.1