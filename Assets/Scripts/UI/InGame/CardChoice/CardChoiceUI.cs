using Card;
using Card.Data;
using Entity;
using System.Linq;
using TMPro;
using UI.InGame;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.CardChoicing
{
    public class CardChoiceUI : MonoBehaviour
    {
        private CardDescTable _cardTable;
        private CardBase _cardBase;
        [SerializeField] private Image _image;
        [SerializeField] private Image _rarityimage;
        [SerializeField] private GameObject _lvstarimage;
        [SerializeField] private TMP_Text _cardRarity;
        [SerializeField] private TMP_Text _cardName;
        [SerializeField] private TMP_Text _cardExplain;

        private CardDesc ClickCard;

        public void Awake()
        {
            _cardTable = new CardDescTable();
        }
        public void SetCardChoice(CardDesc card)
        {
            ClickCard = card;
            _image.sprite = DataImage.Get(card.Number);
            Debug.Log(card.Number);
            _cardName.text = card.Name;
            _cardExplain.text = card.Desc;

            var ownedCard = Player.Instance.CardInventory.Cards.FirstOrDefault(c => c.Id == card.Number);

            if (ownedCard != null && ownedCard.Level == 1)
            {
                _lvstarimage.SetActive(true);
            }

            switch (card.Rarity)
            {
                case Rarity.Common:
                    ColorUtility.TryParseHtmlString("#ddbd4f", out var common);
                    _rarityimage.color = common;
                    _cardRarity.text = "Common";
                    break;

                case Rarity.Rare:
                    ColorUtility.TryParseHtmlString("#b4d5f2", out var rare);
                    _rarityimage.color = rare;
                    _cardRarity.text = "Rare";

                    break;

                case Rarity.Epic:
                    ColorUtility.TryParseHtmlString("#cc4aff", out var epic);
                    _rarityimage.color = epic;
                    _cardRarity.text = "Epic";
                    break;
                case Rarity.Legendary:
                    ColorUtility.TryParseHtmlString("#ddbd4f", out var legendary);
                    _rarityimage.color = legendary;
                    _cardRarity.text = "Legendary";
                    break;
                case Rarity.Arcana:
                    ColorUtility.TryParseHtmlString("#ddbd4f", out var arcana);
                    _rarityimage.color = arcana;
                    _cardRarity.text = "Arcana";
                    break;
            }
        }

        public void OnClickCardChoice()
        {
            Player.Instance.CardInventory.Get(Player.Instance, ClickCard.Number);

            Time.timeScale = 1f;
            gameObject.transform.parent.gameObject.SetActive(false);
        }

    }
}

