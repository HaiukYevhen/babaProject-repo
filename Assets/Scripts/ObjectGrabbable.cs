using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }
    public void Grab (Transform objectGrabPointTransform)
    {
        if (objectRigidbody.mass <= 10000)
        {
            this.objectGrabPointTransform = objectGrabPointTransform;
            objectRigidbody.useGravity = false;
            objectRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
        else  Debug.Log("its too heavy"); 
    }
    public void Drop() 
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
        objectRigidbody.velocity = Vector3.zero;
    }

    public void FixedUpdate()
    {
        if (objectGrabPointTransform != null) 
        {
            //float lerpSpeed = 10f;
            //Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            //objectRigidbody.MovePosition(newPosition);

            float followSpeed = 10f;

            // ??? ?? ??????? ????? velocity
            Vector3 direction = objectGrabPointTransform.position - transform.position;
            Vector3 desiredVelocity = direction * followSpeed;

            // ????????? ?????????, ???? ????????
            float maxSpeed = 2f;
            if (desiredVelocity.magnitude > maxSpeed)
            {
                desiredVelocity = desiredVelocity.normalized * maxSpeed;
            }

            objectRigidbody.velocity = desiredVelocity;
        }
    }
}
