[![NuGet](https://img.shields.io/nuget/v/BCat.Aspire.MailDev.svg)](https://www.nuget.org/packages/BCat.Aspire.MailDev)
[![Downloads](https://img.shields.io/nuget/dt/BCat.Aspire.MailDev.svg)](https://www.nuget.org/packages/BCat.Aspire.MailDev)

# Aspire.Hosting.MailDev

MailDev integration for .NET Aspire applications. This package provides a simple way to add MailDev to your Aspire application for testing emails during development.

## Installation
In your AppHost project, install the .NET Aspire Keycloak Hosting library with [NuGet](https://www.nuget.org):
```dotnetcli
dotnet add package BCat.Aspire.MailDev
```

## Usage

In your `Program.cs` or Aspire host project:

```csharp
var builder = DistributedApplication.CreateBuilder(args);

// Simple usage
var maildev = builder.AddMailDev("maildev");

// With configuration
var maildev = builder.AddMailDev("maildev", options => options
    .WithPorts(httpPort: 8025, smtpPort: 2525)
    .WithAuth("admin", "secret"));

// Reference in other projects
var api = builder.AddProject<Projects.MyApiProject>("api")
    .WithReference(maildev);
```

## Feedback & contributing

https://github.com/dotnet/aspire