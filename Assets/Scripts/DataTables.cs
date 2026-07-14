using Card.Data;
using Item.Data;
using Extension;
using Extension.DataTable;
using UI.InGame;

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