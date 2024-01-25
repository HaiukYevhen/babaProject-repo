using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PausedMenu : MonoBehaviour
{
    public Esc escScript;
    private GameObject pausedMenu;
    public void CountinueGame()
    {
        pausedMenu = GameObject.Find("PausedMenu");
        escScript = GetComponent<Esc>();
        // escScript.EscMenu();
        
        // escScript.secondTime = false;
        pausedMenu.SetActive(false);
        
        Time.timeScale = 1;
        return;
        // Application.Quit();
        
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
