using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Cinemachine;
public class CamerFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] players ;
    public int i = 0 ;
     private GameObject camObj;
     private Player playerScript;
    private CinemachineVirtualCamera virtualCamera;
    void Start()
    {
        camObj = GameObject.Find("VirtualCamera1");

        players = GameObject.FindGameObjectsWithTag("PlayerPrefab");
        // playerScript = players[0].GetComponent<Player>();
        Debug.Log(players.Count());
    }

    public void CameraPosition()
    {
        if(Input.GetKeyDown("space"))
        {
            i++;
           
            // if(i < players.Count()-1)
            // {
                
            // }
            if(i == players.Count())
            {
                i = 0;
            }
            virtualCamera =  camObj.GetComponent<CinemachineVirtualCamera>();
            virtualCamera.transform.position = players[i].transform.position;
            Debug.Log("i = "+i);
            virtualCamera.Follow = players[i].GetComponent<Transform>();
        }
            
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CameraPosition();

    }
}
