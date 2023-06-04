using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button Playbutton;
    public Button Exitbutton;
    //public string Level1;
    public GameObject LevelSelectionPopup;
    private void Awake()
    {
        Playbutton.onClick.AddListener(Play);
        Exitbutton.onClick.AddListener(Exit);
    }
    public void Play()
    {
        LevelSelectionPopup.SetActive(true);
        //SceneManager.LoadScene(Level1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
