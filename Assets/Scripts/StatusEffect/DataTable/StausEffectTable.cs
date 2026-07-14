using System.Collections.Generic;
using System.Linq;
using CSVData.Extensions;
using Extension.DataTable;

namespace StatusEffect {
	public class StatusEffectTable: IDataTable<StatusEffectDesc> {
		private readonly IReadOnlyDictionary<int, StatusEffectDesc> _table;
        
		public StatusEffectTable() {
			_table = SpreadSheet.SmartLoad<StatusEffectDesc>("EffectTable", "Data")
				.ToDictionary(k => k.Number, k => k);
		}
        
		public StatusEffectDesc Get(int pId) =>
			_table.FirstOrDefault(kvp => kvp.Key == pId).Value;
	}
}