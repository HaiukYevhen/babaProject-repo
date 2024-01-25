using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject pausedMenu;
    public bool secondTime = false;
    void Start()
    {
        pausedMenu = GameObject.Find("PausedMenu");
        pausedMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
		{
            EscMenu();
		}
    }

    public void EscMenu()
    {
        if(secondTime == false)
        {
            pausedMenu.SetActive(true);
            secondTime = true;
            Time.timeScale = 0;
            return;
        }
        if(secondTime == true)
        {
            pausedMenu.SetActive(false);
            secondTime = false;
            Time.timeScale = 1;
            return;
        }
    }
}
