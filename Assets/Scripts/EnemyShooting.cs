using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour 
{
	public float maximumDamage = 120f;
	public float minimumDamage = 45f;
    public float fadeSpeed = 10f;

	private Animator anim;
	private LineRenderer laserShotLine;
    private Light laserShotLight;
	private SphereCollider col;
	private Transform player;
	private PlayerHealth playerHealth;
	private bool shooting;
	private float scaledDamage;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
        laserShotLine = GetComponentInChildren<LineRenderer>();
        laserShotLight = GetComponent<Light>();
		col = GetComponent<SphereCollider> ();
		player = GameObject.FindGameObjectWithTag(Tags.player).transform;
		playerHealth = player.gameObject.GetComponent<PlayerHealth> ();

        laserShotLine.enabled = false;
        laserShotLight.intensity = 0f;

		scaledDamage = maximumDamage - minimumDamage;
	}
	
	// Update is called once per frame
	void Update () 
	{
        laserShotLight.intensity = Mathf.Lerp(laserShotLight.intensity, 0f, fadeSpeed * Time.deltaTime);
	
	}

    void OnAnimatorIK(int layerIndex)
    {
        anim.SetIKPosition(AvatarIKGoal.RightHand, player.position + Vector3.up);
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
    }
}
