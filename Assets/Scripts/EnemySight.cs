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
    
    //private Animator anim;
    
    //private Animator playerAnim;
	private PlayerHealth playerHealth;
    

    void Start()
    {
		nav = GetComponent<NavMeshAgent>();       
		col = GetComponent<SphereCollider>();
		//anim = GetComponent<Animator> ();
		//anim = GameObject.FindGameObjectWithTag(Tags.enemy).GetComponent<Animator>(); // inutile si tu places ton script sur ton prefab ennemy, la ligne au dessus est suffisante je pense 
        //lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();        
        player = GameObject.FindGameObjectWithTag(Tags.player);
		//playerAnim = player.GetComponent<Animator>(); // pourquoi t'as besoin de l'animator tu playor?
		playerHealth = player.GetComponent<PlayerHealth> ();
        
        
		
        //personalLastSighting = resetPosition;
    }

    void Update()
    {
        if (playerInSight == true)
        {
            personalLastSighting = player.transform.position;
            Debug.Log("personal last sighting");
        }
            
        
        else
            personalLastSighting = resetPosition;
        /*if (position != previousSighting)
            personalLastSighting = position;

        previousSighting = position;*/
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInSight = false;
            

            Vector3 direction = other.transform.position - transform.position;
            //nav.SetDestination(direction);
            float angle = Vector3.Angle(direction, transform.forward);

            if(angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;

                if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    
                    if(hit.collider.gameObject == player)
                    {
                        playerInSight = true;
                        

                        //Animation shoot

                        //playerHealth.TakeDamage(20);
                    }
                }
            }

            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInSight = false;
            
        }
    }

    float CalculatePathLength(Vector3 targetPosition)
    {
        NavMeshPath path = nav.path;//new NavMeshPath();

        //if(nav.enabled)
        //{
        nav.CalculatePath(targetPosition, path);
        //}
        

        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];
        allWayPoints[0] = transform.position;
        allWayPoints[allWayPoints.Length - 1] = targetPosition;

        for(int i = 0; i < path.corners.Length; i++)
        {
            allWayPoints[i + 1] = path.corners[i];
        }

        float pathLength = 0;

        for(int i = 0; i < allWayPoints.Length - 1; i++)
        {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
        }

        return pathLength;
    }
}
