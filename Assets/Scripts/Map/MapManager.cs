using System;
using Entity;
using Extension.ObjectPool;
using UnityEngine;

namespace Map {
    public class MapManager: MonoBehaviour {
        
        //==================================================||Fields 
        [SerializeField] private MapTile _defaultTile;
        [SerializeField] private Sprite[] _tileSprites;
        private ObjPool<MapTile> _tilePool;
        private Vector2Int _lastPlayerPos;
        public const int MapRadius = 1;
        private const int MapLength = MapRadius * 2 + 1;

       //==================================================||Methods
       private void UpdateTiles(Vector2Int pPos) {
           _lastPlayerPos = pPos;
           var exist = new bool[MapLength * MapLength];
           foreach (var element in _tilePool.Elements) {
               var delta = element.Pos - _lastPlayerPos;
               if(delta.x is < -MapRadius or > MapRadius || delta.y is < -MapRadius or > MapRadius)
                   continue;
               exist[(delta.y + MapRadius) * MapLength + delta.x + MapRadius] = true;
           }

           for (int y = 0; y < MapLength; y++) {
               for (int x = 0; x < MapLength; x++) {
                   if(exist[y * MapLength + x])
                       continue;
                   var pos = new Vector2Int(_lastPlayerPos.x + x - MapRadius, _lastPlayerPos.y + y - MapRadius);
                   var spriteIdx = Mathf.Abs(pos.GetHashCode()) % _tileSprites.Length;
                   _tilePool.Get().SetPos(pos, _tileSprites[spriteIdx]);
               }
           }
       }

       //==================================================||Unity 
        private void Awake() {
            _tilePool = new(_defaultTile);
            UpdateTiles(Vector2Int.zero);
        }

        private void LateUpdate() {
            var pos = Player.Instance.GridPos;
            if(pos != _lastPlayerPos)
                UpdateTiles(pos);
        }
    }
}