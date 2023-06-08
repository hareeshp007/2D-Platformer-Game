using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public scorecounter scorecounter;
    public healthcontroller healthcontroller;
    public GameoverController GameoverController;
    public int Keyscore=10;
    [SerializeField]
    private int health = 3;
    public int Totaljumps = 2;

    public Animator animator;
    public ParticleSystem FailEffect;
    public float speed,jumppower;
    private Rigidbody2D rb2d;
    public bool Onground;
    public bool isMoving;

    public Transform feetpos;
    public float checkRadius;
    public LayerMask Ground;
    
    private void Awake()
    {
        SoundManager.Instance.PlayLevel(Sounds.LevelStarted);
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        healthcontroller.Health(health);
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
        PlayerMovement(pos, Hori, vert, jump, scale);
        MovingAudio(Hori);
    }
    public void MovingAudio(float horizontal)
    {
        if (horizontal != 0 && Onground )
        {
            if (!isMoving)
            {
                SoundManager.Instance.Play(Sounds.PlayerMove);
                isMoving = true;
            }
        }
        else
        {
            if (isMoving)
            {
                SoundManager.Instance.StopEffect();
                isMoving = false;
            }
        }
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
            Onground = false;
        }
        if(!Onground && Totaljumps > 0 && jump)
        {
            Debug.Log("Double Jump");
            rb2d.velocity = Vector2.up * jumppower;
            Totaljumps -= 1;
        }
        if (Onground) Totaljumps = 2;
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

    public void Collect()
    {
        SoundManager.Instance.Play(Sounds.collect);
        scorecounter.IncreaseScore(Keyscore);
    }

    public void Death()
    {
        rb2d.gravityScale = 0f;
        FailEffect.Play();
        animator.SetBool("isAlive", false);
        GameoverController.PlayerDied();
        SoundManager.Instance.Play(Sounds.PlayerDied);
        this.enabled = false;
    }
    public void TakeDamage()
    {
        SoundManager.Instance.Play(Sounds.PlayerHurt);
        health-=1;
        healthcontroller.Health(health);
        animator.SetTrigger("ishurt");
        if(health <= 0)
        {
            Death();
        }
    }
    public void LevelComplete()
    {
        int stopMoving=0;
        animator.SetFloat("speed", stopMoving);
        this.enabled = false;    
    }
}
