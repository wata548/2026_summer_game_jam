using System;
using Extension.ObjectPool;
using UnityEngine;

namespace Entity.AttackModule.Implements {
    public class Projectile: ObjBase<Projectile> {
        private const float LimitSqrDistance = 20 * 20;
        private IEntity _owner;
        private float _power;
        private Vector3 _velocity;  
        
        public void Init(IEntity pOwner, float pSpeed, float pPower, float pRadian) {
            _owner = pOwner;
            _power = pPower;
            _velocity = new Vector3(Mathf.Cos(pRadian), Mathf.Sin(pRadian)) * pSpeed;
            transform.rotation = Quaternion.Euler(0, 0, pRadian * Mathf.Rad2Deg);
            transform.position = pOwner.Pos;
        }

        private void Update() {
            if (!IsExist) return;
            transform.position += _velocity * Time.deltaTime;
            if((_owner.Pos - transform.position).sqrMagnitude >= LimitSqrDistance)
                Hide();
        }
    }
}