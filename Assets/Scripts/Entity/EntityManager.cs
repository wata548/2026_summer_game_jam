using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Entity;
using Extension;
using Extension.ObjectPool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Data.Entity {
	public class EntityManager: MonoSingleton<EntityManager> {
		protected override bool IsNarrowSingleton => true;
		[SerializeField] private DefaultEnemy _fish;
		[SerializeField] private DefaultEnemy _snake1;
		[SerializeField] private DefaultEnemy _snake2;
		[SerializeField] private DefaultEnemy _lion;
		[SerializeField] private DefaultEnemy _devil;
		[SerializeField] private List<int> _appear = new(){13, 2, 1, 0};
		[SerializeField] private float _minRange = 5;
		[SerializeField] private float _maxRange = 12;
		[SerializeField] private float _term = 0.45f;
		private int _wave = 1;
		private float _curTerm = 1;
		public ObjPool<DefaultEnemy> FishPool { get; private set; }
		public ObjPool<DefaultEnemy> Snake1Pool { get; private set; }
		public ObjPool<DefaultEnemy> Snake2Pool { get; private set; }
		public ObjPool<DefaultEnemy> LionPool { get; private set; }
		public ObjPool<DefaultEnemy> DevilPool { get; private set; }
		
		private DefaultEnemy GetMob() {
			var range = _appear.Sum();
			var random = Random.Range(0, range);
			var sum = 0;
			for (int i = 0; i < _appear.Count; i++) {
				sum += _appear[i];
				if (random < sum) {
					return (i switch {
						0 => FishPool,
						1 => Snake1Pool,
						2 => LionPool,
						3 => DevilPool
					}).Get();
				}
			}
			return FishPool.Get();
		}
		private void Generate() {
			var newMob = GetMob();
			var radian = Random.Range(0, 2 * Mathf.PI);
			var length = Random.Range(_minRange, _maxRange);
			var delta = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian));
			newMob.transform.position = Player.Instance.Pos + delta * length;
		}

		private void NextWave() {
			_wave++;
			_curTerm += _term;
			var amount = (_wave + 1) * (_wave + 1) / 4;
			for(int i = 0; i < amount; i++) this.Generate();
			StartCoroutine(Generate());

			IEnumerator Generate() {
				var term = new WaitForSeconds(_curTerm / amount);
				for (int i = 0; i < amount; i++) {
					yield return term;
					this.Generate();
				}
				NextWave();
			}
		}
		
		private void Awake() {
			Snake1Pool = new(_snake1);
			Snake2Pool = new(_snake2);
			LionPool = new(_lion);
			FishPool = new(_fish);
			DevilPool = new(_devil);
		}

		private void Start() {
			NextWave();
		}
	}
}