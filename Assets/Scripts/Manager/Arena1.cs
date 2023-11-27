using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena1 : MonoBehaviour
{
    public GameObject giris;
    public GameObject bossCan;
    public GameObject boss;
    BoxCollider2D boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boss.SetActive(true);
            giris.SetActive(true);
            bossCan.SetActive(true);
            gameObject.SetActive(false);
            boxCollider.isTrigger = false;
        }
    }
}
