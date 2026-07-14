using Card;
using Card.Data;
using System;
using UnityEngine;

namespace UI.InGame.LevelUpWindow {
	public class LevelUpWindow: MonoBehaviour {
        [SerializeField] private GameObject LvPanel;
        [SerializeField] private GameObject[] CardChoices = { };

        [SerializeField] private RarityTable rarityTable;
        private CardDescTable cardDescTable;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Time.timeScale = 0f;
                LvPanel.SetActive(true);
                CreateCard();

            }
        }
        
        public void CreateCard()
        {
            Rarity rarity = rarityTable.GetRandomRarity();

            Debug.Log(rarity);
        }
    }
}