using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerForDestruction : MonoBehaviour
{
    public float timeCount = 5f;
    float elapsedTime = 0f;
    CommandTarget commandTarget;
    private CodeManagerController codeManagerController;
    void Start()
    {
        codeManagerController = GameObject.Find("CodeManager").GetComponent<CodeManagerController>();
        commandTarget = gameObject.GetComponent<CommandTarget>();
    }
    // Start is called before the first frame update
    void Update()
    {
        StartCoroutine( CountDown());
    }
    public IEnumerator CountDown() 
    {

        while (elapsedTime <= timeCount)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(elapsedTime);
        }
        if (commandTarget != null && commandTarget.HasTag("RPG"))
        {
            Debug.Log("RPG DEstroy");
            codeManagerController?.DestroyCommandTarget(commandTarget);
        }
        Destroy(gameObject);

    }

}
