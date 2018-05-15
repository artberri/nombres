using System;
using System.Collections.Generic;
using System.Data;

namespace Names.Infrastructure.Client
{
    public interface IDbClient
    {
        IEnumerable<T> Query<T>(string query, object param = null);
    }
}
