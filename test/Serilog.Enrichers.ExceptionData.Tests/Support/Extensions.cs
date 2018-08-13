using System.Collections.Generic;
using Serilog.Events;

namespace Serilog.Tests.Support
{
    public static class Extensions
    {
        public static IReadOnlyDictionary<ScalarValue, LogEventPropertyValue> DictionaryValue(this LogEventPropertyValue @this)
        {
            return ((DictionaryValue) @this).Elements;
        }

        public static object LiteralValue(this LogEventPropertyValue @this)
        {
            return ((ScalarValue) @this).Value;
        }
    }
}
