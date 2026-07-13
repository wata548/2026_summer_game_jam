using Entity;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HPbar : MonoBehaviour
{
    [SerializeField] private Image _fill;
    [SerializeField] private TMP_Text _context;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Update() {

        _fill.fillAmount = Player.Instance.Hp / Player.Instance.MaxHp;
    }
}
