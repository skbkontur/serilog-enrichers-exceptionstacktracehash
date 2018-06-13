# Serilog.Enrichers.Exception

## ExceptionStackTraceHashEnricher

Enriches Serilog events with hash from exception's stack trace.
 
To use the enricher, first install the NuGet package:

```powershell
Install-Package Serilog.Enrichers.Exception
```

Then, apply the enricher to you `LoggerConfiguration`:

```csharp
Log.Logger = new LoggerConfiguration()
    .Enrich.WithExceptionStackTraceHash()
    // ...other configuration...
    .CreateLogger();
```

The `WithExceptionStackTraceHash()` enricher will add a `ExceptionStackTraceHash` property to produced events.

## ExceptionDataEnricher

Enriches Serilog events with collection of key/value pairs from exception's `Data` property.
 
To use the enricher, first install the NuGet package:

```powershell
Install-Package Serilog.Enrichers.Exception
```

Then, apply the enricher to you `LoggerConfiguration`:

```csharp
Log.Logger = new LoggerConfiguration()
    .Enrich.WithExceptionData()
    // ...other configuration...
    .CreateLogger();
```

The `WithExceptionData()` enricher will add a properties from exception's `Data` property to produced events.
                                                                                                                                           
