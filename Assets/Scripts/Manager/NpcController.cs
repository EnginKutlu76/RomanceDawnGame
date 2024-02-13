using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public string[] dialog;
    public string nameOfNpc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogSystems.instance.AddDialog(dialog, nameOfNpc);
        }
    }
}
