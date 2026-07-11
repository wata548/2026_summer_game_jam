using UnityEngine;

namespace Extension {
    public static class ExVector {
        public static Vector2 Mul(this Vector2Int pLhs, float pRhs) =>
            new(pLhs.x * pRhs, pLhs.y * pRhs);
    }
}