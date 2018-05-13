using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;
using Names.Domain.Entities;

namespace Names.Infrastructure.Repositories
{
    public class NameRepository : BaseRepository
    {
        public static List<Name> Get()
        {
            var query = "SELECT names.*, SUM(quantity.value) AS total FROM names INNER JOIN quantity ON names.id = quantity.name GROUP BY names.id HAVING total > 1000 ORDER BY value ASC";
            return Query<List<Name>>(db => db.Query<Name>(query).ToList());
        }
    }
}
