using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restartoncollision : MonoBehaviour
{
    public GameoverController GameoverController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            GameoverController.PlayerDied();

        }
        
    }
    public void RestartwithDelay(float time)
    {
        Invoke("restart", time);
    }
    public void restart()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
        Debug.Log("restart current level");
    }
}
