using UnityEngine;

namespace Card {
    public enum Rarity {
        Common,
        Rare,
        Epic,
        Legendary,
        Arcana
    }
    public static class ExRarity {
        private static RarityTable _table = null;

        public static Rarity GetRandomRarity() {
            _table ??= Resources.Load<RarityTable>("RarityTable");
            return _table.GetRandomRarity();
        } 
    }
}