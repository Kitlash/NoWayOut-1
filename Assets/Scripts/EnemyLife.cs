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

	void Start () 
	{
        weaponBase = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<WeaponBase>();
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
            Destroy(gameObject, interval);
            life = maxlife;
        }
    }
}
