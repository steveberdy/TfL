# Transport for London API Wrapper

This is a .NET wrapper for the Transport for London API.

## Getting Started

Add package using `dotnet add package TfLApi`.
Then add the assembly reference `TfL` and start using a `TfLClient`, like below:

```csharp
using TfL;
using TfL.Entities;

TfLClient client = new();
TfLRoutes[] lines = await client.Line.GetLinesByMode("tube");

// List all lines on the Underground
foreach (TfLRoutes line in lines)
{
    Console.WriteLine(line.Name);
}
```

## Building and Testing

To build: `dotnet build`

To test: `dotnet test src/TfL.Tests`
