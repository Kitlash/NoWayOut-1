using UnityEngine;
using System.Collections;

public class touristRout : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public Transform[] patrolWayPoints;

    private NavMeshAgent nav;
    private int wayPointIndex = 0;

    // Use this for initialization
    void Start ()
    {
        nav = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Patrolling();
	}

    void Patrolling()
    {

        nav.speed = patrolSpeed;
        wayPointIndex %= (patrolWayPoints.Length - 1);

        if (nav.destination == nav.nextPosition)
        {
            wayPointIndex++;
            nav.destination = patrolWayPoints[wayPointIndex].position;
        }


        else
            nav.destination = patrolWayPoints[wayPointIndex].position;
    }
}
