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
using Serilog.Configuration;
using Serilog.Enrichers;

namespace Serilog
{
    /// <summary>
    /// Extends <see cref="LoggerConfiguration"/> to add enrichers for <see cref="System.Exception"/>.
    /// capabilities.
    /// </summary>
    public static class ExceptionStackTraceHashLoggerConfigurationExtensions
    {
        /// <summary>
        /// Enrich log events with a ExceptionStackTraceHash property containing the hash of exception's stack trace.
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="exceptionStackTraceHashPropertyName">Property name for stack trace of exception.</param>
        /// <param name="includeExceptionFullname">Allow to include exception type fullname to stack trace.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithExceptionStackTraceHash(
           this LoggerEnrichmentConfiguration enrichmentConfiguration,
           string exceptionStackTraceHashPropertyName = null,
           bool includeExceptionFullname = false
           )
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new ExceptionStackTraceHashEnricher(exceptionStackTraceHashPropertyName, includeExceptionFullname));
        }
    }
}