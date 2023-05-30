using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restartoncollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(CurrentSceneIndex);
            Debug.Log("restart current level");

        }
        
    }
}
