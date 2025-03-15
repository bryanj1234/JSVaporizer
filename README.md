I like the idea of writing more C# and less JavaScript.

JSVaporizer is s lightweight project with the goal of unifying front end and back end code for Razor Pages applications,
without committing to Blazor.

It helps you to do these things:

1. Share C# application logic code between the front end and the back end.
2. Share C# data validation code between the front end and the back end.
3. Reduce the amount of front-end spaghetti.

JSVaporizer is a simple application of
[Microsoft.NET.Runtime.WebAssembly.Sdk](https://www.nuget.org/packages/Microsoft.NET.Runtime.WebAssembly.Sdk)
combined with [JavaScript interop](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.javascript?view=net-8.0).

***Currently supports only .NET 8***
