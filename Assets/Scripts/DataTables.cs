using Card.DataTable;
using Data.Item;
using Extension;
using Extension.DataTable;

namespace Data {
    public class DataTables: MonoSingleton<DataTables> {
        public IQueryAbleDataTable<CardDesc> CardDesc { get; private set; }
        public IDataTable<ItemDesc> ItemsDesc { get; private set; }

        private void Awake() {
            CardDesc = new CardDescTable();
            ItemsDesc = new ItemDescTable();
        }
    }
}