﻿using UnityEngine;
using System.Collections;

public class enemyBossAI : MonoBehaviour
{

    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float chaseWaitTime = 5f;
    public float patrolWaitTime = 1f;
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
    private Vector3 PersonnalLastSighting;
    private EnemyLife enemyLife;

    [SerializeField]
    float damages;
    

    private EnemyShooting enemyShooting;

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
        enemyShooting = GetComponent<EnemyShooting>();
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

            else if (enemySight.personalLastSighting != enemySight.resetPosition && !enemySight.playerInSight)
            {
                anim.SetBool("Shoot", false);
                Chasing();
            }
            
        }

        else
        {
            nav.Stop();
            anim.SetBool("Shoot", false);
            anim.Stop();
        }



        //laserShotLight.intensity = Mathf.Lerp(laserShotLight.intensity, 0f, fadeSpeed * Time.deltaTime);
    }

    void Shooting()
    {
        if (nextFire > Time.time)
            return;

        nav.Stop();
        playerHealth.TakeDamage(damages);
        anim.SetBool("Shoot", true);

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position + new Vector3(0, 1.9f, 0), transform.rotation);
        bullet.name = bulletPrefab.name;

        Destroy(bullet, 2f);

        // Make the light flash.
        laserShotLight.intensity = flashIntensity;

        nextFire = Time.time + 1;
    }

    void Chasing()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(enemySight.personalLastSighting - transform.position), chaseSpeed * Time.deltaTime);
        transform.position += transform.forward * chaseSpeed * Time.deltaTime;
    }

   
}
