using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public GameObject winMenu;
    void Start()
    {
        winMenu = GameObject.Find("WinMenu");
        winMenu.SetActive(false);
    }
}
