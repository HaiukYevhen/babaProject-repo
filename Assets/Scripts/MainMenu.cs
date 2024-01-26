using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nameScene;
    public void PlayGame()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayLevl()
    {
        SceneManager.LoadScene(nameScene);
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
