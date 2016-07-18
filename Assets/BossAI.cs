using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour
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
    private int wayPointIndex = 0;
    private Animator anim;
    private float nextFire;


    // Use this for initialization
    void Start()
    {
        laserShotLine = GetComponentInChildren<LineRenderer>();
        laserShotLight = GetComponentInChildren<Light>();
        enemySight = GetComponent<EnemySight>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        lastPlayerSighting = GetComponent<LastPlayerSighting>();
        anim = GetComponent<Animator>();

        nextFire = Time.time;

        //laserShotLine.enabled = false;
        //aserShotLight.intensity = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (enemySight.playerInSight)
        {
            Shooting();
        }

        else
            Patrolling();


        //laserShotLight.intensity = Mathf.Lerp(laserShotLight.intensity, 0f, fadeSpeed * Time.deltaTime);
    }

    void Shooting()
    {
        if (nextFire > Time.time)
            return;

        nav.Stop();
        playerHealth.TakeDamage(5);
        anim.SetBool("Shoot", true);
        

        /*GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position + new Vector3(0, 1.8f, 0), transform.rotation);
        bullet.name = bulletPrefab.name;

        Destroy(bullet, 2f);

        
        laserShotLight.intensity = flashIntensity;


        nextFire = Time.time + 1;*/

    }



    void Patrolling()
    {

        nav.speed = patrolSpeed;
        wayPointIndex %= (patrolWayPoints.Length - 1);
        //nav.destination == nav.nextPosition

        if (nav.destination == nav.nextPosition)
        {
            wayPointIndex++;
            nav.destination = patrolWayPoints[wayPointIndex].position;
        }

        else
        {
            nav.destination = patrolWayPoints[wayPointIndex].position;
        }
            

            

    }        

}
