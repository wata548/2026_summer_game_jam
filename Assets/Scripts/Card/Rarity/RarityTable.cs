using System.Collections.Generic;
using System.Linq;
using Extension;
using UnityEngine;

namespace Card {
    [CreateAssetMenu(menuName = "Rarity")]
    public class RarityTable: ScriptableObject {
        [SerializeField] private List<SerializableKvp<Rarity, int>> _table;
        private readonly System.Random _random = new();
        private int _sum = -1; 

        public Rarity GetRandomRarity() {
            if (_sum == -1)
                _sum = _table.Sum(kvp => kvp.Value);
            var r = _random.Next() % _sum;
            var current = 0;
            foreach (var kvp in _table) {
                current += kvp.Value;
                if (r < current)
                    return kvp.Key;
            }

            return _table[^ 1].Key;
        }  
    }
}