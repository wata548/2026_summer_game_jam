using UnityEngine;

namespace Movement {
	public class TracePlayer: IMovement {
		public bool MoveFlip { get; set; }
		public float Speed { get; private set; }
		public float SpeedMultiplier { get; set; } = 1;
		public Vector3 GetDelta() {
			throw new System.NotImplementedException();
		}
	}
}