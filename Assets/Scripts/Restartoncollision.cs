using UnityEngine;

public class Restartoncollision : MonoBehaviour
{
    public GameoverController GameoverController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.Death();
        }
        
    }
}
