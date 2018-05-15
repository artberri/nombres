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
    public class YearRepository
    {
        private readonly IDbClient _db;

        public YearRepository(IDbClient db)
        {
            _db = db;
        }

        public IEnumerable<Year> Get()
        {
            var query = "SELECT years.* FROM years ORDER BY years.value ASC";
            return _db.Query<Year>(query);
        }
    }
}
