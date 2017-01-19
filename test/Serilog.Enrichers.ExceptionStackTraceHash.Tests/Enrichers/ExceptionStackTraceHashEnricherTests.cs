using System;
using Serilog.Events;
using Serilog.Tests.Support;
using Xunit;

namespace Serilog.Tests.Enrichers
{
    public class ExceptionStackTraceHashEnricherTests
    {
        [Fact]
        public void ExceptionStackTraceHashEnricherIsApplied()
        {
            LogEvent evt = null;
            var log = new LoggerConfiguration()
                .Enrich.WithExceptionStackTraceHash()
                .WriteTo.Sink(new DelegatingSink(e => evt = e))
                .CreateLogger();

            try
            {
                throw new Exception("Calculate stack trace hash");
            }
            catch (Exception exception)
            {
                log.Information(exception, "Has an ExceptionStackTraceHash property");
            }

            Assert.NotNull(evt);
            Assert.NotEmpty((string) evt.Properties["ExceptionStackTraceHash"].LiteralValue());
        }

        [Fact]
        public void ExceptionStackTraceHashEnricherWithCustomPropertyNameIsApplied()
        {
            LogEvent evt = null;
            var log = new LoggerConfiguration()
                .Enrich.WithExceptionStackTraceHash("YetAnotherExceptionStackTraceHash")
                .WriteTo.Sink(new DelegatingSink(e => evt = e))
                .CreateLogger();

            try
            {
                throw new Exception("Calculate stack trace hash");
            }
            catch (Exception exception)
            {
                log.Information(exception, "Has an YetAnotherExceptionStackTraceHash property");
            }

            Assert.NotNull(evt);
            Assert.NotEmpty((string)evt.Properties["YetAnotherExceptionStackTraceHash"].LiteralValue());
        }
    }
}