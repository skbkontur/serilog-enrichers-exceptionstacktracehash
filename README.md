# Serilog.Enrichers.ExceptionStackTraceHash

Enriches Serilog events with hash from exception's stack trace.
 
To use the enricher, first install the NuGet package:

```powershell
Install-Package Serilog.Enrichers.ExceptionStackTraceHash
```

Then, apply the enricher to you `LoggerConfiguration`:

```csharp
Log.Logger = new LoggerConfiguration()
    .Enrich.WithExceptionStackTraceHash()
    // ...other configuration...
    .CreateLogger();
```

The `WithExceptionStackTraceHash()` enricher will add a `ExceptionStackTraceHash` property to produced events.
                                                                                                                                           
