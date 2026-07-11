using DG.Tweening;
using Extension;
using Extension.Animation;
using Extension.Test;
using UnityEngine;

namespace TestExtension {
    public class Card: MonoBehaviour {
        private Tween anim = null;
        [TestMethod]
        public void Anim(int pLength = 5, bool pClockDirection = true, int pTurnCnt = 1) {
            SoundManager.Instance.Play("Sound/ShootDeal1");
            var radian = Random.Range(0, 1f) * 2 * Mathf.PI;
            var direction = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * pLength;
            anim?.Kill();
            anim = transform.SimpleCardMove(transform.position + direction, 0.4f, pClockDirection, pTurnCnt);
            anim.OnComplete(() => SoundManager.Instance.Play("Sound/SmallDeal1"));

        }

        [TestMethod]
        public void PlaySound(string pClip = "Sound/Deal1") {
            SoundManager.Instance.Play(pClip);
        }
    }
}