using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button btnPlay;
    public GameObject AudioPanel;
    private bool activePanel = false;
    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(() => Play());
    }

    void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void ActivePanel()
    {
        if (activePanel == false)
        {
            activePanel = true;
            AudioPanel.SetActive(true);
        }
        else
        {
            activePanel = false;
            AudioPanel.SetActive(false);
        }
    }
}
