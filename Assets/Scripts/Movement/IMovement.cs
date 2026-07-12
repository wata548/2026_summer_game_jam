using UnityEngine;

namespace Movement {
    public interface IMovement {
        bool MoveFlip { get; set; } 
        float Speed { get; } 
        float SpeedMultiplier { get; set; } 
        Vector3 GetDelta();
    }
}