using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject menu;
    public void Back()
    {
        gameObject.SetActive(false);
        menu.SetActive(true);
    }
}
