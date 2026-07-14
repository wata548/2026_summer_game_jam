using System;
using System.Collections.Generic;
using System.Linq;
using CSVData.Extensions;
using Extension.DataTable;

namespace Item.Data {
	public class ItemDescTable: IDataTable<ItemDesc> {
		private readonly IReadOnlyDictionary<int, ItemDesc> _table;
        
		public ItemDescTable() {
			_table = SpreadSheet.SmartLoad<ItemDesc>("ItemTable", "Data")
				.ToDictionary(k => k.Number, k => k);
		}
        
		public ItemDesc Get(int pId) =>
			_table.FirstOrDefault(kvp => kvp.Key == pId).Value;
	}
}