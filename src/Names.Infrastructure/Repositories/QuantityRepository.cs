using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;
using Names.Domain.Entities;

namespace Names.Infrastructure.Repositories
{
    public class QuantityRepository : BaseRepository
    {
        public static List<Quantity> GetByName(int nameId)
        {
            var query = "SELECT q.year, SUM(q.value) as total FROM quantity q WHERE q.name = @NameId GROUP BY q.name, q.year ORDER BY q.year";
            return Query<List<Quantity>>(db => db.Query<Quantity>(query, new {NameId = nameId}).ToList());
        }
    }
}
