using System.Collections.Generic;
using Names.Domain.Entities;
using Names.Infrastructure.Client;

namespace Names.Infrastructure.Repositories
{
    public class NameRepository
    {
        private readonly IDbClient _db;

        public NameRepository(IDbClient db)
        {
            _db = db;
        }
        public IEnumerable<Name> Get()
        {
            var query = "SELECT names.*, SUM(quantity.value) AS total FROM names INNER JOIN quantity ON names.id = quantity.name GROUP BY names.id HAVING total > 1000 ORDER BY value ASC";
            return _db.Query<Name>(query);
        }
    }
}
