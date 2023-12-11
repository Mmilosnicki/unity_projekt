using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpKing : MonoBehaviour
{
    public float speed = 6f;
    private float moveInput;
    public float jumpPower = 12.5f;
    private Rigidbody2D rb;
    public Animator animator;
    public BananasManager bananas;
    public WinningGame winningGameScreen;
    public PauseMenuScreen pauseMenu;

    public AudioSource BGMusic;
    public AudioSource jumpSFX;
    public AudioSource collectSFX;
    public AudioSource WinSFX;

    private bool isSpaceHeld = false;
    private bool hasCollided = false;

    public bool isGrounded;
    public Transform groundCheck;
    const float groundedRadius = .2f;
    public LayerMask whatIsGround;

    public float jumpTimeCounter;
    public bool canJump;
    private bool facingRight = true;
    
    void Start()
    {
        BGMusic.Play();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.pausedScreen();
            BGMusic.Pause();
            Time.timeScale = 0f;
        }

        moveInput = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (isSpaceHeld == false)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            if (moveInput > 0 && facingRight == false)
            {
                Flip();
            }
            else if (moveInput < 0 && facingRight)
            {
                Flip();
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
            jumpTimeCounter = 0.5f;
            isSpaceHeld = true; 
        }

        if (Input.GetKey(KeyCode.Space) && canJump == true)
        {
            jumpTimeCounter += Time.deltaTime;

            if (jumpTimeCounter >= 1.5f)
            {
                isSpaceHeld = false; 
                if (moveInput > 0)
                {
                    jumpSFX.Play();
                    rb.velocity = new Vector2(1, jumpPower * jumpTimeCounter);
                }
                else if (moveInput < 0)
                {
                    jumpSFX.Play();
                    rb.velocity = new Vector2(-1, jumpPower * jumpTimeCounter);
                }
                else
                {
                    jumpSFX.Play();
                    rb.velocity = new Vector2(rb.velocity.x, jumpPower * jumpTimeCounter);
                }

                jumpTimeCounter = 0f;
                canJump = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && isSpaceHeld == true)
        {
            isSpaceHeld = false; 
            if (moveInput > 0)
            {
                jumpSFX.Play();
                rb.velocity = new Vector2(1, jumpPower * jumpTimeCounter);
            }
            else if (moveInput < 0)
            {
                jumpSFX.Play();
                rb.velocity = new Vector2(-1, jumpPower * jumpTimeCounter);
            }
            else
            {
                jumpSFX.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpPower * jumpTimeCounter);
            }

            jumpTimeCounter = 0f;
            canJump = false;
        }    
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasCollided == false)
        {
            hasCollided = true;

            if (other.gameObject.CompareTag("Banana"))
            {
                Destroy(other.gameObject);
                bananas.bananasCount++;
                collectSFX.Play();
            }

            else if (other.gameObject.CompareTag("BigBanana"))
            {
                Destroy(other.gameObject);
                gameObject.SetActive(false);
                winningGameScreen.WinningScreen();  
                Time.timeScale = 0f;
            }

            Invoke("ResetCollisionFlag", 1f);
        }       
    }

    void ResetCollisionFlag()
    {
        hasCollided = false;
    }
}