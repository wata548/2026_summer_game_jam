using System;
using System.Collections.Generic;

namespace Extension.DataTable {
    public interface IDataTable<T> {
        public T Get(int pId);
    }
    public interface IQueryAbleDataTable<T>: IDataTable<T> {
        public IEnumerable<T> Query(Func<T, bool> pCondition);
    }
}