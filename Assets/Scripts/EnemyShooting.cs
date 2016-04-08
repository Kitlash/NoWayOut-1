using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour 
{
	public float maximumDamage = 120f;
	public float minimumDamage = 45f;

	private Animator anim;
	private LineRenderer laserShotLight;
	private SphereCollider col;
	private Transform player;
	private PlayerHealth playerHealth;
	private bool shooting;
	private bool scaledDamage;

	// Use this for initialization
	void Start () 
	{
		anim = GameObject.FindGameObjectWithTag (Tags.enemy).GetComponent<Animator> ();
		col = GameObject.FindGameObjectWithTag (Tags.enemy).GetComponent<SphereCollider> ();
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		playerHealth = player.gameObject.GetComponent<PlayerHealth> ();

		//scaledDamage = maximumDamage - minimumDamage;
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*float shot = anim.GetFloat (hash.shotFloat);

		if (shot > 0.5f && !shooting)
			Shoot ();*/
	
	}
}
