using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;
using Names.Domain.Entities;

namespace Names.Infrastructure.Repositories
{
    public class YearRepository : BaseRepository
    {
        public static List<Year> Get()
        {
            var query = "SELECT years.* FROM years ORDER BY years.value ASC";
            return Query<List<Year>>(db => db.Query<Year>(query).ToList());
        }
    }
}
