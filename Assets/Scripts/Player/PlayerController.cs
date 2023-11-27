using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float MovementDirection;
    public float Speed;
    public float JumpPower;
    private bool isGrounded;
    public float groundCheckRadius;
    public float attackRate;
    float nextAttack;
    public float maxHealth;
    public float currentHealth;
    /*************************/
    Rigidbody2D rb;
    Animator anim;
    public GameObject groundCheck;
    public GameObject deathPanel;
    public LayerMask groundLayer;
   // public GameObject panel;
    public Image can;
    /*************************/
    bool SagaBakiyorMu = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        can.fillAmount = currentHealth;
    }
    void Update()
    {
        CheckAnimations();
        Jump();
        CheckSurface();
        CheckRotation();
        if (Time.time > nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Atak1();
                nextAttack = Time.time + 1f / attackRate; 
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Bazooka();
                nextAttack = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Pistol();
                nextAttack = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Kane();
                nextAttack = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Fusen();
                nextAttack = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                Ulti();
                nextAttack = Time.time + 1f / attackRate;
            }


        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //panel.SetActive(true);
            //if (Input.GetKeyDown(KeyCode.Escape))
            //{
            //    panel.SetActive(false);
            //}
        }
    }
    private void FixedUpdate()
    {
        Movement();
    }
    /****EKLENTÝLER****/


    void CheckAnimations()
    {
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
    }
    void Movement()
    {
        MovementDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(MovementDirection * Speed, rb.velocity.y);
        anim.SetFloat("runSpeed",Mathf.Abs(MovementDirection * Speed));
    }
    void CheckRotation()
    {
        if (SagaBakiyorMu && MovementDirection < 0)
        {
            FlipFace();
        }
        else if (!SagaBakiyorMu && MovementDirection > 0)
        {
            FlipFace();
        }
    }
    void CheckSurface()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);
    }
    void FlipFace()
    {
        SagaBakiyorMu = !SagaBakiyorMu;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void Jump()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpPower);
            }
        } 
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(groundCheck.transform.position, groundCheckRadius);
    //}
    void Atak1()
    {
        anim.SetTrigger("Atak1");
    }
    void Bazooka()
    {
        anim.SetTrigger("Bazooka");
    }
    void Fusen()
    {
        anim.SetTrigger("Fusen");
    }
    void Kane()
    {
        anim.SetTrigger("Kane");
    }
    void Ulti()
    {
        anim.SetTrigger("Ulti");
    }
    void Pistol()
    {
        anim.SetTrigger("Pistol");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Atak"))
        {
            can.fillAmount -= 0.1f;
            anim.SetTrigger("Hit");
            currentHealth -= 10;
             anim.SetTrigger("Hit");
            if (currentHealth <= 0)
            {
                anim.SetTrigger("Lose");
                anim.SetTrigger("Death");
                deathPanel.SetActive(true);
                MovementDirection = 0;
                //Invoke("DurdurOyun", 1.5f);
            }  
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.collider.tag == "deniz")
            {
                anim.SetTrigger("Lose");
                deathPanel.SetActive(true);
                MovementDirection = 0;
            }
    }
    void DurdurOyun()
    {
        Time.timeScale = 0;
    }

}
