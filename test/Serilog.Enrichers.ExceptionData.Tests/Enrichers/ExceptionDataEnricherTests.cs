using System;
using System.Linq;
using Serilog.Events;
using Serilog.Tests.Support;
using Xunit;

namespace Serilog.Tests.Enrichers
{
    public class ExceptionDataEnricherTests
    {
        [Fact]
        public void ExceptionDataEnricherIsApplied()
        {
            LogEvent evt = null;
            var log = new LoggerConfiguration()
                .Enrich.WithExceptionData()
                .WriteTo.Sink(new DelegatingSink(e => evt = e))
                .CreateLogger();

            try
            {
                throw new Exception {Data = {{"key", "value"}}};
            }
            catch (Exception exception)
            {
                log.Information(exception, "Has an ExceptionData property");
            }

            var actual = evt.Properties["ExceptionData"].DictionaryValue();

            Assert.NotNull(evt);
            Assert.Equal(1, actual.Count);
            Assert.Equal("key", (string) actual.Single().Key.Value);
            Assert.Equal("value", (string) actual.Single().Value.LiteralValue());
        }

        [Fact]
        public void ExceptionDataEnricherWithCustomPropertyNameIsApplied()
        {
            LogEvent evt = null;
            var log = new LoggerConfiguration()
                .Enrich.WithExceptionData("YetAnotherExceptionData")
                .WriteTo.Sink(new DelegatingSink(e => evt = e))
                .CreateLogger();

            try
            {
                throw new Exception {Data = {{"key", "value"}}};
            }
            catch (Exception exception)
            {
                log.Information(exception, "Has an YetAnotherExceptionData property");
            }

            var actual = evt.Properties["YetAnotherExceptionData"].DictionaryValue();

            Assert.NotNull(evt);
            Assert.Equal(1, actual.Count);
            Assert.Equal("key", (string) actual.Single().Key.Value);
            Assert.Equal("value", (string) actual.Single().Value.LiteralValue());
        }
    }
}