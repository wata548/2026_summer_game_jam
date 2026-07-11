using System;
using Entity;
using Extension;
using Extension.ObjectPool;
using UnityEngine;

namespace Map {
    public class MapTile: ObjBase<MapTile> {
        public const float Size = 8; 
        public Vector2Int Pos { get; private set; }

        public void SetPos(Vector2Int pPos) {
            Pos = pPos;
            transform.position = Pos.Mul(Size);
        } 
        
        private void Update() {
            if (!IsExist) return;
            var term = Pos - Player.Instance.Pos;
            if(Mathf.Abs(term.x) > 1 || Mathf.Abs(term.y) > 1)
                Hide();
        }

        private void Awake() {
            transform.localScale = Vector3.one * Size;
        }
    }
}