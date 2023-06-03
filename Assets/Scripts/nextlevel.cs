using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class nextlevel : MonoBehaviour
{
    public int lastlevelnumber;
    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            
            Debug.Log("finish collider has been triggered");
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            Debug.Log(nextSceneIndex);
            // Check if the next level index is within the valid range
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
}
