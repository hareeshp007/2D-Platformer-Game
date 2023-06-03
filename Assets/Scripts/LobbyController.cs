using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button Playbutton;
    public Button Exitbutton;
    public string Level1;
    private void Awake()
    {
        Playbutton.onClick.AddListener(Play);
        Exitbutton.onClick.AddListener(Exit);
    }
    public void Play()
    {
        SceneManager.LoadScene(Level1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
