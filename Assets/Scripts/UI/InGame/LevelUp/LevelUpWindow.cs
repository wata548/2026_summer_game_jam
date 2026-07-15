using Card;
using Card.Data;
using System.Linq;
using Data;
using Data.Level;
using UnityEngine;
using Entity;
using Extension;
using UI.InGame.CardChoicing;

namespace UI.InGame.LevelUpWindow
{
    public class LevelUpWindow : MonoSingleton<LevelUpWindow> {
        protected override bool IsNarrowSingleton => true;
        [SerializeField] private GameObject LvPanel;
        [SerializeField] private CardChoiceUI[] cardChoices;
        [SerializeField] private RarityTable rarityTable;

        private CardDesc card;
        private void Start() {
            Player.Instance.Level.OnLevelUp += Show;
        }

        public void Show(Level pLevel) {
            Time.timeScale = 0f;
            for (int i = 0; i < 3; i++)
            {
                CreateCard(i);
                cardChoices[i].SetCardChoice(card);
            }
            LvPanel.SetActive(true);
        }

        private void CreateCard(int order)
        {
            Rarity rarity = rarityTable.GetRandomRarity();

            card = GetRarityRandomCard(rarity);

            if (card == null)
            {
                return;
            }
        }

        private CardDesc GetRarityRandomCard(Rarity rarity)
        {
            var ownedCards = Player.Instance.CardInventory.Cards;

            var cards = DataTables.Instance.CardDesc
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