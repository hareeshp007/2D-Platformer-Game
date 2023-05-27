using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed,jumppower;
    private Rigidbody2D rb2d;
    public bool Onground;

    public Transform feetpos;
    public float checkRadius;
    public LayerMask Ground;
    
    private void Awake()
    {
        rb2d=GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Onground=Physics2D.OverlapCircle(feetpos.position,checkRadius,Ground);
        animator.SetBool("OnGround", Onground);
        bool cntrl = Input.GetKey(KeyCode.LeftControl);
        bool jump = Input.GetKey(KeyCode.Space);
        Vector3 scale = transform.localScale;
        Vector3 pos=transform.position; 
        float Hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        PlayerMovementAnimation( Hori, vert, cntrl, jump);
        PlayerMovement(pos, Hori,vert, jump, scale);
    }

    private void PlayerMovement(Vector3 pos, float Hori, float vert, bool jump, Vector3 scale)
    {

        pos.x += Hori * speed * Time.deltaTime;
        transform.position = pos;
        if (vert>0 && Onground)
        {
            Debug.Log(jump + "+ " + Onground);
            animator.SetTrigger("Isjumping");
            rb2d.velocity = Vector2.up * jumppower;
            //rb2d.AddForce(new Vector2(0f, jumppower), ForceMode2D.Impulse);
            Onground = false;
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

    private void PlayerMovementAnimation( float Hori, float vert,bool cntrl,bool jump)
    {
        
        if (Onground) {
            animator.SetBool("Iscrouch", cntrl);
            animator.SetFloat("speed", Mathf.Abs(Hori));    
        }
        
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            //Onground = true;
        }
        
        Debug.Log("collision detected" +collision.gameObject.tag);
    }
}
