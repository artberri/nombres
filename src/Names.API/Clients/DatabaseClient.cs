using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationInsights;
using Names.Infrastructure.Client;

namespace Names.API.Clients
{
    public class DatabaseClient : DbClient, IDbClient
    {
        const string DependencyTypeName = "SQL";
        const string DependencyName = "(local)";

        private readonly TelemetryClient _telemetryClient;

        public DatabaseClient(TelemetryClient telemetryClient) : base()
        {
            _telemetryClient = telemetryClient;
        }

        public override IEnumerable<T> Query<T>(string query, object param = null)
        {
            IEnumerable<T> response;

            var success = false;
            var startTime = DateTime.UtcNow;
            var timer = Stopwatch.StartNew();
            try
            {
                response = base.Query<T>(query, param);
                success = true;
            }
            finally
            {
                timer.Stop();
                _telemetryClient.TrackDependency(DependencyTypeName, DependencyName, query, startTime, timer.Elapsed, success);
            }

            return base.Query<T>(query, param);
        }
    }
}
