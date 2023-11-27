using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class etHealth : MonoBehaviour
{
    PlayerController controller;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && controller.currentHealth < 100)
        {
            controller.currentHealth += 20;
            Destroy(gameObject);
        }
    }
}
