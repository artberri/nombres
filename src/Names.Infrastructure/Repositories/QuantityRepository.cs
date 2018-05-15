using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;
using Names.Domain.Entities;
using Names.Infrastructure.Client;

namespace Names.Infrastructure.Repositories
{
    public class QuantityRepository
    {
        private readonly IDbClient _db;

        public QuantityRepository(IDbClient db)
        {
            _db = db;
        }

        public IEnumerable<Quantity> GetByName(int nameId)
        {
            var query = "SELECT q.year, SUM(q.value) as total FROM quantity q WHERE q.name = @NameId GROUP BY q.name, q.year ORDER BY q.year";
            return _db.Query<Quantity>(query, new {NameId = nameId});
        }
    }
}
