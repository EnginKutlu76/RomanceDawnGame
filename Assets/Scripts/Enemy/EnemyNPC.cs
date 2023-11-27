using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNPC : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    Animator anim;
    public Transform target;

    public void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            anim.SetTrigger("Death");
            Destroy(gameObject, 1f);
        }
        Flip();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AtakZone"))
        {
            currentHealth -= 10;
            anim.SetTrigger("Hit");
        }
    }
    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 0f;
        }
        else
        {
            rotation.y = 180f;
        }
        transform.eulerAngles = rotation;
    }



}
