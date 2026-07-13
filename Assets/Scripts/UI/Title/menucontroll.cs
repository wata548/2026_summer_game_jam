using UnityEngine;
using UnityEngine.SceneManagement;

public class menucontroll : MonoBehaviour
{
    public GameObject settingsPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void onclickstartbutton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void onclicksettingbutton()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);

    }
    public void onclickquitbutton()
    {

        Application.Quit();
    }
}
