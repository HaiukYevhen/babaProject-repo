//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.AI;
//using UnityEngine.UIElements.Experimental;

//public class EnemyAi : MonoBehaviour
//{
//    public NavMeshAgent ai;
//    public List<Transform> destinations;
//    public Animator aiAnimator;
//    public float walkSpeed, chaseSpeed;
//    public bool walking, chasing;
//    public Transform player;
//    Transform currentDest;
//    Vector3 dest;
//    int randNum;
//    public int destinationAmount;

//    private float timer = 0f; 
//    public int secondsElapsed = 0; 
//    public int timerDuration = 5;

//    private FieldOfView fielfOfView;   
//    void Start()
//    {
//        fielfOfView = gameObject.GetComponent<FieldOfView>();

//        walking = true;
//        randNum = Random.Range(0, destinationAmount);
//        currentDest = destinations[randNum];
//        aiAnimator.SetFloat("Speed_f", 0.3f); 
//    }

//    void Update()
//    {
//        if(walking == false) 
//        {
//            aiAnimator.SetFloat("Speed_f", 0);
//        }
//        if (fielfOfView.canSeePlayer == true) 
//        {
//            chasing = true;
//        }
//        if(fielfOfView.canSeePlayer == false && secondsElapsed >= 1)
//        {
//            walking = false;
//            aiAnimator.SetFloat("Speed_f", 1f);

//            timer += Time.deltaTime;
//            if (timer >= 1f)
//            {
//                timer -= 1f;
//                secondsElapsed--;
//            }
//            dest = player.position;
//            ai.destination = dest;
//            ai.speed = chaseSpeed;

//            if(secondsElapsed == 0)
//            {
//                chasing = false;
//                walking = true;
//            }
//        }

//        if (fielfOfView.canSeePlayer == true && chasing == true)
//        {
//            TimerExample();
//            aiAnimator.SetFloat("Speed_f", 1f);
//            dest = player.position;
//            ai.destination = dest;
//            ai.speed = chaseSpeed;
//        }

//        if (fielfOfView.canSeePlayer == false  && walking == true)
//        {

//            aiAnimator.SetFloat("Speed_f", 0.3f);
//            dest = currentDest.position;
//            ai.destination = dest;
//            ai.speed = walkSpeed;
//            if (ai.remainingDistance <= ai.stoppingDistance) 
//            {
//                randNum = Random.Range(0, destinationAmount);
//                currentDest = destinations[randNum];
//            }
//            chasing = false;
//        }        
//    }
//    void TimerExample() 
//    {

//        timer += Time.deltaTime;
//        if (timer >= 1f)
//        {
//            timer -= 1f;

//            secondsElapsed++;

//            Debug.Log(secondsElapsed);
//        }
//    }

//}



