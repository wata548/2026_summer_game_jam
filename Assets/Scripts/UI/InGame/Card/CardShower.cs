using Card;
using TMPro;
using UI.InGame.Info;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.Card
{
    public class CardShower : DataGenerator
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

        public override string Name {
            get {
                if (_card == null) return "";
                return $"{_card.Desc.Name} + {_card.Level + 1}";
            }
        }

        public override string Context {
            get {
                if (_card == null) return "";
                return _card.Level switch {
                    0 => _card.Desc.Desc,
                    1 => _card.Desc.Level1Desc,
                    2 => _card.Desc.Level2Desc
                };
            }
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