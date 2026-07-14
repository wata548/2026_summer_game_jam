using Card;
using UI.InGame;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.CardChoicing
{
    public class NewMonoBehaviourScript : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private string _cardRarity;
        [SerializeField] private Image _cardName;
        [SerializeField] private Image _cardExplain;

        private void SetCardChoice(int pld)
        {
            _image.sprite = DataImage.Get(pld);
        }



    }
}

