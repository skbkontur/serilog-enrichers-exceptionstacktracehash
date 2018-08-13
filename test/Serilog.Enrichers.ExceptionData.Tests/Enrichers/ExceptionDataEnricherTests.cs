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
                throw new Exception {Data = {{"key1", "value1"}, {"key2", "value2"}}};
            }
            catch (Exception exception)
            {
                log.Information(exception, "Have properties from Exception.Data");
            }

            Assert.NotNull(evt);
            Assert.Equal("value1", (string) evt.Properties["key1"].LiteralValue());
            Assert.Equal("value2", (string) evt.Properties["key2"].LiteralValue());
        }
    }
}