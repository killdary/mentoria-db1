using Restaurante.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Queries
{
    public class QueryResult : Notification, IQueryResult
    {
        public QueryResult(long rowCount, object data)
        {
            RowCount = rowCount;
            Data = data;
            Executed = DateTime.Now;
        }

        public long RowCount { get; private set; }
        public object Data { get; private set; }
        public DateTime Executed { get; private set; }

    }


    public class QueryResult<T> : Notification, IQueryResult
    {
        public QueryResult(long rowCount, IEnumerable<T> data)
        {
            RowCount = rowCount;
            Data = data;
            Executed = DateTime.Now;
        }

        public long RowCount { get; private set; }
        public IEnumerable<T> Data { get; private set; }
        public DateTime Executed { get; private set; }

    }
}
