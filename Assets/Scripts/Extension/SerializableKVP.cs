using System;
using UnityEngine;

namespace Extension {
    [Serializable]
    public class SerializableKvp<TKey, TValue> {
        [field: SerializeField] public TKey Key{ get; private set; }
        [field: SerializeField] public TValue Value { get; private set; }
    }
}