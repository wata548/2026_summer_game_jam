using Entity;
using UnityEngine;

namespace Movement {
    public interface IMovement {
        bool MoveFlip { get; set; } 
        bool MoveLock { get; set; } 
        float Speed { get; } 
        float SpeedMultiplier { get; set; } 
        Vector3 GetDelta(IEntity pTarget);
    }
}