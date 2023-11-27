using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jango : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    Animator anim;

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
            //Destroy(gameObject, 1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AtakZone"))
        {
            currentHealth -= 20;
        }
        if (collision.CompareTag("Player"))
        {
            anim.enabled = true;
        }
    }
}
