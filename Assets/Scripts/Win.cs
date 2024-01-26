
using UnityEngine;

public class Win : MonoBehaviour
{
    private GameObject winMenu;
    void Start()
    {
        winMenu = GameObject.Find("WinMenu");
        winMenu.SetActive(false);
    }
    void OnTriggerEnter(Collider collider)
    {
        
        var commandTarget = collider.gameObject.GetComponent<CommandTarget>();
		if (commandTarget != null && commandTarget.HasTag("You"))
        {
            Debug.Log("win");
            winMenu.SetActive(true);
            Time.timeScale = 0;
            return;
        }
        
    }
}
