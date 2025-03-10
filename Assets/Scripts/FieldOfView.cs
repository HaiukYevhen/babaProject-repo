using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    //public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public List<bool> canSeePlayers;
    public bool canSeePlayer;

    //
    public List<Transform> visibleTargets = new List<Transform>(); // ?????? ??????? ???????
    void Start()
    {
        //Debug.Log(LayerMask.GetMask("Obstruction"));
        radius = 7;
        angle = 100;
        targetMask = LayerMask.GetMask("Target");
        obstructionMask = LayerMask.GetMask("Obstruction");
        //playerRef = GameObject.FindGameObjectWithTag("PlayerPrefab");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine() 
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true) 
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    //private void FieldOfViewCheck()
    //{
    //    Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

    //    if (rangeChecks.Length != 0) 
    //    {
    //        Transform target = rangeChecks[0].transform;
    //        Vector3 directionToTarget = (target.position - transform.position).normalized;

    //        if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2) 
    //        {
    //            float distanceToTarget = Vector3.Distance(transform.position, target.position);

    //            if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask)) 
    //                canSeePlayer = true;
    //            else
    //                canSeePlayer = false; // &=

    //        }
    //        else
    //            canSeePlayer = false;
    //    }
    //    else if (canSeePlayer) 
    //        canSeePlayer = false;
    //}
    private void FieldOfViewCheck()
    {

        visibleTargets?.Clear(); // ???????? ?????? ??????? ?????
        canSeePlayers?.Clear();
        canSeePlayer = false;

        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        foreach (Collider targetCollider in rangeChecks)
        {
            Transform target = targetCollider.transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    visibleTargets?.Add(target); 
                    canSeePlayers?.Add(true);
                    canSeePlayer = true;
                }
            }
        }
    }
}
