using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dovus2 : MonoBehaviour
{
    Animator anim;
    public GameObject bariyer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //zoro buna girince yok olucak savaþçý zoro çýkýcak sonrasýnda mihawkýn animasonu oynicak
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("crew"))
        {
            bariyer.SetActive(true);
            anim.enabled = true;
            //Destroy(gameObject, 7);
            Destroy(bariyer, 5);
            
        }
    }
}
