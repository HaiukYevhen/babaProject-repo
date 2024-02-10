
using UnityEngine;

public class Win : MonoBehaviour
{
    private GameObject winMenu;
    private WinManager winManagerScript;
    void Start()
    {
        winMenu = GameObject.Find("WinGameObject");
        winManagerScript = winMenu.GetComponent<WinManager>();
    }
    void OnCollisionEnter(Collision collision)
    {
        var commandTarget = collision.gameObject.GetComponent<CommandTarget>();
		if (commandTarget != null && commandTarget.HasTag("You"))
        {
            Debug.Log("win");
            winManagerScript.winMenu.SetActive(true);
            Time.timeScale = 0;
            return;
        }
        
    }
}
