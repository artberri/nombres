using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace Names.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        protected static SqliteConnection GetDbConnection()
        {
            return new SqliteConnection("Data Source=../nombres.db");
        }

        protected static void Execute(Action<IDbConnection> query)
        {
            using (IDbConnection db = GetDbConnection())
            {
                query.Invoke(db);
            }
        }

        protected static T Query<T>(Func<IDbConnection, T> query)
        {
            using (IDbConnection db = GetDbConnection())
            {
                return query.Invoke(db);
            }
        }
    }
}
