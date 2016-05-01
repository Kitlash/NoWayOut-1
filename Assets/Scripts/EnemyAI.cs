using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float chaseWaitTime = 5f;
    public float patrolWaitTime = 1f;
    public Transform[] patrolWayPoints;
    public float flashIntensity = 3f;
    public float fadeSpeed = 10f;
    public GameObject bulletPrefab;

    private LineRenderer laserShotLine;
    private Light laserShotLight;
    private EnemySight enemySight;
    private NavMeshAgent nav;
    private Transform player;
    private PlayerHealth playerHealth;
    private LastPlayerSighting lastPlayerSighting;
    private float chaseTimer;
    private float patrolTimer;
    private int wayPointIndex =0;
    private Animator anim;
    private float nextFire;

    private EnemyShooting enemyShooting;

	// Use this for initialization
	void Start ()
	{
        laserShotLine = GetComponentInChildren<LineRenderer>();
        laserShotLight = GetComponentInChildren<Light>();
        enemySight = GetComponent<EnemySight> ();
		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		playerHealth = player.GetComponent<PlayerHealth> ();
		lastPlayerSighting = GetComponent<LastPlayerSighting> ();
        enemyShooting = GetComponent<EnemyShooting>();
        anim = GetComponent<Animator>();
        anim.Play("Idle");

        nextFire = Time.time;

        laserShotLine.enabled = false;
        laserShotLight.intensity = 0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        

        if (enemySight.playerInSight)
        {
            Debug.Log("shooting");
            Shooting();
        }

        /*else if (enemySight.personalLastSighting != enemySight.resetPosition)
        {
            Chasing();
            Debug.Log("chase");
        }*/
            

        else
            Patrolling();

        laserShotLight.intensity = Mathf.Lerp(laserShotLight.intensity, 0f, fadeSpeed * Time.deltaTime);
    }

    void Shooting()
    {
        if (nextFire > Time.time)
            return;

        nav.Stop();
        playerHealth.TakeDamage(5);
        anim.Play("Shooting");
        //laserShotLine.SetPosition(0, laserShotLine.transform.position);

        // Set the end position of the player's centre of mass.
        //laserShotLine.SetPosition(1, player.position + Vector3.up * 1.5f);

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position + new Vector3(0, 1.8f, 0), transform.rotation);
        bullet.name = bulletPrefab.name;

        Destroy(bullet, 2f);

        //bullet.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward)* 100);

        //if (anim.GetFloat("Shot") > 0.5f)
        //    laserShotLine.enabled = true;

        // Make the light flash.
        laserShotLight.intensity = flashIntensity;
        Debug.Log("shot");

        nextFire = Time.time + 1;

    }

    /*void Chasing()
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
    }*/

    void Patrolling()
    {
        anim.Play("isWalking");
        nav.speed = patrolSpeed;
        wayPointIndex %= (patrolWayPoints.Length - 1);

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
