using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;
using Names.Domain.Entities;

namespace Names.Infrastructure.Repositories
{
    public class NameRepository
    {
        public static List<Name> Get()
        {
            var query = "SELECT names.*, SUM(quantity.quantity) AS total FROM names INNER JOIN quantity ON names.id = quantity.name GROUP BY names.id HAVING total > 1000 ORDER BY value ASC";
            return Query<List<Name>>(db => db.Query<Name>(query).ToList());
        }

        private static SqliteConnection GetDbConnection()
        {
            return new SqliteConnection("Data Source=../nombres.db");
        }

        private static void Execute(Action<IDbConnection> query)
        {
            using (IDbConnection db = GetDbConnection())
            {
                query.Invoke(db);
            }
        }

        private static T Query<T>(Func<IDbConnection, T> query)
        {
            using (IDbConnection db = GetDbConnection())
            {
                return query.Invoke(db);
            }
        }
    }
}
