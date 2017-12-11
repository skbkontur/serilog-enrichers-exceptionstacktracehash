// Copyright 2013-2017 Serilog Contributors
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

using System.Collections;
using System.Linq;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    /// <summary>
    /// Enrich log events with an ExceptionData property containing the collection of key/value pairs that provide additional user-defined information about the exception.
    /// </summary>
    public class ExceptionDataEnricher : ILogEventEnricher
    {
        /// <summary>
        /// The property name added to enriched log events.
        /// </summary>
        string _exceptionDataPropertyName;

        /// <summary>
        /// The default name of the property added to enriched log events.
        /// </summary>
        public const string DefaultExceptionDataPropertyName = "ExceptionData";

        public ExceptionDataEnricher(string exceptionDataPropertyName = null)
        {
            _exceptionDataPropertyName = exceptionDataPropertyName ?? DefaultExceptionDataPropertyName;
        }

        /// <summary>
        /// Enrich the log event.
        /// </summary>
        /// <param name="logEvent">The log event to enrich.</param>
        /// <param name="propertyFactory">Factory for creating new properties to add to the event.</param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent.Exception?.Data == null || logEvent.Exception.Data.Count == 0) return;

            var dataDictionary = logEvent.Exception.Data
                                         .Cast<DictionaryEntry>()
                                         .Where(e => e.Key is string)
                                         .ToDictionary(e => (string) e.Key, e => e.Value);

            var property = propertyFactory.CreateProperty(_exceptionDataPropertyName, dataDictionary, true);

            logEvent.AddPropertyIfAbsent(property);
        }
    }
}