using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crewController : MonoBehaviour
{
    public float MovementDirection;
    public float Speed;
    /*************************/
    Rigidbody2D rb;
    Animator anim;
    public LayerMask groundLayer;
    /*************************/
    public bool SagaBakiyorMu = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        MovementDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(MovementDirection * Speed, rb.velocity.y);
        anim.SetFloat("runSpeed", Mathf.Abs(MovementDirection * Speed));
    }
}
