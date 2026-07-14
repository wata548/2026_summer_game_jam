using Card;
using Entity;
using System.Collections;
using TestExtension;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.Card
{
    public class CardShower : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _coolTimeText;
        [SerializeField] private GameObject _coolTimeRoot;
        [SerializeField] private Image coolTimeFill;
        private CardBase _card;

        [SerializeField] private GameObject _Lv1;
        [SerializeField] private GameObject _Lv2;

        public void Start()
        {
            _card = new Card1009();
            SetCard(_card);
        }
        public void SetCard(CardBase card)
        {
            _card = card;
            _image.sprite = DataImage.Get(card.Id);
            SetCardLevel(card.Level);
        }

        public void SetCardLevel(int Lv)
        {
            switch (Lv)
            {
                case 0:
                    break;
                case 1:
                    _Lv1.SetActive(true);
                    break;
                case 2:
                    _Lv1.SetActive(true);
                    _Lv2.SetActive(true);
                    break;
            }
        }
        private void Update()
        {
            if (_card is not CoolTimeCard coolCard)
            {
                _coolTimeRoot.SetActive(false);
                return;
            }
            coolCard.Update(Player.Instance);
            UpdateCoolTime(coolCard);
        }
        public void UpdateCoolTime(CoolTimeCard card)
        {
            if (card.InSkill)
            {
                _coolTimeRoot.SetActive(false);
                return;
            }

            _coolTimeRoot.SetActive(true);

            float max = card.CoolTime[card.Level];
            float remain = max - card.CurTime;

            coolTimeFill.fillAmount = remain / max;
            _coolTimeText.text = Mathf.CeilToInt(remain).ToString();
        }
    }
}