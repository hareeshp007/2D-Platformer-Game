using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class nextlevel : MonoBehaviour
{
    public GameWonController woncontroller;
    public int lastlevelnumber;
    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            SoundManager.Instance.PlayLevel(Sounds.LevelFinished);
            LevelManager.Instance.MarkCurrentLevelCompleted();
            woncontroller.showWonScreen();
        }
    }
    public void Loadnextscene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= 0 && nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogError("Invalid next level index!");
            if (nextSceneIndex >= (lastlevelnumber))
            {
                SceneManager.LoadScene(0);
            }

        }
    }
}
