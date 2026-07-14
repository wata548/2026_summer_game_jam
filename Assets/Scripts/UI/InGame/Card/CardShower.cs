using Card;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.Card
{
    public class CardShower : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Image _cooldownimage;
        [SerializeField] private TMP_Text _coolTimeText;
        [SerializeField] private GameObject _coolTimeRoot;
        [SerializeField] private Image coolTimeFill;
        [SerializeField] private GameObject _Lv1;
        [SerializeField] private GameObject _Lv2;
        
        private CardBase _card;
        
        public void SetCard(CardBase card)
        {
            _card = card;
            _image.sprite = DataImage.Get(card.Id);
            _cooldownimage.sprite = DataImage.Get(card.Id);
            CheckCardLevel(card.Level);
        }

        private void CheckCardLevel(int pLevel) {
            _Lv1.SetActive(pLevel >= 1);
            _Lv2.SetActive(pLevel >= 2);
        }
        private void UpdateCoolTime(CoolTimeCard card)
        {
            if (card.InSkill) {
                _coolTimeRoot.SetActive(false);
                return;
            }

            _coolTimeRoot.SetActive(true);
            float max = card.CoolTime[card.Level];
            float remain = max - card.CurTime;
            coolTimeFill.fillAmount = Mathf.Clamp01(remain / max);

            coolTimeFill.fillAmount = remain / max;
            _coolTimeText.text = Mathf.CeilToInt(remain).ToString();
        }
        
        private void Update()
        {
            CheckCardLevel(_card.Level);
            if (_card is CoolTimeCard coolCard) {
                UpdateCoolTime(coolCard);
                return;
            }
            _coolTimeRoot.SetActive(false);
        }
    }
}