//////////////////////////



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class EnemyAi : MonoBehaviour
{
    //public NavMeshAgent ai;

    //public Animator aiAnimator;
    //public float walkSpeed, chaseSpeed;
    //public bool walking, chasing;
    //public Transform targetPlayer; // ???????? ???????, ?? ???? ???????
    //public Transform currentDest;
    //Vector3 dest;
    //int randNum;
    //public int destinationAmount;

    //public LayerMask destinationLayer;
    //public List<Transform> destinations = new List<Transform>();


    //private FieldOfView fieldOfView;
    //public float lostTargetTimer = 0f; // ?????? ??? ?????? ????
    //public float lostTargetDuration = 3f; // ???, ????? ???? ????? ???????? ?????????, ???? ??????? ????

    //void Start()
    //{

    //    ai = gameObject.GetComponent<NavMeshAgent>();
    //    if (ai == null) 
    //    {
    //        gameObject.AddComponent<NavMeshAgent>();
    //        ai = gameObject.GetComponent<NavMeshAgent>();
    //        NavMeshAgentHandler();
    //    }
    //    fieldOfView = gameObject.GetComponent<FieldOfView>();
    //    aiAnimator = gameObject.GetComponent<Animator>();

    //    walkSpeed = 2;
    //    chaseSpeed = 5;
    //    destinationLayer = LayerMask.GetMask("Destination");
    //    //Debug.Log(destinationLayer.value);
    //    // ????????? ??? ????? ???????????? ?? ?????
    //    FindDestinationsByLayer();
    //    if (destinations.Count > 0)
    //    {
    //        int randNum = Random.Range(0, destinations.Count);
    //        currentDest = destinations[randNum];
    //        NoSameDest();
    //    }
    //    walking = true;
    //    //randNum = Random.Range(0, destinationAmount);
    //    //currentDest = destinations[randNum];
    //    if(aiAnimator != null)
    //        aiAnimator.SetFloat("Speed_f", 0.3f);
    //}

    //void Update()
    //{
    //    if (fieldOfView.visibleTargets.Count > 0)
    //    {
    //        if (targetPlayer == null || !fieldOfView.visibleTargets.Contains(targetPlayer))
    //        {
    //            // ??????????? ?????? ??????, ???? ??????? ????? ??? ??? ????
    //            targetPlayer = fieldOfView.visibleTargets[0];
    //        }

    //        chasing = true;
    //        lostTargetTimer = 0f; // ???????? ??????
    //    }
    //    else
    //    {
    //        if (chasing)
    //        {
    //            lostTargetTimer += Time.deltaTime;

    //            if (lostTargetTimer >= lostTargetDuration)
    //            {
    //                // ???? ?????? ????? ?????, ??? `lostTargetDuration`, ?????????? ??????????
    //                targetPlayer = null;
    //                chasing = false;
    //                walking = true;

    //                //Test layer Enemy
    //                NoSameDest();
    //            }
    //        }
    //    }

    //    if (chasing && targetPlayer != null)
    //    {
    //        // ???????? ?? ???????? ???????
    //        if (aiAnimator != null)
    //            aiAnimator.SetFloat("Speed_f", 1f);
    //        dest = targetPlayer.position;
    //        ai.destination = dest;
    //        ai.speed = chaseSpeed;
    //        walking = false;
    //    }
    //    else if (walking)
    //    {
    //        // ????????????
    //        if (aiAnimator != null)
    //            aiAnimator.SetFloat("Speed_f", 0.3f);
    //        dest = currentDest.position;
    //        ai.destination = dest;
    //        ai.speed = walkSpeed;

    //        if (ai.remainingDistance <= ai.stoppingDistance)
    //        {
    //            //randNum = Random.Range(0, destinationAmount);
    //            //currentDest = destinations[randNum];
    //            int randNum = Random.Range(0, destinations.Count);
    //            currentDest = destinations[randNum];
    //            NoSameDest();
    //        }
    //    }
    //}

    //void FindDestinationsByLayer()
    //{
    //    destinations.Clear();

    //    // ????????? ????????? ???? ??????
    //    Collider[] foundColliders = Physics.OverlapSphere(transform.position, Mathf.Infinity, destinationLayer);

    //    // ????????? ????????????? ??’????? ?? ??????? ?????
    //    destinations = foundColliders.Select(collider => collider.transform).ToList();

    //    if (destinations.Count == 0)
    //    {
    //        Debug.LogError("?? ???????? ?????? ????? ???????????? ?? ????? Destination!");
    //    }
    //    else
    //    {
    //        Debug.Log($"???????? {destinations.Count} ??'????? ??? ????????????.");
    //    }
    //}
    //void NavMeshAgentHandler() 
    //{
    //    // dog
    //    ai.baseOffset = -0.01f;
    //    ai.radius = 0.14f;
    //    ai.height = 0.17f;
    //    int areaMask = 0;
    //    areaMask += 1<< NavMesh.GetAreaFromName("Walkable");
    //    Debug.Log("areaMask: " + areaMask);
    //    ai.areaMask = areaMask;
    //    //gameObject.layer += 0 << LayerMask.GetMask("Enemy"); 
    //    //Debug.Log(LayerMask.GetMask("Enemy"));
    //    gameObject.layer = LayerMask.NameToLayer("Enemy");

    //}
    //void NoSameDest() 
    //{
    //    int enemyLayer = LayerMask.NameToLayer("Enemy");

    //    if (enemyLayer == -1)
    //    {
    //        Debug.LogError("??? 'Enemy' ?? ????????! ?????????????, ?? ??? ????? ? Unity.");
    //        return ;
    //    }
    //    List<GameObject> enemies = GameObject.FindObjectsOfType<GameObject>()
    //    .Where(obj => obj.layer == enemyLayer)
    //    .ToList();

    //    Debug.Log($"???????? {enemies.Count} ???????????.");
    //    Transform tempDest;
    //    // ?????????, ???? ????? ???? ??????? ? ????? ????????????
    //    foreach (GameObject enemy in enemies)
    //    {
    //        Debug.Log($"Enemy: {enemy.name}");
    //        if(gameObject.GetComponent<EnemyAi>().currentDest == enemy.GetComponent<EnemyAi>().currentDest) 
    //        {
    //            int randNum = Random.Range(0, destinations.Count);
    //            currentDest = destinations[randNum];
    //        }

    //        //currentDest
    //    }
    //}
    //////////

    ////////////////////////////////
    public NavMeshAgent ai;
    public Animator aiAnimator;
    public float walkSpeed = 2f, chaseSpeed = 5f;
    public bool walking = true, chasing = false;
    public Transform targetPlayer;
    public Transform currentDest;
    public LayerMask destinationLayer;
    public float lostTargetDuration = 3f;
    public float stuckCheckDuration = 5f;

    private float lostTargetTimer = 0f;
    private float stuckTimer = 0f;
    private Vector3 lastPosition;
    private FieldOfView fieldOfView;
    private List<Transform> destinations = new List<Transform>();

    void Start()
    {
        ai = GetComponent<NavMeshAgent>();
        if (ai == null) ai = gameObject.AddComponent<NavMeshAgent>();
        InitNavMeshAgent();

        fieldOfView = GetComponent<FieldOfView>();
        aiAnimator = GetComponent<Animator>();

        destinationLayer = LayerMask.GetMask("Destination");
        FindDestinationsByLayer();
        SelectNewDestination();
        lastPosition = transform.position;

        if (aiAnimator != null)
            aiAnimator.SetFloat("Speed_f", 0.3f);
    }

    void Update()
    {
        if (fieldOfView.visibleTargets.Count > 0)
        {
            if (targetPlayer == null || !fieldOfView.visibleTargets.Contains(targetPlayer))
            {
                targetPlayer = fieldOfView.visibleTargets[0];
            }

            chasing = true;
            lostTargetTimer = 0f;
        }
        else if (chasing)
        {
            lostTargetTimer += Time.deltaTime;
            if (lostTargetTimer >= lostTargetDuration)
            {
                targetPlayer = null;
                chasing = false;
                walking = true;
                SelectNewDestination();
            }
        }

        if (chasing && targetPlayer != null)
        {
            if (aiAnimator != null) aiAnimator.SetFloat("Speed_f", 1f);
            ai.destination = targetPlayer.position;
            ai.speed = chaseSpeed;
            walking = false;
        }
        else if (walking)
        {
            if (aiAnimator != null) aiAnimator.SetFloat("Speed_f", 0.3f);
            ai.destination = currentDest != null ? currentDest.position : transform.position;
            ai.speed = walkSpeed;

            stuckTimer += Time.deltaTime;

            if (ai.remainingDistance <= ai.stoppingDistance || stuckTimer >= stuckCheckDuration)
            {
                stuckTimer = 0f;
                if (!SelectNewDestination())
                {
                    ai.destination = transform.position; // stand still
                }
            }
        }

        lastPosition = transform.position;
    }

    void InitNavMeshAgent()
    {
        ai.baseOffset = -0.01f;
        ai.radius = 0.14f;
        ai.height = 0.17f;
        ai.areaMask = 1 << NavMesh.GetAreaFromName("Walkable");
        gameObject.layer = LayerMask.NameToLayer("Enemy");
    }

    void FindDestinationsByLayer()
    {
        destinations.Clear();
        Collider[] found = Physics.OverlapSphere(transform.position, Mathf.Infinity, destinationLayer);
        destinations = found.Select(c => c.transform).ToList();
    }

    bool SelectNewDestination()
    {
        if (destinations.Count == 0) return false;

        List<Transform> availableDest = new List<Transform>(destinations);
        List<GameObject> enemies = FindObjectsOfType<GameObject>().Where(obj => obj.layer == LayerMask.NameToLayer("Enemy")).ToList();

        foreach (GameObject enemy in enemies)
        {
            if (enemy == this.gameObject) continue;
            EnemyAi otherAI = enemy.GetComponent<EnemyAi>();
            if (otherAI != null && otherAI.currentDest != null)
            {
                availableDest.Remove(otherAI.currentDest);
            }
        }

        if (availableDest.Count == 0) return false;

        Transform newDest = availableDest[Random.Range(0, availableDest.Count)];
        currentDest = newDest;
        return true;
    }
    ////////////////////////////////

    ////////
    //void FindDestinationsByLayer()
    //{
    //    destinations.Clear();

    //    // ????????? ??? ??'???? ? ????????? ????? ????? LINQ
    //    destinations = GameObject.FindObjectsOfType<Transform>()
    //                             .Where(obj => (destinationLayer & (1 << obj.gameObject.layer)) != 0)
    //                             .Select(obj => obj.transform)
    //                             .ToList();

    //    if (destinations.Count == 0)
    //    {
    //        Debug.LogError("?? ???????? ?????? ????? ???????????? ?? ????? Destination!");
    //    }
    //    else
    //    {
    //        Debug.Log($"???????? {destinations.Count} ??'????? ??? ????????????.");
    //    }
    //}


    /////////////////////////////////////
    //private void FindDestinationsByLayer()
    //{
    //    // ???????? ?????? ????? ???????
    //    destinations.Clear();

    //    // ????????? ????? ??? ??'???? ? ?????
    //    GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

    //    foreach (GameObject obj in allObjects)
    //    {
    //        // ???????????, ?? ??'??? ??? ????????? ???
    //        if (obj.layer == Mathf.Log(destinationLayer.value, 2))
    //        {
    //            destinations.Add(obj.transform);
    //        }
    //    }

    //    // ?????????, ?? ??????? ?? ???? ? ???? ??'???
    //    if (destinations.Count == 0)
    //    {
    //        Debug.LogError("?? ???????? ?????? ????? ???????????? ?? ??????? ?????!");
    //    }
    //    else
    //    {
    //        Debug.Log($"???????? {destinations.Count} ??'????? ??? ????????????.");
    //    }
    //}
}
