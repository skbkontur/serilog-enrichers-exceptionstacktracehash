// Copyright 2013-2016 Serilog Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Diagnostics;
using System.Text;
using Serilog.Core;
using Serilog.Events;
using xxHashSharp;

namespace Serilog.Enrichers
{
    /// <summary>
    /// Enriches log events with an ExceptionStackTraceHash property containing hash of exception's stack trace/>.
    /// </summary>
    public class ExceptionStackTraceHashEnricher : ILogEventEnricher
    {
        /// <summary>
        /// Allow to include exception type fullname to stack trace.
        /// </summary>
        bool _includeExceptionFullName;

        /// <summary>
        /// The property name added to enriched log events.
        /// </summary>
        string _exceptionStackTraceHashPropertyName;

        /// <summary>
        /// The default name of the property added to enriched log events.
        /// </summary>
        public const string DefaultExceptionStackTraceHashPropertyName = "ExceptionStackTraceHash";

        public ExceptionStackTraceHashEnricher(string exceptionStackTraceHashPropertyName = null, bool includeExceptionFullName = false)
        {
            _includeExceptionFullName = includeExceptionFullName;
            _exceptionStackTraceHashPropertyName = exceptionStackTraceHashPropertyName ?? DefaultExceptionStackTraceHashPropertyName;
        }


        /// <summary>
        /// Enrich the log event.
        /// </summary>
        /// <param name="logEvent">The log event to enrich.</param>
        /// <param name="propertyFactory">Factory for creating new properties to add to the event.</param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent.Exception == null)
            {
                return;
            }

            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(_exceptionStackTraceHashPropertyName, GetExceptionStackTraceHash(logEvent.Exception)));
        }

        private string GetExceptionStackTraceHash(Exception exception)
        {
            var stackTraceString = (_includeExceptionFullName ? exception.GetType().FullName : string.Empty) + new StackTrace(exception, false);
            var stackTraceBytes = Encoding.UTF8.GetBytes(stackTraceString);
            return xxHash.CalculateHash(stackTraceBytes).ToString();
        }
    }
}