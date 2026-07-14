using Card;
using Card.Data;
using System.Linq;
using UnityEngine;
using Entity;
using UI.InGame.CardChoicing;

namespace UI.InGame.LevelUpWindow
{
    public class LevelUpWindow : MonoBehaviour
    {
        [SerializeField] private GameObject LvPanel;
        [SerializeField] private CardChoiceUI[] cardChoices;
        [SerializeField] private RarityTable rarityTable;

        private CardDescTable cardDescTable;
        private CardDesc card;
        private void Awake()
        {
            cardDescTable = new CardDescTable();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                Time.timeScale = 0f;
                for (int i = 0; i < 3; i++)
                {
                    CreateCard(i);
                    cardChoices[i].SetCardChoice(card);
                }
                LvPanel.SetActive(true);
                
            }
        }

        public void CreateCard(int order)
        {
            Rarity rarity = rarityTable.GetRandomRarity();

            card = GetRarityRandomCard(rarity);

            if (card == null)
            {
                return;
            }
        }

        public CardDesc GetRarityRandomCard(Rarity rarity)
        {
            var ownedCards = Player.Instance.CardInventory.Cards;

            var cards = cardDescTable
                .Query(card => card.Rarity == rarity)
                .Where(desc =>
                {
                    var ownedCard = ownedCards.FirstOrDefault(card => card.Id == desc.Number);
                    if (ownedCard == null) return true;
                    return ownedCard.LevelUpAble;
                }).ToList();

            if (cards.Count == 0)
                return null;

            int index = UnityEngine.Random.Range(0, cards.Count);

            return cards[index];
        }
    }
}