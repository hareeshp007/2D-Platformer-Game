using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class nextlevel : MonoBehaviour
{
    public GameWonController woncontroller;
    public int lastlevelnumber;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            SoundManager.Instance.PlayLevel(Sounds.LevelFinished);
            LevelManager.Instance.MarkCurrentLevelCompleted();
            PlayerController playerController = (PlayerController)collision.gameObject.GetComponent<PlayerController>();
            playerController.LevelComplete();
            woncontroller.ShowWonScreen();
        }
    }
}
