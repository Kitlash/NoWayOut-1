using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float patrolWaitTime = 3f;
    public Transform[] patrolWayPoints;
    public float flashIntensity = 3f;
    public float fadeSpeed = 10f;
    public GameObject bulletPrefab;
    public float damagePoints;

    private LineRenderer laserShotLine;
    private Light laserShotLight;
    private EnemySight enemySight;
    private NavMeshAgent nav;
    private Transform player;
    private PlayerHealth playerHealth;
    private int wayPointIndex = 0;
    private Animator anim;
    private float nextFire;
    private EnemyLife enemyLife;

    // Use this for initialization
    void Start()
    {
        laserShotLine = GetComponentInChildren<LineRenderer>();
        laserShotLight = GetComponentInChildren<Light>();
        enemySight = GetComponent<EnemySight>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        enemyLife = GetComponent<EnemyLife>();

        nextFire = Time.time;

        //laserShotLine.enabled = false;
        //laserShotLight.intensity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyLife.Life > 0)
        {
            if (enemySight.playerInSight)
                Shooting();

            else
                Patrolling();
        }

        //laserShotLight.intensity = Mathf.Lerp(laserShotLight.intensity, 0f, fadeSpeed * Time.deltaTime);
    }

    void Shooting()
    {
        if (nextFire > Time.time)
            return;

        nav.Stop();
        playerHealth.TakeDamage(damagePoints);
        anim.SetBool("Shoot", true);
        

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position + new Vector3(0, 1.8f, 0), transform.rotation);
        bullet.name = bulletPrefab.name;

        Destroy(bullet, 2f);

        
        laserShotLight.intensity = flashIntensity;


        nextFire = Time.time + 1;

    }



    void Patrolling()
    {
        nav.speed = patrolSpeed;
        wayPointIndex %= (patrolWayPoints.Length - 1);
        
        if (nav.destination == nav.nextPosition)
        {
            patrolWaitTime -= Time.deltaTime;
            if (patrolWaitTime <= 0)
            {
                wayPointIndex++;
                nav.destination = patrolWayPoints[wayPointIndex].position;
            }           
        }

        else
        {
            nav.destination = patrolWayPoints[wayPointIndex].position;
        }
        patrolWaitTime = 3f;
    }        
}
