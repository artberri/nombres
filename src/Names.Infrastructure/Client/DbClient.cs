using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Names.Infrastructure.Client
{
    public class DbClient : IDbClient, IDisposable
    {
        private readonly IDbConnection _connection;

        public DbClient()
        {
            _connection = new SqliteConnection("Data Source=../../db/nombres.db");
        }

        public virtual IEnumerable<T> Query<T>(string query, object param = null)
        {
            return _connection.Query<T>(query, param);
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _connection.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
