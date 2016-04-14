using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float chaseWaitTime = 5f;
    public float patrolWaitTime = 1f;
    public Transform[] patrolWayPoints;

    private EnemySight enemySight;
    private NavMeshAgent nav;
    private Transform player;
    private PlayerHealth playerHealth;
    private LastPlayerSighting lastPlayerSighting;
    private float chaseTimer;
    private float patrolTimer;
    private int wayPointIndex;

	// Use this for initialization
	void Start ()
	{
		enemySight = GetComponent<EnemySight> ();
		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		playerHealth = player.GetComponent<PlayerHealth> ();
		lastPlayerSighting = GetComponent<LastPlayerSighting> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
        

        if (enemySight.playerInSight)
        {
            Debug.Log("shooting");
            Shooting();
        }

        else if (enemySight.personalLastSighting != enemySight.resetPosition)
        {
            Chasing();
            Debug.Log("chase");
        }
            

        else
            Patrolling();  
	}

    void Shooting()
    {
        nav.Stop();
        Debug.Log("shot");
    }

    void Chasing()
    {
        Vector3 sightingDeltaPos = enemySight.personalLastSighting - transform.position;

        if (sightingDeltaPos.sqrMagnitude > 4f)
            nav.destination = enemySight.personalLastSighting;

        nav.speed = chaseSpeed;

        if (nav.remainingDistance < nav.stoppingDistance)
        {
            chaseTimer += Time.deltaTime;

            if (chaseTimer >= chaseWaitTime)
            {
                lastPlayerSighting.position = lastPlayerSighting.resetPosition;
                enemySight.personalLastSighting = lastPlayerSighting.resetPosition;
                chaseTimer = 0f;
            }
        }
        else
            chaseTimer = 0f;
    }

    void Patrolling()
    {
        nav.speed = patrolSpeed;
        wayPointIndex = 0;

        if (nav.destination == nav.nextPosition)
        {
            wayPointIndex++;
            nav.destination = patrolWayPoints[wayPointIndex].position;
        }
            
            
        else
            nav.destination = patrolWayPoints[wayPointIndex].position;
        

       /*patrolTimer += Time.deltaTime;
       if (wayPointIndex == patrolWayPoints.Length - 1)
            wayPointIndex = 0;
       else
            wayPointIndex++;

        Debug.Log("Next round");
        /*if (nav.remainingDistance < nav.stoppingDistance)
        {
            
            /*if (patrolTimer >= patrolWaitTime)
            {
                

                patrolTimer = 0;
            }

            
        }
        else
            patrolTimer = 0;
        
        nav.destination = patrolWayPoints[wayPointIndex].position;*/
    }
}
