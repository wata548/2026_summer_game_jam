using Card.DataTable;
using Extension;
using Extension.DataTable;

namespace Data {
    public class DataTables: MonoSingleton<DataTables> {
        public IQueryAbleDataTable<CardDesc> CardDesc { get; private set; }

        private void Awake() {
            CardDesc = new CardDescTable();
        }
    }
}