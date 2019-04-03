using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2DPlatform : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public GameObject projectile;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;

    public Animator anim;
    private bool IsSwap;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed * Time.deltaTime, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * JumpForce * Time.deltaTime;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * JumpForce * Time.deltaTime;
        }

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0) && IsSwap == true)
            {
                Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            }
            timeBtwShots = startTimeBtwShots;
        } else {
            timeBtwShots -= Time.deltaTime;
        }

        anim.SetBool("IsSwap", IsSwap);
        if(Input.GetKeyDown(KeyCode.F)){
            IsSwap = !IsSwap;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        /*Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;*/
        transform.Rotate(0f,180f,0f);
    }
}
