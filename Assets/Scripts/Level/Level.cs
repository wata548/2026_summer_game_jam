using System;

namespace Data.Level {
	public class Level {
		public event Action<Level> OnLevelUp;
		public event Action<Level> OnGetExp;
		
		public int CurLevel { get; private set; } = 1; 
		public int NeedExp { get; private set; } = 30; 
		public int Exp { get; private set; } = 0;
		public int Score => _usedExp + Exp;
		private int _usedExp = 0; 

		private void CalcNextExp() {
			if (CurLevel >= 5)
				NeedExp += 20;
			else
				NeedExp += 10;
		}

		public void GetExp(int pAmount) {
			Exp += pAmount;
			while (true) {
				if (NeedExp <= Exp) {
					Exp -= NeedExp;
					CurLevel++;
					_usedExp += NeedExp;
					CalcNextExp();
					OnLevelUp?.Invoke(this);
					continue;
				}

				OnGetExp?.Invoke(this);
				break;
			}
		}
	}
}