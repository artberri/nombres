using System.Collections.Generic;
using Names.Domain.Entities;
using Names.Infrastructure.Client;

namespace Names.Infrastructure.Repositories
{
    public class ProvinceRepository
    {
        private readonly IDbClient _db;

        public ProvinceRepository(IDbClient db)
        {
            _db = db;
        }
        public IEnumerable<Province> Get()
        {
            var query = "SELECT p.id, p.name FROM provinces p ORDER BY p.name ASC";
            return _db.Query<Province>(query);
        }
    }
}
