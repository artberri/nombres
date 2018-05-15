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
            var query = "SELECT n.*, SUM(q.value) AS total FROM names n INNER JOIN quantity q ON n.id = q.name GROUP BY n.id HAVING total > 1000 ORDER BY n.value ASC";
            return _db.Query<Name>(query);
        }

        public IEnumerable<Name> GetByProvince(int provinceId)
        {
            var query = "SELECT n.*, SUM(q.value) AS total FROM names n INNER JOIN quantity q ON n.id = q.name WHERE q.province = @ProvinceId GROUP BY n.id HAVING total > 100 ORDER BY n.value ASC";
            return _db.Query<Name>(query, new {ProvinceId = provinceId});
        }
    }
}
