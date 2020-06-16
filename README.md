# udemy-angular-dotnetapi-neilcummings
code along to udemy course at https://www.udemy.com/course/learn-to-build-an-e-commerce-app-with-net-core-and-angular/

## dotnet CLI

all from the root folder of the project

`dotnet new sln --name DotnetAngular`
`dotnet new webapi -o src/Udemy.Skinet.Api`
`dotnet sln add ./src/Udemy.Skinet.Api`
`dotnet sln list`

`dotnet new classlib -o src/Udemy.Skinet.Core`
`dotnet new classlib -o src/Udemy.Skinet.Infrastructure`
`dotnet sln add ./src/Udemy.Skinet.Core`
`dotnet sln add ./src/Udemy.Skinet.Infrastructure`

## EF Core

in Visual Studio 2019 Package Mananger Console

`Add-Migration InitialCreate -o Data/Migrations`
`Update-Database`