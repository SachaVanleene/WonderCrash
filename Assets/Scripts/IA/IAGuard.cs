using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class IAGuard : MonoBehaviour {

    Animator anim;
    NavMeshAgent agent;
    bool isMovingToDestnation;
    Transform currentDestination;
    float minDistToDestination;
    bool movingToPlayer;
    Transform playerTransform;

    float timeSinceNotSeenPlayer;
    float timeNeededToEscape;

    public Slider detectionBar;

    public LayerMask maskLayer;

    private GameObject player;

    public GameObject cone;

    GameObject[] dest;
    List<GameObject> Destination;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        minDistToDestination = 0.1f;
        movingToPlayer = false;
        isMovingToDestnation = false;
        timeSinceNotSeenPlayer = 0f;
        timeNeededToEscape = 1f;
        player = GameObject.FindGameObjectWithTag("Player");
        dest = GameObject.FindGameObjectsWithTag("RoamingDestination");
        Destination = new List<GameObject>(dest);
    }



    // Use this for initialization
    void Start()
    {
        currentDestination = GetNextDestination();
        playerTransform = player.transform;
    }


    void Roaming()
    {
        if (!isMovingToDestnation) // si pas de destination
        {
            currentDestination = GetNextDestination();
            isMovingToDestnation = true;
        }
    }

    public void ChasePlayer(GameObject player)
    {
        if (!movingToPlayer)
        {
            currentDestination = player.transform;
            //playerTransform = player.transform;
            timeSinceNotSeenPlayer = 0f;
            movingToPlayer = true;
            isMovingToDestnation = true;
            anim.SetBool("moving", true);
        }
    }

    Transform GetNextDestination() // Obtenir une destination assez éloigné pour avoir un meilleur comportement 
    {
        List<Transform> possibleDestination = new List<Transform>(Destination.Count);
        for (int i = 0; i < Destination.Count; i++)
        {
            if (Vector3.Distance(transform.position, Destination[i].transform.position) > 0.5)
            {
                possibleDestination.Add(Destination[i].transform);
            }
        }
        isMovingToDestnation = true;
        anim.SetBool("moving", true);
        return possibleDestination[Random.Range(0, possibleDestination.Count)];
    }

    void FixedUpdate()
    {
        if (isMovingToDestnation)
        {
            agent.SetDestination(currentDestination.position);
            if (isDestinationReached() && !movingToPlayer) // on attend avant de repartir
            {
                StartCoroutine(waitBeforeMoving());
            }
            if (movingToPlayer)
            {
                RaycastHit hit;
                Vector3 upTransform = transform.position + new Vector3(0f, 2, 0f);
                Vector3 direction = (playerTransform.position - (transform.position + upTransform)).normalized;
                if (Physics.Linecast(cone.transform.position, playerTransform.position, out hit,maskLayer))
                {
                    Debug.LogError("Ca collide tag"+hit.transform.tag);
                    Debug.DrawLine(cone.transform.position, playerTransform.position, Color.red);
                    Debug.DrawLine(cone.transform.position, hit.transform.position, Color.green);
                    if (hit.transform.tag == "Player")
                    {
                        //Debug.LogError("Joueur");
                        IncreaseDetectionValue();
                        timeSinceNotSeenPlayer = 0f;
                    }
                    if (hit.transform.tag == "Obstacle")
                    {
                        timeSinceNotSeenPlayer += Time.deltaTime;
                    }
                }
                if (timeSinceNotSeenPlayer > timeNeededToEscape)
                {
                    //Debug.LogError("Joueur perdu de vu");
                    LosingTarget();
                }
            }
        }
        if(!movingToPlayer && detectionBar.value > 0) //Diminuer la detection
        {
            detectionBar.value -= 0.01f;
            if (detectionBar.value < 0)
            {
                detectionBar.value = 0;
            }
        }

    }

    public void IncreaseDetectionValue()
    {
        detectionBar.value += 0.01f;
        /* Vector3 agentVector = new Vector3(transform.position.x, 0f, transform.position.z);
         Vector3 targetVector = new Vector3(currentDestination.position.x, 0f, currentDestination.position.z);
         float distance = Vector3.Distance(agentVector,targetVector);
         if(detectionBar.value + (1f-distance)> 1)
         {
             detectionBar.value = 1;
         }
         else
         {
             detectionBar.value += (1f - (distance);
         }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player" && movingToPlayer)
        {
            anim.SetBool("moving", false);
            currentDestination = agent.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && movingToPlayer)
        {
            anim.SetBool("moving", true);
            currentDestination = playerTransform;
        }
    }

    bool isDestinationReached()
    {
        Vector3 agentVector = new Vector3(transform.position.x, 0f, transform.position.z);
        Vector3 targetVector = new Vector3(currentDestination.position.x, 0f, currentDestination.position.z);
        //Debug.LogError("Deistance : " + Vector3.Distance(transform.position, currentDestination.position));
        return (Vector3.Distance(agentVector,targetVector) < minDistToDestination);
    }

    IEnumerator waitBeforeMoving()
    {
        anim.SetBool("moving", false);
        isMovingToDestnation = false;
        yield return new WaitForSeconds(5);
        if (!movingToPlayer)
        {
            currentDestination = GetNextDestination();
        }
    }

    void LosingTarget()
    {
        agent.SetDestination(agent.transform.position);
        Debug.LogError("Je passe dans la fonction");
        movingToPlayer = false;
        currentDestination = agent.transform;
        anim.SetTrigger("targetLost");
        anim.SetBool("moving", false);
        isMovingToDestnation = false;
        StartCoroutine(confusedThenBackToNextPosition());
    }

    IEnumerator confusedThenBackToNextPosition()
    {
        yield return new WaitForSeconds(6.33f);
        if (!movingToPlayer)
        {
            currentDestination = GetNextDestination();
        }
    }


}
