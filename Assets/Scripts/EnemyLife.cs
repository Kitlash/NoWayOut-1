using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour 
{

	[SerializeField]
	float life = 100f;

	[SerializeField]
	float maxlife = 100f;

	float damage;

	[SerializeField]
	float interval;

    public WeaponBase weaponBase;

    private Animator anim;

	void Start () 
	{
        weaponBase = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<WeaponBase>();
        anim = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject == weaponBase.Bullet) 
		{
			damage = weaponBase.cur_damage;
			life -= damage;
            
		}
	}

	// Update is called once per frame
	void Update ()
    {
        if (life <= 0)
        {
<<<<<<< HEAD
            Debug.Log("Dead");
            //Destroy(gameObject, interval);
            anim.SetBool("Dead", true);
=======
            Destroy(gameObject, interval);
>>>>>>> d469c6faf600c7a3af8677aa8285893b8256a1b1
            life = maxlife;
        }
    }
}
