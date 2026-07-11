using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Movement {
    public class KeyboardMovement: IMovement {
        public bool MoveFlip { get; set; }
        private readonly IReadOnlyDictionary<KeyCode, Vector3> _keyDirectionMatch = new Dictionary<KeyCode, Vector3>() {
            { KeyCode.W, Vector3.up },
            { KeyCode.S, Vector3.down },
            { KeyCode.A, Vector3.left },
            { KeyCode.D, Vector3.right },
        };

        public Vector3 GetDirection() {
            var result = _keyDirectionMatch
                .Where(kvp => Input.GetKey(kvp.Key))
                .Aggregate(Vector3.zero, (current, kvp) => current + kvp.Value);
            return result.normalized * (MoveFlip ? -1 : 1);
        }
    }
}