using UnityEngine;
using System.Collections;

public class Bullet1 : MonoBehaviour 
{
	float damage;

	void Start()
	{
		damage = GameObject.Find("Player").GetComponent<WeaponBase>().Damage;
	}


	void OnTriggerEnter(Collider Enemy)
	{
		if (Enemy.gameObject.CompareTag ("enemy"))
		{
			Debug.Log ("Touched!");

			Enemy.GetComponent<EnemyLife> ().Touched = true;

			Enemy.gameObject.SendMessage ("OnDamage", damage);

		}

		if (Enemy.gameObject.CompareTag ("boss1"))
		{
			Debug.Log ("Touched!");

			Enemy.GetComponent<EnemyLife> ().Touched = true;

			Enemy.gameObject.SendMessage ("OnDamage", damage);

		}
	}
		
}
