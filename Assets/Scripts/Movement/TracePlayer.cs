using Entity;
using UnityEngine;

namespace Movement {
	public class TracePlayer: IMovement {
		public bool MoveFlip { get; set; }
		public bool MoveLock { get; set; }
		public float Speed { get; private set; }
		public float SpeedMultiplier { get; set; } = 1;
		private float _traceRange;

		public TracePlayer(float pSpeed, float pTraceRange) {
			Speed = pSpeed;
			_traceRange = pTraceRange;
		}
		
		public Vector3 GetDelta(IEntity pTarget) {
			if (MoveLock) return Vector3.zero;
			var delta = Player.Instance.Pos - pTarget.Pos;
			var mag = delta.magnitude;
			if (mag < _traceRange) return Vector3.zero;
			return delta.normalized * Speed;
		}
	}
}