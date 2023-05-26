using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;

    public bool Onground;

    private void Update()
    {
        bool cntrl = Input.GetKey(KeyCode.LeftControl);
        bool jump = Input.GetKey(KeyCode.Space);
        Vector3 scale = transform.localScale;
        Vector3 pos=transform.position;
        //animator.SetFloat("vertical",vert);  
        float Hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        PlayerMovementAnimation(scale, Hori, vert, cntrl, jump);
        PlayerMovement(pos, Hori, vert);
    }

    private void PlayerMovement(Vector3 pos, float Hori, float vert)
    {
        pos.x += Hori * speed * Time.deltaTime;
        transform.position = pos;
    }

    private void PlayerMovementAnimation(Vector3 scale, float Hori, float vert,bool cntrl,bool jump)
    {
        animator.SetBool("Iscrouch", cntrl);
        animator.SetFloat("speed", Mathf.Abs(Hori));
        if (jump && Onground)
        {
            animator.SetTrigger("Isjumping");
        }
        if (Hori < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (Hori > 0)
        {
            scale.x = 1 * Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            Onground = true;
        }
        else {
            Onground = false;
        }
        Debug.Log("collision detected" +collision.gameObject);
    }
}
