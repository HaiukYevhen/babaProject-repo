using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PausedMenu : MonoBehaviour
{
    private Esc escScript;
    public void CountinueGame()
    {
        escScript = GameObject.Find("Esc").GetComponent<Esc>();
        escScript.EscMenu();  
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
