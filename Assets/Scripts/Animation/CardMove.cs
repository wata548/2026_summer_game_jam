using DG.Tweening;
using UnityEngine;

namespace Extension.Animation {
    public static class CardMove {
        public static Tween SimpleCardMove(this Transform pTransform, Vector3 pTargetPos, float pDuration, bool pClockDirection = true, int pAmount = 1, Ease pEase = Ease.OutSine) {
            var rotation = pTransform.rotation.eulerAngles;
            rotation.z = Mathf.Round(rotation.z / 180) * 180;
            pTransform.transform.eulerAngles = rotation;
            var endValue = rotation.z + (pClockDirection ? -180 : 180) * pAmount;
            return DOTween.Sequence()
                .Append(pTransform.DOMove(pTargetPos, pDuration).SetEase(pEase))
                .Join(DOTween.To(() => rotation.z, x => {
                    rotation.z = x;
                    pTransform.rotation = Quaternion.Euler(rotation);
                }, endValue, pDuration));
        }
    }
}