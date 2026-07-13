using Entity;

namespace Data {
	public abstract class ItemBase {
		public abstract int Id { get; }
		public abstract void Use();
	}
}