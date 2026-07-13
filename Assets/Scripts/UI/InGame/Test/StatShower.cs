using System;
using System.Text;
using Entity;
using Entity.AttackModule;
using TMPro;
using UnityEngine;

namespace UI.InGame.Test {
	[RequireComponent(typeof(TMP_Text))]
	public class StatShower: MonoBehaviour {

		private TMP_Text _context; 
		
		private void Awake() {
			_context = GetComponent<TMP_Text>();
		}

		private void Update() {
			var builder = new StringBuilder();
			var player = Player.Instance;
			builder.AppendLine($"Atk: {player.Attack.Power}");
			builder.AppendLine($"Atm: {player.Attack.PowerMultiplier}");
			builder.AppendLine($"Att: {(player.Attack as ICoolTimeAttack)!.CoolTime}");
			builder.AppendLine($"Atc: {(player.Attack as IMultipleAttack)!.AttackCnt}");
			builder.AppendLine($"Grd: {player.Guard}");
			builder.AppendLine($"Spd: {player.Movement.Speed}");
			builder.AppendLine($"Spm: {player.Movement.SpeedMultiplier}");
			builder.AppendLine($"Ddm: {player.DamageDownMultiplier}");
			builder.AppendLine($"Inv: {player.IsInvincible}");
			_context.text = builder.ToString();
		}
	}
}