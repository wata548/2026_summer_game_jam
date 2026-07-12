using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Movement {
    public class KeyboardMovement: IMovement {
        
       //==================================================||Properties 
        public bool MoveFlip { get; set; }
        public float Speed { get;}
        public float SpeedMultiplier {
            get => _speedMultiplier;
            set => _speedMultiplier = Mathf.Max(value, 0);
        }
        
       //==================================================||Fields 
        private float _speedMultiplier = 1; 
        private readonly IReadOnlyDictionary<KeyCode, Vector3> _keyDirectionMatch = new Dictionary<KeyCode, Vector3>() {
            { KeyCode.W, Vector3.up },
            { KeyCode.S, Vector3.down },
            { KeyCode.A, Vector3.left },
            { KeyCode.D, Vector3.right },
        };

        //==================================================||Constructors 
        public KeyboardMovement(float pSpeed) => Speed = pSpeed;

        //==================================================||Methods 
        public Vector3 GetDelta() {
            var result = _keyDirectionMatch
                .Where(kvp => Input.GetKey(kvp.Key))
                .Aggregate(Vector3.zero, (current, kvp) => current + kvp.Value);
            var power = (MoveFlip ? -1 : 1) * Speed * Time.deltaTime;
            return result.normalized * power;
        }
    }
}