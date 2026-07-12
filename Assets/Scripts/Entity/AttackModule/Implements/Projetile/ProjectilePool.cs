using Extension;
using Extension.ObjectPool;
using UnityEngine;

namespace Entity.AttackModule.Implements {
    public class ProjectilePool: MonoSingleton<ProjectilePool> {
        protected override bool IsNarrowSingleton => true;

        [SerializeField] private Projectile _prefab;
        public ObjPool<Projectile> Pool { get; private set; }

        private void Awake() {
            Pool = new(_prefab);
        } 
    }
}