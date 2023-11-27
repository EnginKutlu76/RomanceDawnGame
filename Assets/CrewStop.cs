using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewStop : MonoBehaviour
{
    BoxCollider2D bx2d;
    crewController crew;
  
    void Start()
    {
        crew = GetComponent<crewController>();
        bx2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dur"))
        {
            crew.Speed = 0;
            bx2d.enabled = false;
            crew.MovementDirection = 0;
            crew.SagaBakiyorMu = true;
        }
        if (collision.CompareTag("animasyon"))
        {
            gameObject.SetActive(false);
        }

    }
}
