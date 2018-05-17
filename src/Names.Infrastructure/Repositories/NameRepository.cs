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
            var query = @"SELECT n.id, n.value, n.gender, n.compound, qq.total
                            FROM names n INNER JOIN
                                (SELECT q.name, SUM(q.value) AS total
                                    FROM quantity q
                                    GROUP BY q.name
                                    ORDER BY total DESC
                                    LIMIT 1000
                                ) AS qq
                            ON n.id = qq.name
                            ORDER BY n.value ASC";

            return _db.Query<Name>(query);
        }

        public IEnumerable<Name> GetByProvince(int provinceId)
        {
            var query = @"SELECT n.id, n.value, n.gender, n.compound, qq.total
                            FROM names n INNER JOIN
                                (SELECT q.name, SUM(q.value) AS total
                                    FROM quantity q
                                    WHERE q.province = @ProvinceId
                                    GROUP BY q.name
                                    ORDER BY total DESC
                                    LIMIT 1000
                                ) AS qq
                            ON n.id = qq.name
                            ORDER BY n.value ASC";

            return _db.Query<Name>(query, new {ProvinceId = provinceId});
        }

        public IEnumerable<Name> GetByYear(int yearId)
        {
            var query = @"SELECT n.id, n.value, n.gender, n.compound, qq.total
                            FROM names n INNER JOIN
                                (SELECT q.name, SUM(q.value) AS total
                                    FROM quantity q
                                    WHERE q.year = @YearId
                                    GROUP BY q.name
                                    ORDER BY total DESC
                                    LIMIT 1000
                                ) AS qq
                            ON n.id = qq.name
                            ORDER BY n.value ASC";

            return _db.Query<Name>(query, new {YearId = yearId});
        }

        public IEnumerable<Name> GetByProvinceAndYear(int provinceId, int yearId)
        {
            var query = @"SELECT n.id, n.value, n.gender, n.compound, qq.total
                            FROM names n INNER JOIN
                                (SELECT q.name, SUM(q.value) AS total
                                    FROM quantity q
                                    WHERE q.province = @ProvinceId
                                        AND q.year = @YearId
                                    GROUP BY q.name
                                    ORDER BY total DESC
                                    LIMIT 1000
                                ) AS qq
                            ON n.id = qq.name
                            ORDER BY n.value ASC";

            return _db.Query<Name>(query, new {ProvinceId = provinceId, YearId = yearId});
        }
    }
}
