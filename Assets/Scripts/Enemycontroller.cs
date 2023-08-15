using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    public float speed;
    public Transform groundDetection;
    private float distance=2f;
    public Animator animator;
    private bool ismovingRight=true;


    private void Update()
    {
        animator.SetFloat("speed", speed);
        transform.Translate(Vector2.right * speed *Time.deltaTime);
        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundinfo.collider == false)
        {
            if (ismovingRight)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
                ismovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                ismovingRight = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController PController=collision.gameObject.GetComponent<PlayerController>();
            PController.TakeDamage();
        }
    }

}
