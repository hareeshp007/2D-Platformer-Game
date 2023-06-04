using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverController : MonoBehaviour
{
    public Button Playbutton;
    public Button MainmenuButton;
    private void Awake()
    {
        Playbutton.onClick.AddListener(Restart);
        MainmenuButton.onClick.AddListener(Mainmenu);
    }
    public void PlayerDied()
    {
        PlayerPrefs.SetString("LastLevel", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        gameObject.SetActive(true);
    }
    private void Restart()
    {
        int currentscene=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene);
    }
    private void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
