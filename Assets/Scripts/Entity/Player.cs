using Extension;
using Map;
using UnityEngine;

namespace Entity {
    public class Player: MonoSingleton<Player>, IEntity {
       //==================================================||Singleton Option 
        protected override bool IsNarrowSingleton => true;
        protected override bool AllowAutoGen => false;

       //==================================================||Properties 
       public int Hp { get; private set; } = 100;

        public Vector2Int Pos => new(
            Mathf.RoundToInt(transform.position.x / MapTile.Size),
            Mathf.RoundToInt(transform.position.y / MapTile.Size)
        );
            
        //==================================================||Methods 
        public void GetDamage(int pAmount) {
            throw new System.NotImplementedException();
            
        }
    }
}