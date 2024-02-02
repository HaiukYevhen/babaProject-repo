
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
    void OnTriggerEnter(Collider collider)
    {
        
        var commandTarget = collider.gameObject.GetComponent<CommandTarget>();
		if (commandTarget != null && commandTarget.HasTag("You"))
        {
            Debug.Log("win");
            winManagerScript.winMenu.SetActive(true);
            Time.timeScale = 0;
            return;
        }
        
    }
}
