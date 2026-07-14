using Data;

namespace Item {
	public abstract class ItemBase {
		public abstract int Id { get; }
		public ItemDesc Info { get; }
		public abstract void Use();
		protected ItemBase() => DataTables.Instance.ItemsDesc.Get(Id);
	}
}