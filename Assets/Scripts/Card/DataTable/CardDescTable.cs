using System;
using System.Collections.Generic;
using System.Linq;
using CSVData.Extensions;
using Extension.DataTable;

namespace Card.Data {
    public class CardDescTable: IQueryAbleDataTable<CardDesc> {
        private readonly IReadOnlyDictionary<int, CardDesc> _table;
        
        public CardDescTable() {
            _table = SpreadSheet.SmartLoad<CardDesc>("CardTable", "Data")
                .ToDictionary(k => k.Number, k => k);
        }
        
        public IEnumerable<CardDesc> Query(Func<CardDesc, bool> pCondition) {
            return _table
                .Where(kvp => pCondition!.Invoke(kvp.Value))
                .Select(kvp => kvp.Value);
        }

        public CardDesc Get(int pId) =>
            _table.FirstOrDefault(kvp => kvp.Key == pId).Value;

    }
}