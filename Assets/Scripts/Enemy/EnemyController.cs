using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    public Image can;
    public float maxHealth;
    public float currentHealth;
    Animator anim;
    private bool isPlayingFirstAnimation;
    public GameObject gecis;
    public GameObject sonSahne;
    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        can.fillAmount = currentHealth;
        isPlayingFirstAnimation = true;
        StartCoroutine(SwitchAnimations());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AtakZone"))
        {
            can.fillAmount-= 0.1f;
            currentHealth -= 10;
            anim.SetTrigger("Hit");
            if (currentHealth <= 0)
            {
                anim.SetTrigger("Death");
                gecis.SetActive(true);
                Destroy(gameObject, 1f);
                sonSahne.SetActive(false);
            }
        }
    }
    IEnumerator SwitchAnimations()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            if (isPlayingFirstAnimation)
            {
                anim.SetTrigger("tp1");
            }
            else
            {
                anim.SetTrigger("tp2");
            }
            isPlayingFirstAnimation = !isPlayingFirstAnimation;
        }
    }
}
