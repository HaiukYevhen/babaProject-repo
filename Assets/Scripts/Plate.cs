using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public GameObject[] objects; // ????????????? gameObject -> objects
    [SerializeField] int countObject = 0;
    public float[] upNumber;
    private Vector3[] initialPositions; // ??????? ????? ?????????? ???????

    void Start()
    {
        // ?????'???????? ????????? ??????? ??'?????
        initialPositions = new Vector3[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null)
                initialPositions[i] = objects[i].transform.position;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("OnTriggerEnter: " + collider);
        countObject++;
        if (countObject == 1)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] != null)
                {
                    objects[i].transform.position = new Vector3(
                        objects[i].transform.position.x,
                        initialPositions[i].y + upNumber[i], // ?????????? ???????? ?????????? ???????
                        objects[i].transform.position.z
                    );
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        Debug.Log("OnTriggerExit: " + collider);
        countObject--;
        if (countObject == 0)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] != null)
                {
                    objects[i].transform.position = initialPositions[i]; // ?????????? ?? ????????? ???????
                }
            }
        }
    }
}
