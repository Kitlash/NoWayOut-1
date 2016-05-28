﻿using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour 
{
	public float maximumDamage = 120f;
	public float minimumDamage = 45f;
    public float flashIntensity = 3f;
    public float fadeSpeed = 10f;

	private Animator anim;
    private HashIDs hash;
	private LineRenderer laserShotLine;
    private Light laserShotLight;
	private SphereCollider col;
	private Transform player;
	private PlayerHealth playerHealth;
	private bool shooting;
	private float scaledDamage;
   //private H

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
        laserShotLine = GetComponentInChildren<LineRenderer>();
        laserShotLight = GetComponentInChildren<Light>();
		col = GetComponent<SphereCollider> ();
		player = GameObject.FindGameObjectWithTag(Tags.player).transform;
		playerHealth = player.gameObject.GetComponent<PlayerHealth> ();
        //hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();

        laserShotLine.enabled = false;
        laserShotLight.intensity = 0f;

		scaledDamage = maximumDamage - minimumDamage;
	}
	
<<<<<<< HEAD

=======
//<<<<<<< HEAD
>>>>>>> ab896de25a70c447b967c54f3da058a8c5f8ec92
	// Update is called once per frame
	void Update () 
	{
        //float shot = anim.GetFloat(hash.shotFloat);
        float shot = anim.GetFloat("Shot");

        if (shot > 0.5f && !shooting)
            Shoot();

        if (shot < 0.5f)
        {
            shooting = false;
            laserShotLine.enabled = false;
        }

        laserShotLight.intensity = Mathf.Lerp(laserShotLight.intensity, 0f, fadeSpeed * Time.deltaTime);
	}
<<<<<<< HEAD

	// Update is called once per frame
	

=======
//=======
//	// Update is called once per frame
//	void Update () 
//	{
//        float shot = anim.GetFloat(hash.shotFloat);
//
//        if (shot > 0.5f && !shooting)
//            Shoot();
//
//        if (shot < 0.5f)
//        {
//            shooting = false;
//            laserShotLine.enabled = false;
//        }
//
//        laserShotLight.intensity = Mathf.Lerp(laserShotLight.intensity, 0f, fadeSpeed * Time.deltaTime);
//	
//	}
//>>>>>>> 126defbc5644f6a3990ed3812483b64a4b640d52
>>>>>>> ab896de25a70c447b967c54f3da058a8c5f8ec92

    void OnAnimatorIK(int layerIndex)
    {
        float aimWeight = anim.GetFloat(hash.aimWeightFloat);

        anim.SetIKPosition(AvatarIKGoal.RightHand, player.position + Vector3.up);

        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, aimWeight);
    }

    void Shoot()
    {
        shooting = true;

        float fractionalDistance = (col.radius - Vector3.Distance(transform.position, player.position)) / col.radius;

        float damage = scaledDamage * fractionalDistance + minimumDamage;

        playerHealth.TakeDamage(damage);

        ShotEffects();
    }

    void ShotEffects()
    {
        laserShotLine.SetPosition(0, laserShotLine.transform.position);

        laserShotLine.SetPosition(1, player.position + Vector3.up * 1.5f);

        laserShotLine.enabled = true;

        laserShotLight.intensity = flashIntensity;       
    }
}
