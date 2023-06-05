using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWonController : MonoBehaviour
{
    public Button Restartbutton;
    public Button MainmenuButton;
    public Button NextLevelButton;
    [SerializeField]
    private int lastlevelnumber=4;

    private void Awake()
    {
        int currentsceneIndex = SceneManager.GetActiveScene().buildIndex;
        Restartbutton.onClick.AddListener(Restart);
        MainmenuButton.onClick.AddListener(Mainmenu);
        NextLevelButton.onClick.AddListener(Nextlevel);
    }
    public void showWonScreen()
    {
        gameObject.SetActive(true);
    }
    private void Restart()
    {
        int currentsceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneIndex);
    }
    private void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }
    private void Nextlevel()
    {
        int currentsceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentsceneIndex+1;
        if (nextSceneIndex >= 0 && nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogError("Invalid next level index!");
            if (nextSceneIndex >= (lastlevelnumber))
            {
                Debug.Log("You Won");
                Debug.Log("Lobby Return");

                SceneManager.LoadScene(0);
            }

        }
        
    }
}
