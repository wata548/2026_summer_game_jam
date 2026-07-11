using UnityEngine;

namespace Movement {
    public interface IMovement {
        bool MoveFlip { get; set; } 
        Vector3 GetDirection();
    }
}