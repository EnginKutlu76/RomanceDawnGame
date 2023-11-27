using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AslanController : MonoBehaviour
{
    Animator anim;

    public Transform target;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

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
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Eðer oyuncu bu alana girdiyse atak animasyonunu baþlat
            anim.SetTrigger("Atak"); // "Attack" animasyonunu baþlat
        }
    }
}
