using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverController : MonoBehaviour
{
    public Button Playbutton;
    private void Awake()
    {
        Playbutton.onClick.AddListener(Restart);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    private void Restart()
    {
        int currentscene=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene);
    }
}
