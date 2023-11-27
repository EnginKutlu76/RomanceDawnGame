using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    Animator anim;
    public Rigidbody2D rb;
    public Transform player;
    private bool lookingRight = false;

    [Header("Attack")]
    public Transform attack;
    public float attackRadius;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

   
    void Update()
    {
        LookPlayer();
        float DistanceToPlayer = Vector2.Distance(transform.position, player.position);
        anim.SetFloat("Distance", DistanceToPlayer);
    }
    public void LookPlayer()
    {
        if (player.position.x > transform.position.x && !lookingRight || player.position.x < transform.position.x && lookingRight)
        {
            //lookingRight = !lookingRight;
            //transform.position = new Vector3(0, transform.position.y + 180, 0);
            FlipFace();
        }
    }

    //public void Attack()
    //{
    //    Collider2D[] objeler = 
    //}

    void FlipFace()
    {
        lookingRight = !lookingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
