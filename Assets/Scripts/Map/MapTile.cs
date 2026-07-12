using System;
using Entity;
using Extension;
using Extension.ObjectPool;
using UnityEngine;

namespace Map {
    public class MapTile: ObjBase<MapTile> {
        public const float Size = 3; 
        public Vector2Int Pos { get; private set; }

        public void SetPos(Vector2Int pPos) {
            Pos = pPos;
            transform.position = Pos.Mul(Size);
        } 
        
        private void Update() {
            if (!IsExist) return;
            var term = Pos - Player.Instance.GridPos;
            if(Mathf.Abs(term.x) > MapManager.MapRadius || Mathf.Abs(term.y) > MapManager.MapRadius)
                Hide();
        }

        private void Awake() {
            transform.localScale = Vector3.one * Size;
        }
    }
}