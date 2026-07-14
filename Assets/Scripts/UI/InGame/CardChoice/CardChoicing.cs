using Card;
using Card.Data;
using TMPro;
using UI.InGame;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.CardChoicing
{
    public class CardChoicing : MonoBehaviour
    {
        private CardDescTable _cardTable;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _cardRarity;
        [SerializeField] private TMP_Text _cardName;
        [SerializeField] private TMP_Text _cardExplain;

        public void Init()
        {
            _cardTable = new CardDescTable();
        }
        private void SetCardChoice(int pld)
        {
            CardDesc card = _cardTable.Get(pld);
            _image.sprite = DataImage.Get(pld);
            _cardName.text = card.Name;
            _cardName.text = card.Desc;
        }



    }
}

