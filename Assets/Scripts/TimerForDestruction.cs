using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerForDestruction : MonoBehaviour
{
    public float timeCount = 5f;
    float elapsedTime = 0f;
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
        Destroy(gameObject);
    }

}
