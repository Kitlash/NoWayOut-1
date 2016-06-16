using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;
    public Vector3 resetPosition = new Vector3(1000000f, 1000000f, 1000000f);
    public Vector3 position = new Vector3(1000000f, 1000000f, 1000000f);

    private GameObject player;
    private LastPlayerSighting lastPlayerSighting;
    private NavMeshAgent nav;
    private Vector3 previousSighting;
    private SphereCollider col;
	private PlayerHealth playerHealth;

    void Start()
    {
		nav = GetComponent<NavMeshAgent>();       
		col = GetComponent<SphereCollider>();      
        player = GameObject.FindGameObjectWithTag(Tags.player);
		playerHealth = player.GetComponent<PlayerHealth> ();
        personalLastSighting = resetPosition;
    }

    void Update()
    {
        if (playerInSight)
            personalLastSighting = player.transform.position;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInSight = false;
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if(angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;

                if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {                    
                    if(hit.collider.gameObject == player)
                        playerInSight = true;
                }
            }      
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
            playerInSight = false;
    }

    float CalculatePathLength(Vector3 targetPosition)
    {
        NavMeshPath path = nav.path;//new NavMeshPath();

        nav.CalculatePath(targetPosition, path);

        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];
        allWayPoints[0] = transform.position;
        allWayPoints[allWayPoints.Length - 1] = targetPosition;

        for(int i = 0; i < path.corners.Length; i++)
            allWayPoints[i + 1] = path.corners[i];

        float pathLength = 0;

        for(int i = 0; i < allWayPoints.Length - 1; i++)
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);

        return pathLength;
    }
}
